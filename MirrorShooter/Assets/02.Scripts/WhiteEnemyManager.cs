using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteEnemyManager : MonoBehaviour
{
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
    void Update()
    {
        
    }
}
