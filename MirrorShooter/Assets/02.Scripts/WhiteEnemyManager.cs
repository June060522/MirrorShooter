using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteEnemyManager : MonoBehaviour
{
    private int hp = 3;
    [SerializeField] GameObject WhiteBullet;
    void Start()
    {
        StartCoroutine(SpawnBullet());
    }

    IEnumerator SpawnBullet()
    {
        while(true)
        {
            Instantiate(WhiteBullet,this.transform.position,Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Bullet"))
        {

        }
    }
}
