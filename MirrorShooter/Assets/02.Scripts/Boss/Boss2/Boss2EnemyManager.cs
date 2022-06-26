using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Boss2EnemyManager : MonoBehaviour
{
    PlayerManager playerManager;
    private int hp = 0;
    private int repeatMove;
    [SerializeField] GameObject BlackBullet;
    [SerializeField] int maxhp = 2;
    int x;
    int y;

    private void Awake()
    {
        playerManager = GameObject.Find("BlackPlayer").GetComponent<PlayerManager>();
    }

    private void OnEnable()
    {
        repeatMove = 0;
        hp = maxhp;
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
