using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour
{
    float a = 0;

    public float hp = 0;
    public float maxhp = 350;
    private int random;
    private int spawn;

    [SerializeField]GameObject BlackEnemyBullet;
    [SerializeField]GameObject WhiteEnemyBullet;
    [SerializeField]GameObject FirePos;

    [SerializeField]GameObject BlackEnemy;
    [SerializeField]GameObject WhiteEnemy;

    SpawnManager spawnManager;
    PlayerManager playerManager;

    private void Start()
    {
        playerManager = GameObject.Find("BlackPlayer").GetComponent<PlayerManager>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        hp = maxhp;
        StartCoroutine(Boss2Pattern());
    }
    void Update()
    {
        transform.rotation = Quaternion.Euler(0,0,a);
        a += 0.2f;

        if(hp <= 0)
        {
            Destroy(gameObject);
            spawnManager.BossDie();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("BlackBullet") || other.CompareTag("WhiteBullet"))
        {
            hp--;
            playerManager.Score += 150;
            PoolManager.Instance.Push(other.gameObject);
        }
    }

    IEnumerator Boss2Pattern()
    {
        while(true)
        {
            random = Random.Range(2,3);
            Debug.Log(random);
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
            yield return new WaitForSeconds(15f);
        }
    }

    IEnumerator Pattern1()
    {
        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 45 ;j++)
            {
                int k = Random.Range(0,360);
                spawn = Random.Range(1,3);
                if(spawn == 1)
                {
                    PoolManager.Instance.Pop(BlackEnemyBullet,FirePos.transform.position,Quaternion.Euler(0,0,k));
                }
                if(spawn == 2)
                {
                    PoolManager.Instance.Pop(WhiteEnemyBullet,FirePos.transform.position,Quaternion.Euler(0,0,k));
                }
            }
            yield return new WaitForSeconds(3f);
        }
    }

    IEnumerator Pattern2()
    {
        for (int j = 0; j < 20; j++)
        {
            FirePos.transform.position = new Vector3(1.4f,2,0);
            spawn = Random.Range(1, 3);
            if (spawn == 1)
            {
                PoolManager.Instance.Pop(BlackEnemy, FirePos.transform.position, Quaternion.identity);
            }
            if (spawn == 2)
            {
                PoolManager.Instance.Pop(WhiteEnemy, FirePos.transform.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(0.01f);
            FirePos.transform.position = new Vector3(-1.4f,2,0);
            spawn = Random.Range(1, 3);
            if (spawn == 1)
            {
                PoolManager.Instance.Pop(BlackEnemy, FirePos.transform.position, Quaternion.identity);
            }
            if (spawn == 2)
            {
                PoolManager.Instance.Pop(WhiteEnemy, FirePos.transform.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(0.01f);
        }
        yield return null;
    }

    IEnumerator Pattern3()
    {
        yield return null;
    }
}
