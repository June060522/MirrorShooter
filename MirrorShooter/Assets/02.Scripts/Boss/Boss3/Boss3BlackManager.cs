using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3BlackManager : MonoBehaviour
{
    PlayerManager playerManager;
    [SerializeField] Boss3WhiteManager boss3WhiteManager;
    [SerializeField] GameObject BlackEnemyBullet;
    [SerializeField] GameObject guidedBullet;
    private GameObject BlackPlayer;
    private Vector2 MinPos = new Vector2 (-17.28f,-9.5f);
    private Vector2 MaxPos = new Vector2 (17.28f,5.3f);

    int random = 0;
    float fireSpeed = 1f;
    void Start()
    {
        playerManager = GameObject.Find("BlackPlayer").GetComponent<PlayerManager>();
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
            random = Random.Range(3,4);
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
        for(int i = 0; i < 18; i++)
        {
            PoolManager.Instance.Pop(BlackEnemyBullet,transform.position,Quaternion.Euler(0,0,25));
            PoolManager.Instance.Pop(BlackEnemyBullet,transform.position,Quaternion.Euler(0,0,-25));
            yield return new WaitForSeconds(fireSpeed);
        }
        fireSpeed = 1f;
        yield return null;
    }
    IEnumerator Boss3Pattern3()
    {
        transform.localScale = new Vector3(8,8,1);
        yield return new WaitForSeconds(12f);
        transform.localScale = new Vector3(5,5,1);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("BlackBullet"))
        {
            boss3WhiteManager.hp--;
            playerManager.Score += 300;
            PoolManager.Instance.Push(other.gameObject);
        }
    }
}
