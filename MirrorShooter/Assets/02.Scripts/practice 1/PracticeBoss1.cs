using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PracticeBoss1 : MonoBehaviour
{
    PracticePlayerManager playerManager;

    private bool heal = true;
    public float hp = 0;
    public float maxhp = 150;
    private int random;
    private int repeat = 0;
    [SerializeField] GameObject firePos;
    [SerializeField] GameObject grayEnemyBullet;
    private void Start()
    {
        playerManager = GameObject.Find("BlackPlayer").GetComponent<PracticePlayerManager>();
        hp = maxhp;
        StartCoroutine(Boss1Pattern());
    }

    void Update()
    {
        if(hp < 50 && heal)
        {
            hp += 70;
            heal = false;
        }
        if(hp <= 0 || playerManager.checkDie == false)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("BlackBullet") || other.CompareTag("WhiteBullet"))
        {
            hp--;
            PoolManager.Instance.Push(other.gameObject);
        }
    }

    IEnumerator Boss1Pattern()
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
            yield return new WaitForSeconds(15f);
        }
    }

    IEnumerator Pattern1()
    {
        repeat = 0;
        int i = 110;
        while(repeat < 21)
        {
            i -= 10;
            PoolManager.Instance.Pop(grayEnemyBullet,firePos.transform.position,Quaternion.Euler(0,0,i));
            repeat++;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(3f);
        i = -110;
        repeat = 0;
        while(repeat < 21)
        {
            i += 10;
            PoolManager.Instance.Pop(grayEnemyBullet,firePos.transform.position,Quaternion.Euler(0,0,i));
            repeat++;
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator Pattern2()
    {
        int i = 0;
        transform.DOMove(new Vector3(15,7,0),3f);   
        yield return new WaitForSeconds(2f);
        for(int r = 0; r < 5; r++)
        {
            PoolManager.Instance.Pop(grayEnemyBullet,firePos.transform.position,Quaternion.Euler(0,0,i));
            i -= 20;
        }
        yield return new WaitForSeconds(1f);

        i = -30;
        transform.DOMove(new Vector3(9,2,0),1f);
        yield return new WaitForSeconds(1f);
        for(int r = 0; r < 5; r++)
        {
            PoolManager.Instance.Pop(grayEnemyBullet,firePos.transform.position,Quaternion.Euler(0,0,i));
            i += 15;
        }
        yield return new WaitForSeconds(1f);

        i = 30;
        transform.DOMove(new Vector3(-9,2,0),3f);
        yield return new WaitForSeconds(2.5f);
        for(int r = 0; r < 5; r++)
        {
            PoolManager.Instance.Pop(grayEnemyBullet,firePos.transform.position,Quaternion.Euler(0,0,i));
            i -= 15;
        }
        yield return new WaitForSeconds(1f);

        i = 0;
        transform.DOMove(new Vector3(-15,7,0),1f);
        yield return new WaitForSeconds(1f);
        for(int r = 0; r < 5; r++)
        {
            PoolManager.Instance.Pop(grayEnemyBullet,firePos.transform.position,Quaternion.Euler(0,0,i));
            i += 20;
        }
        yield return new WaitForSeconds(1f);

        transform.DOMove(new Vector3(0,3.5f,0),3f);
    }

    IEnumerator Pattern3()
    {
        for(int k = 0; k < 6; k++)
        {
            float j = 0;
            for(int i = 0; i < 10; i++)
            {
                j = Random.Range(-16f, 16f);
                Vector3 pos = new Vector3 (j,10,0);
                PoolManager.Instance.Pop(grayEnemyBullet,pos,Quaternion.identity);
            }
            yield return new WaitForSeconds(2f);
        }
    }
}
