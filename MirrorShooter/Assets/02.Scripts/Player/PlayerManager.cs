using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public int TotalPlayerHp = 6;
    private float speed = 7.5f;
    [SerializeField] GameObject WhitePlayer;
    [SerializeField] GameObject BlackPlayer;
    [SerializeField] GameObject RememberPos;
    [SerializeField] GameObject BlackBackground;
    [SerializeField] GameObject WhiteBackGround;

    [SerializeField] GameObject BlackBullet;
    [SerializeField] GameObject WhiteBullet;

    private Vector2 MinPos = new Vector2 (-17.28f,-9.5f);
    private Vector2 MaxPos = new Vector2 (17.28f,9.5f);
    private readonly string Wall;
    
    TwinkePlayer tp;

    private void Awake()
    {
        tp = GameObject.Find("GameManager").GetComponent<TwinkePlayer>();
}

    private void Start()
    {
        StartCoroutine(Fire());
    }

    void Update()
    {
        Move();
        transform.position = new Vector2(Mathf.Clamp(transform.position.x,MinPos.x,MaxPos.x),Mathf.Clamp(transform.position.y,MinPos.y,MaxPos.y));

        if(TotalPlayerHp <= 0)
        {
            Destroy(gameObject);
            Destroy(WhitePlayer);
            SceneManager.LoadScene("StartScene");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.CompareTag("Wall"))   
        {
            ChangePosition();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("BlackEnemyBullet"))
        {
            TotalPlayerHp--;

            tp.Twinke();
            
            Destroy(other.gameObject);
        }
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(x,y);
        transform.Translate(dir * speed * Time.deltaTime);
        WhitePlayer.transform.Translate(-dir * speed * Time.deltaTime);
    }

    private void ChangePosition()
    {
        RememberPos.transform.position = WhitePlayer.transform.position;
        WhitePlayer.transform.position = BlackPlayer.transform.position;
        BlackPlayer.transform.position = RememberPos.transform.position;

        RememberPos.transform.position = WhiteBackGround.transform.position;
        WhiteBackGround.transform.position = BlackBackground.transform.position;
        BlackBackground.transform.position = RememberPos.transform.position;
    }

    IEnumerator Fire()
    {
        while(true)
        {
            PoolManager.Instance.Pop(BlackBullet,transform.position, Quaternion.identity);
            PoolManager.Instance.Pop(WhiteBullet,WhitePlayer.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.4f);
        }
    }
}