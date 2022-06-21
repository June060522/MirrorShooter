using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteEnemyManager : MonoBehaviour
{
    private int hp = 2;
    [SerializeField] GameObject WhiteBullet;
    void Start()
    {
        StartCoroutine(SpawnBullet());
    }

    IEnumerator SpawnBullet()
    {
        int random = 0;
        while(true)
        {
            random = Random.Range(0,10);
            if(random < 6)
                PoolManager.Instance.Pop(WhiteBullet,this.transform.position,Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }

    private void Update()
    {
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("WhiteBullet"))
        {
            hp--;
            PoolManager.Instance.Push(other.gameObject);
        }
    }
}
