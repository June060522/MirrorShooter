using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDiePlayerMove : MonoBehaviour
{
    [SerializeField] GameObject BlackPlayer;
    [SerializeField] GameObject rememberPos;

    private void OnEnable()
    {
        StartCoroutine(PlayerDieMove());
    }

    IEnumerator PlayerDieMove()
    {
        while(true)
        {
            transform.position += new Vector3(1,0,0) * 2f * Time.deltaTime;
            BlackPlayer.transform.position += new Vector3(-1,0,0) * 2f * Time.deltaTime;

            if(transform.position.x > 18.4f)
            {
                rememberPos.transform.position = BlackPlayer.transform.position;
                BlackPlayer.transform.position = transform.position;
                transform.position = rememberPos.transform.position;

            }
            yield return null;
        }
    }
}
