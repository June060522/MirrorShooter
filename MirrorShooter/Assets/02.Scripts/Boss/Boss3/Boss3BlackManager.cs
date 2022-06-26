using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3BlackManager : MonoBehaviour
{
    [SerializeField] GameObject BlackEnemyBullet;
    [SerializeField] GameObject guidedBullet;
    private GameObject BlackPlayer;
    private Vector2 MinPos = new Vector2 (-17.28f,-9.5f);
    private Vector2 MaxPos = new Vector2 (17.28f,5.3f);

    int random = 0;
    float fireSpeed = 1f;
    void Start()
    {
        BlackPlayer = GameObject.Find("BlackPlayer");
        StartCoroutine(Fire());
        StartCoroutine(Boss3Pattern());
    }

    void Update()
    {
        transform.position = BlackPlayer.transform.position + Vector3.up * 13;
        transform.position = new Vector2(Mathf.Clamp(transform.position.x,MinPos.x,MaxPos.x),Mathf.Clamp(transform.position.y,MinPos.y,MaxPos.y));
    }

    IEnumerator Fire()
    {
        while(true)
        {
            yield return new WaitForSeconds(fireSpeed);
            PoolManager.Instance.Pop(BlackEnemyBullet,transform.position,Quaternion.identity);
        }
    }

    IEnumerator Boss3Pattern()
    {
        yield return new WaitForSeconds(3f);
        while(true)
        {
            random = Random.Range(2,3);
            switch(random)
            {
                case 1 :
                    StartCoroutine(Boss3Pattern1());
                    break;
                case 2 :
                    StartCoroutine(Boss3Pattern2());
                    break;
                case 3 :
                    StartCoroutine(Boss3Pattern3());
                    break;
            }
            yield return new WaitForSeconds(15f);
        }
    }

    IEnumerator Boss3Pattern1()
    {
        for(int i = 0; i < 2; i++)
        {
            Vector3 dir = transform.position + new Vector3(1,0,0);
            Instantiate(guidedBullet, dir, Quaternion.identity);
            Instantiate(guidedBullet, dir + new Vector3(-2,0,0), Quaternion.identity);
            yield return new WaitForSeconds(4f);
        }
    }
    IEnumerator Boss3Pattern2()
    {
        fireSpeed = 0.55f;
        yield return new WaitForSeconds(10f);
        fireSpeed = 1f;
    }
    IEnumerator Boss3Pattern3()
    {
        yield return null;
    }
}
