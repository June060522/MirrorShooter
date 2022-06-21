using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    enum Phase : short
    {
        easy = 0,
        normal = 1,
        hard = 2,
        expect = 3,
    }

    [SerializeField]private Phase phase = Phase.easy;
    [SerializeField] GameObject BlackEnemy;
    [SerializeField] GameObject WhiteEnemy;
    void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {
        while((short)phase == 0)
        {
            int spawnvalue = Random.Range(0,1000);
            if(spawnvalue > 499)
                PoolManager.Instance.Pop(BlackEnemy,transform.position,Quaternion.identity);
            else
                PoolManager.Instance.Pop(WhiteEnemy,transform.position,Quaternion.identity);
            yield return null;
        }
    }
}
