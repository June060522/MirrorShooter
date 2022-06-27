using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss4 : MonoBehaviour
{
    PlayerManager playerManager;
    SpawnManager spawnManager;

    float i = 45f;
    int random = 0;
    
    public float hp = 0f;
    public float maxHp = 700f;
    public bool boss4DieCheck = false;

    [SerializeField]GameObject hiddenScreen;
    [SerializeField] GameObject GrayEnemyBullet;
    [SerializeField] GameObject BlackEnemyBullet;
    [SerializeField] GameObject WhiteEnemyBullet;
    private void Awake()
    {
    }
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        playerManager = GameObject.Find("BlackPlayer").GetComponent<PlayerManager>();
        hp = maxHp;
        StartCoroutine(Boss4Pattern());
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0,0,i);
        i += 10f;

        if(hp <= 0 || playerManager.checkDie == false)
        {
            boss4DieCheck = true;
            spawnManager.BossDie();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("BlackBullet") || other.CompareTag("WhiteBullet"))
        {
            hp--;
            playerManager.Score += 300;
            PoolManager.Instance.Push(other.gameObject);
        }
    }

    IEnumerator Boss4Pattern()
    {
        while(true)
        {
            random = Random.Range(1,4);
            switch(random)
            {
                case 1 :
                    StartCoroutine(Pattern1());
                    break;
                case 2 :
                    StartCoroutine(Pattern2());
                    break;
                case 3 :
                    StartCoroutine(Pattern3());
                    break;
            }
            yield return new WaitForSeconds(6.5f);
        }
    }

    IEnumerator Pattern1()
    {
        float i = 0;
        int randomSpawn = 0;
        for(i = 0f; i < 360; i += 5)
        {
            randomSpawn = Random.Range(1,4);
            switch(randomSpawn)
            {
                case 1 :
                    PoolManager.Instance.Pop(BlackEnemyBullet,transform.position,Quaternion.Euler(0,0,i));
                    break;
                case 2 :
                    PoolManager.Instance.Pop(WhiteEnemyBullet,transform.position,Quaternion.Euler(0,0,i));
                    break;
                case 3 :
                    PoolManager.Instance.Pop(GrayEnemyBullet,transform.position,Quaternion.Euler(0,0,i));
                    break;
            }
        }
        yield return new WaitForSeconds(2f);
        hiddenScreen.SetActive(true);
        yield return new WaitForSeconds(4f);
        hiddenScreen.SetActive(false);
        yield return null;
    }

    IEnumerator Pattern2()
    {
        int randomSpawn = 0;
        for(int k = 0; k < 2; k++)
        {
            for(float i = 16.5f; i > -16.5f; i -= 1.1f)
            {
                Vector3 dir = new Vector3(i,9,0);
                randomSpawn = Random.Range(1,4);
                switch(randomSpawn)
                {
                    case 1 :
                        PoolManager.Instance.Pop(BlackEnemyBullet,dir,Quaternion.identity);
                        break;
                    case 2 :
                        PoolManager.Instance.Pop(WhiteEnemyBullet,dir,Quaternion.identity);
                        break;
                    case 3 :
                        PoolManager.Instance.Pop(GrayEnemyBullet,dir,Quaternion.identity);
                        break;
                }
            }
            yield return new WaitForSeconds(3f);
        }
        yield return null;
    }

    IEnumerator Pattern3()
    {
        for(int i = 0;i < 2; i++)
        {
            for(int j = 0; j < 360; j += 15)
            {
                PoolManager.Instance.Pop(BlackEnemyBullet,transform.position,Quaternion.Euler(0,0,j));
            }
            yield return new WaitForSeconds(1f);
            for(int j = 5; j < 360; j += 15)
            {
                PoolManager.Instance.Pop(WhiteEnemyBullet,transform.position,Quaternion.Euler(0,0,j));
            }
            yield return new WaitForSeconds(1f);
            for(int j = 10; j < 360; j += 15)
            {
                PoolManager.Instance.Pop(GrayEnemyBullet,transform.position,Quaternion.Euler(0,0,j));
            }
            yield return new WaitForSeconds(1f);
        }
        yield return null;
    }
}
