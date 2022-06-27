using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PracticeBoss3White : MonoBehaviour
{
    PracticePlayerManager playerManager;

    [SerializeField] GameObject WhiteEnemyBullet;
    [SerializeField] GameObject guidedBullet;
    [SerializeField] PracticeBoss3Black boss3blackManager;

    private GameObject Boss3Black;
    private GameObject WhitePlayer;
    private Vector2 MinPos = new Vector2 (-17.28f,-9.5f);
    private Vector2 MaxPos = new Vector2 (17.28f,5.3f);

    public float hp = 1;
    private float saveHp;
    public float maxHp = 500;

    int random = 0;
    float fireSpeed = 1f;
    void Start()
    {
        Boss3Black = GameObject.Find("Boss3Black");
        playerManager = GameObject.Find("BlackPlayer").GetComponent<PracticePlayerManager>();
        hp = maxHp;
        WhitePlayer = GameObject.Find("WhitePlayer");
        StartCoroutine(Fire());
        StartCoroutine(Boss3Pattern());
    }

    void Update()
    {
        transform.position = WhitePlayer.transform.position + Vector3.up * 13;
        transform.position = new Vector2(Mathf.Clamp(transform.position.x,MinPos.x,MaxPos.x),Mathf.Clamp(transform.position.y,MinPos.y,MaxPos.y));

        if(hp <= 0 || playerManager.checkDie == false)
        {
            Destroy(Boss3Black);
            Destroy(gameObject);
            SceneManager.LoadScene("StartScene");
        }
    }

    IEnumerator Fire()
    {
        yield return new WaitForSeconds(0.4f);
        while(true)
        {
            yield return new WaitForSeconds(fireSpeed);
            PoolManager.Instance.Pop(WhiteEnemyBullet,transform.position,Quaternion.identity);
        }
    }

    IEnumerator Boss3Pattern()
    {
        yield return new WaitForSeconds(3f);
        while(true)
        {
            random = Random.Range(1,4);
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
        yield return new WaitForSeconds(0.4f);
        fireSpeed = 0.55f;
        for(int i = 0; i < 18; i++)
        {
            PoolManager.Instance.Pop(WhiteEnemyBullet,transform.position,Quaternion.Euler(0,0,25));
            PoolManager.Instance.Pop(WhiteEnemyBullet,transform.position,Quaternion.Euler(0,0,-25));
            yield return new WaitForSeconds(fireSpeed);
        }
        fireSpeed = 1f;
        yield return null;
    }
    IEnumerator Boss3Pattern3()
    {
        transform.localScale = new Vector3(8,8,1);
        saveHp = hp;
        yield return new WaitForSeconds(12f);
        hp = saveHp;
        transform.localScale = new Vector3(5,5,1);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("WhiteBullet"))
        {
            hp--;
            PoolManager.Instance.Push(other.gameObject);
        }
    }
}
