 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteEnemyManager : MonoBehaviour
{
    PlayerManager playerManager;
    private int hp = 0;
    private int repeatMove = 0;
    int random = 0;
    [SerializeField] GameObject WhiteBullet;
    [SerializeField] int maxHp = 3;

    private void Start()
    {
        playerManager = GameObject.Find("BlackPlayer").GetComponent<PlayerManager>();
    }
    private void OnEnable()
    {
        repeatMove = 0;
        hp = maxHp;
        StartCoroutine(SpawnMove());
        StartCoroutine(SpawnBullet());
    }

    IEnumerator SpawnMove()
    {
        while(repeatMove < 50)
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
        while(true)
        {
            yield return new WaitForSeconds(1f);
            random = Random.Range(0,10);
            if(random < 6)
                PoolManager.Instance.Pop(WhiteBullet,this.transform.position,Quaternion.identity);
        }
    }

    private void Update()
    {
        if(hp <= 0)
        {
            playerManager.Score += 100;
            PoolManager.Instance.Push(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("WhiteBullet"))
        {
            hp--;
            PoolManager.Instance.Push(other.gameObject);
        }
        
        if(other.CompareTag("MiddleWall") || other.CompareTag("SideWall"))
        {
            PoolManager.Instance.Push(gameObject);
        }
    }
}
