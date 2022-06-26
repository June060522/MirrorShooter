using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackEnemyBulletManager : MonoBehaviour
{
    private float speed = 7f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(speed * Vector2.down * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("MiddleWall") || other.CompareTag("SideWall"))
        {
            PoolManager.Instance.Push(gameObject);
        }
    }
}
