using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] StageData stageData;
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
            float x = Random.Range(stageData.MinLimit.x + 3.1f,stageData.MaxLimit.x - 3.1f);
            float y = Random.Range(stageData.MaxLimit.y - 1f,stageData.MaxLimit.y - 3.5f);
            Vector3 randomPos = new Vector3(x,y,0);
            int spawnvalue = Random.Range(0,1000);
            if(spawnvalue > 499)
                PoolManager.Instance.Pop(BlackEnemy,randomPos,Quaternion.identity);
            else
                PoolManager.Instance.Pop(WhiteEnemy,randomPos,Quaternion.identity);
            yield return new WaitForSeconds(2.5f);
        }
    }
}
