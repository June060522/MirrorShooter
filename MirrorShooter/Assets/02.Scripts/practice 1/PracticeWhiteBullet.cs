using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeWhiteBullet : MonoBehaviour
{
    PracticePlayerManager playerManager;
    GameObject whiteBackground;
    private void Awake()
    {
        playerManager = GameObject.Find("BlackPlayer").GetComponent<PracticePlayerManager>();
        whiteBackground = GameObject.Find("WhiteBackGround");
    }

    private void Update()
    {
        if(playerManager.checkDie == false)
        {
            PoolManager.Instance.Push(gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject == whiteBackground)
        {
            PoolManager.Instance.Push(gameObject);
        }
    }
}
