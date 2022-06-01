using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackEnemyManager : MonoBehaviour
{
    [SerializeField] GameObject BlackBullet;
    void Start()
    {
        StartCoroutine(SpawnBullet());
    }

    IEnumerator SpawnBullet()
    {
        while(true)
        {
            Instantiate(BlackBullet,this.transform.position,Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }
    void Update()
    {
        
    }
}
