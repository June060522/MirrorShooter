using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeBlackBullet : MonoBehaviour
{
    PracticePlayerManager playerManager;
    GameObject blackbackground;
    private void Awake()
    {
        playerManager = GameObject.Find("BlackPlayer").GetComponent<PracticePlayerManager>();
        blackbackground = GameObject.Find("BlackBackGround");
    }

    private void Update()
    {
        if(playerManager.checkDie == false)
        {
            PoolManager.Instance.Push(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == blackbackground)
        {
            PoolManager.Instance.Push(gameObject);
        }
    }
}
