using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonEnemyBullet : MonoBehaviour
{
    private float speed = 7f;
    private GameObject WhitePlayer;
    Vector3 dir;

    private void OnEnable()
    {
    }
    void Start()
    {
        WhitePlayer = GameObject.Find("WhitePlayer");
        dir = WhitePlayer.transform.position - transform.position;
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
