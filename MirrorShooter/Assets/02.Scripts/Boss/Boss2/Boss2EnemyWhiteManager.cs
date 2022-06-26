 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Boss2EnemyWhiteManager : MonoBehaviour
{
    PlayerManager playerManager;
    private int hp = 0;
    int random = 0;
    [SerializeField] GameObject WhiteBullet;
    [SerializeField] int maxHp = 3;
    int x;
    int y;

    private void Start()
    {
        playerManager = GameObject.Find("BlackPlayer").GetComponent<PlayerManager>();
    }
    private void OnEnable()
    {
        hp = maxHp;
        x = Random.Range(16,-17);
        y = Random.Range(0,7);
        transform.DOMove(new Vector3(x,y,0),2f);
        StartCoroutine(SpawnBullet());
    }

    private void OnDisable()
    {
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
