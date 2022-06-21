using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackEnemyManager : MonoBehaviour
{
    private int hp = 3;
    [SerializeField] GameObject BlackBullet;
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
                PoolManager.Instance.Pop(BlackBullet,this.transform.position,Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }
    void Update()
    {
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("BlackBullet"))
        {
            PoolManager.Instance.Push(other.gameObject);
            hp--;
        }
    }
}
