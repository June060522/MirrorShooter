using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonEnemyBulletBlack : MonoBehaviour
{
    private float speed = 7f;
    private GameObject BlackPlayer;
    Vector3 dir;
    
    void Start()
    {
    }

    private void OnEnable()
    {
        BlackPlayer = GameObject.Find("BlackPlayer");
        dir = BlackPlayer.transform.position - transform.position;
    }

    void Update()
    {
        transform.Translate(speed * dir.normalized * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("MiddleWall") || other.CompareTag("SideWall"))
        {
            PoolManager.Instance.Push(gameObject);
        }
    }
}
