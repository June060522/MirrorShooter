using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBullet : MonoBehaviour
{
    GameObject blackbackground;
    private void Awake()
    {
        blackbackground = GameObject.Find("BlackBackGround");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == blackbackground)
        {
            PoolManager.Instance.Push(gameObject);
        }
    }
}
