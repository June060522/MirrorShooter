using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHexagonEnemy : MonoBehaviour
{
    PlayerManager playerManager;
    private int hp = 0;
    private int repeatMove;
    [SerializeField] GameObject BlackBullet;
    [SerializeField] int maxhp = 4;
    
    private void Awake()
    {
        playerManager = GameObject.Find("BlackPlayer").GetComponent<PlayerManager>();
    }

    private void OnEnable()
    {
        repeatMove = 0;
        hp = maxhp;
        StartCoroutine(SpawnMove());
        StartCoroutine(SpawnBullet());
    }

    IEnumerator SpawnMove()
    {
        while(repeatMove < 170)
        {
            transform.position += Vector3.down * 5 * Time.deltaTime;
            repeatMove++;
            yield return new WaitForSeconds(0.01f);
        }
    }
    
    private void OnDisable()
    {
        StopCoroutine(SpawnMove());
        StopCoroutine(SpawnBullet());
    }

    IEnumerator SpawnBullet()
    {
        int random = 0;
        while(true)
        {
            yield return new WaitForSeconds(1f);
            random = Random.Range(0,10);
            if(random < 6)
                PoolManager.Instance.Pop(BlackBullet,this.transform.position,Quaternion.identity);
        }
    }
    void Update()
    {
        if(hp <= 0)
        {
            playerManager.Score += 100;
            PoolManager.Instance.Push(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("BlackBullet"))
        {
            PoolManager.Instance.Push(other.gameObject);
            hp--;
        }

        if(other.CompareTag("MiddleWall") || other.CompareTag("SideWall"))
        {
            PoolManager.Instance.Push(gameObject);
        }
    }
}
