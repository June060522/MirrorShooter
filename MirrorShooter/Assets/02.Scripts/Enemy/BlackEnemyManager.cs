using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackEnemyManager : MonoBehaviour
{
    PoolManager poolManager;
    private int hp = 3;
    [SerializeField] GameObject BlackBullet;
    void Start()
    {
        poolManager = GameObject.Find("PoolManager").GetComponent<PoolManager>();
        StartCoroutine(SpawnBullet());
    }

    IEnumerator SpawnBullet()
    {
        int random = 0;
        while(true)
        {
            random = Random.Range(0,10);
            if(random < 6)
                Instantiate(BlackBullet,this.transform.position,Quaternion.identity);
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
            poolManager.Push(other.gameObject);
            hp--;
        }
    }
}
