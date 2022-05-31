using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private float speed = 7.5f;
    [SerializeField] GameObject WhitePlayer;
    [SerializeField] GameObject BlackPlayer;
    [SerializeField] GameObject RememberPos;

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(x,y);
        transform.Translate(dir * speed * Time.deltaTime);
        WhitePlayer.transform.Translate(-dir * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.CompareTag("Wall"))
        {
            RememberPos.transform.position = WhitePlayer.transform.position;
            WhitePlayer.transform.position = BlackPlayer.transform.position;
            BlackPlayer.transform.position = RememberPos.transform.position;
        }
    }
}
