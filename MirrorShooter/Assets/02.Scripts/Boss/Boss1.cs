using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Boss1 : MonoBehaviour
{
    private bool heal = true;
    private int hp = 200;
    private int random;
    private int repeat = 0;
    [SerializeField] GameObject firePos;
    [SerializeField] GameObject grayEnemyBullet;
    private void Start()
    {
        StartCoroutine(Boss1Pattern());    
    }

    void Update()
    {
        if(hp < 50 && heal)
        {
            hp += 50;
            heal = false;
        }
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Boss1Pattern()
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
}
