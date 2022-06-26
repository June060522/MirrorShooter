using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] StageData stageData;
    [SerializeField] PlayerManager playerManager;

    [SerializeField] GameObject boss1;
    [SerializeField] GameObject boss2;
    [SerializeField] Canvas boss2Slider;
    [SerializeField] GameObject boss3;
    [SerializeField] GameObject boss4;
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

    private void Update()
    {
        if(playerManager.Score >= 5000 && phase == Phase.easy)
        {
            StopCoroutine(EnemySpawn());
            Instantiate(boss1);
            phase = Phase.normal;
        }
        if(playerManager.Score >= 30000 && phase == Phase.normal)
        {
            StopCoroutine(EnemySpawn());
            Instantiate(boss2);
            Instantiate(boss2Slider);
            phase = Phase.hard;
        }
        if(playerManager.Score >= 70000 && phase == Phase.hard)
        {
            StopCoroutine(EnemySpawn());
            Instantiate(boss3);
            phase = Phase.expect;
        }
        if(playerManager.Score >= 130000 && phase == Phase.expect)
        {
            StopCoroutine(EnemySpawn());
            Instantiate(boss4);
        }
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
            yield return new WaitForSeconds(3f);
        }

        while((short)phase == 1)
        {
            float x = Random.Range(stageData.MinLimit.x + 3.1f,stageData.MaxLimit.x - 3.1f);
            float y = Random.Range(stageData.MaxLimit.y - 1f,stageData.MaxLimit.y - 3.5f);
            Vector3 randomPos = new Vector3(x,y,0);
            int spawnvalue = Random.Range(0,1000);
            if(spawnvalue > 499)
                PoolManager.Instance.Pop(BlackEnemy,randomPos,Quaternion.identity);
            else
                PoolManager.Instance.Pop(WhiteEnemy,randomPos,Quaternion.identity);
            yield return new WaitForSeconds(2f);
        }

        while ((short)phase == 2)
        {
            float x = Random.Range(stageData.MinLimit.x + 3.1f, stageData.MaxLimit.x - 3.1f);
            float y = Random.Range(stageData.MaxLimit.y - 1f, stageData.MaxLimit.y - 3.5f);
            Vector3 randomPos = new Vector3(x, y, 0);
            int spawnvalue = Random.Range(0, 1000);
            if (spawnvalue > 499)
                PoolManager.Instance.Pop(BlackEnemy, randomPos, Quaternion.identity);
            else
                PoolManager.Instance.Pop(WhiteEnemy, randomPos, Quaternion.identity);
            yield return new WaitForSeconds(1.5f);
        }

        while ((short)phase == 3)
        {
            float x = Random.Range(stageData.MinLimit.x + 3.1f, stageData.MaxLimit.x - 3.1f);
            float y = Random.Range(stageData.MaxLimit.y - 1f, stageData.MaxLimit.y - 3.5f);
            Vector3 randomPos = new Vector3(x, y, 0);
            int spawnvalue = Random.Range(0, 1000);
            if (spawnvalue > 499)
                PoolManager.Instance.Pop(BlackEnemy, randomPos, Quaternion.identity);
            else
                PoolManager.Instance.Pop(WhiteEnemy, randomPos, Quaternion.identity);
            yield return new WaitForSeconds(0.75f);
        }
    }

    public void BossDie()
    {
        StartCoroutine(EnemySpawn());
    }
}
