using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBullet : MonoBehaviour
{
    GameObject whiteBackground;
    private void Awake()
    {
        whiteBackground = GameObject.Find("WhiteBackGround");
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject == whiteBackground)
        {
            PoolManager.Instance.Push(gameObject);
        }
    }
}
