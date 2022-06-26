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
    [SerializeField] GameObject boss3White;
    [SerializeField] GameObject boss3Black;
    [SerializeField] GameObject boss4;
    [SerializeField] GameObject hiddenScreen;
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

    [SerializeField] GameObject HBlackEnemy;
    [SerializeField] GameObject HWhiteEnemy;
    void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    private void Update()
    {
        if(playerManager.Score >= 5000 && phase == Phase.easy)
        {
            StopAllCoroutines();
            Instantiate(boss1);
            phase = Phase.normal;
        }
        if(playerManager.Score >= 30000 && phase == Phase.normal)
        {
            StopAllCoroutines();
            Instantiate(boss2);
            Instantiate(boss2Slider);
            phase = Phase.hard;
        }
        if(playerManager.Score >= 130000 && phase == Phase.hard)
        {
            StopAllCoroutines();
            Instantiate(boss3Black);
            Instantiate(boss3White);
            phase = Phase.expect;
        }
        if(playerManager.Score >= 400000 && phase == Phase.expect)
        {
            StopAllCoroutines();
            Instantiate(boss4);
            Instantiate(hiddenScreen);
        }
    }

    IEnumerator EnemySpawn()
    {
        while(phase == Phase.easy)
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

        while(phase == Phase.normal)
        {
            float x = Random.Range(stageData.MinLimit.x + 3.1f,stageData.MaxLimit.x - 3.1f);
            float y = Random.Range(stageData.MaxLimit.y - 1f,stageData.MaxLimit.y - 3.5f);
            Vector3 randomPos = new Vector3(x,y,0);
            int spawnvalue = Random.Range(0,1000);
            if(spawnvalue > 699)
                PoolManager.Instance.Pop(BlackEnemy,randomPos,Quaternion.identity);
            else if(spawnvalue > 399)
                PoolManager.Instance.Pop(WhiteEnemy,randomPos,Quaternion.identity);
            else if(spawnvalue > 199)
                PoolManager.Instance.Pop(HBlackEnemy,randomPos,Quaternion.identity);
            else
                PoolManager.Instance.Pop(HWhiteEnemy,randomPos,Quaternion.identity);
            yield return new WaitForSeconds(2f);
        }

        while (phase == Phase.hard)
        {
            float x = Random.Range(stageData.MinLimit.x + 3.1f, stageData.MaxLimit.x - 3.1f);
            float y = Random.Range(stageData.MaxLimit.y - 1f, stageData.MaxLimit.y - 3.5f);
            Vector3 randomPos = new Vector3(x, y, 0);
            int spawnvalue = Random.Range(0, 1000);
            if(spawnvalue > 799)
                PoolManager.Instance.Pop(BlackEnemy,randomPos,Quaternion.identity);
            else if(spawnvalue > 599)
                PoolManager.Instance.Pop(WhiteEnemy,randomPos,Quaternion.identity);
            else if(spawnvalue > 299)
                PoolManager.Instance.Pop(HBlackEnemy,randomPos,Quaternion.identity);
            else
                PoolManager.Instance.Pop(HWhiteEnemy,randomPos,Quaternion.identity);
            yield return new WaitForSeconds(1.5f);
        }

        while (phase == Phase.expect)
        {
            float x = Random.Range(stageData.MinLimit.x + 3.1f, stageData.MaxLimit.x - 3.1f);
            float y = Random.Range(stageData.MaxLimit.y - 1f, stageData.MaxLimit.y - 3.5f);
            Vector3 randomPos = new Vector3(x, y, 0);
            int spawnvalue = Random.Range(0, 1000);
            if(spawnvalue > 899)
                PoolManager.Instance.Pop(BlackEnemy,randomPos,Quaternion.identity);
            else if(spawnvalue > 799)
                PoolManager.Instance.Pop(WhiteEnemy,randomPos,Quaternion.identity);
            else if(spawnvalue > 399)
                PoolManager.Instance.Pop(HBlackEnemy,randomPos,Quaternion.identity);
            else
                PoolManager.Instance.Pop(HWhiteEnemy,randomPos,Quaternion.identity);
            yield return new WaitForSeconds(0.75f);
        }
    }

    public void BossDie()
    {
        StartCoroutine(EnemySpawn());
    }
}
