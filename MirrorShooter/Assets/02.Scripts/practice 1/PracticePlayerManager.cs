using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PracticePlayerManager : MonoBehaviour
{

    public int TotalPlayerHp = 6;
    private float speed = 7.5f;

    public bool checkDie = true;

    [SerializeField] GameObject WhitePlayer;
    [SerializeField] GameObject BlackPlayer;
    [SerializeField] GameObject RememberPos;
    [SerializeField] GameObject BlackBackground;
    [SerializeField] GameObject WhiteBackGround;

    [SerializeField] GameObject BlackBullet;
    [SerializeField] GameObject WhiteBullet;

    [SerializeField] GameObject CenterLine;
    [SerializeField] GameObject SideLine;
    [SerializeField] GameObject SideLine1;

    [SerializeField] Canvas scoreCanvas;
    [SerializeField] GameObject gameOverManager;
    private Vector2 MinPos = new Vector2 (-17.28f,-9.5f);
    private Vector2 MaxPos = new Vector2 (17.28f,7.4f);
    private readonly string Wall;
    [SerializeField]PracticePlayerHpView showPlayerHp;
    TwinkePlayer tp;

    private void Awake()
    {
        tp = GameObject.Find("GameManager").GetComponent<TwinkePlayer>();
    }

    private void Start()
    {
        StartCoroutine(Fire());
        StartCoroutine(Move());
    }

    void Update()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x,MinPos.x,MaxPos.x),Mathf.Clamp(transform.position.y,MinPos.y,MaxPos.y));

        if(TotalPlayerHp <= 0 && checkDie)
        {
            StartCoroutine(OnDie());
            checkDie = false;
        }
    }

    IEnumerator OnDie()
    {
        StopAllCoroutines();
        SceneManager.LoadScene("StartScene");
        yield return null;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.CompareTag("MiddleWall"))   
        {
            MiddleChange();
        }
        if(other.collider.CompareTag("SideWall"))
        {
            ChangePosition();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("BlackEnemyBullet") || other.CompareTag("GrayEnemyBullet") || other.CompareTag("HBlackEnemyBullet"))
        {
            TotalPlayerHp--;
            showPlayerHp.showHp();
            tp.Twinke();
            
            PoolManager.Instance.Push(other.gameObject);
        }
    }

    IEnumerator Move()
    {
        while(true)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            Vector2 dir = new Vector2(x,y);
            transform.Translate(dir * speed * Time.deltaTime);
            WhitePlayer.transform.Translate(-dir * speed * Time.deltaTime);
            yield return null;
        }
    }

    private void MiddleChange()
    {
        if (BlackPlayer.transform.position.x < 0)
        {
            RememberPos.transform.position = WhitePlayer.transform.position + Vector3.right * 0.1f;
            WhitePlayer.transform.position = BlackPlayer.transform.position + Vector3.left * 0.1f;
            BlackPlayer.transform.position = RememberPos.transform.position;
        }
        else if (BlackPlayer.transform.position.x > 0)
        {
            RememberPos.transform.position = WhitePlayer.transform.position + Vector3.left * 0.1f;
            WhitePlayer.transform.position = BlackPlayer.transform.position + Vector3.right * 0.1f;
            BlackPlayer.transform.position = RememberPos.transform.position;
        }

        RememberPos.transform.position = WhiteBackGround.transform.position;
        WhiteBackGround.transform.position = BlackBackground.transform.position;
        BlackBackground.transform.position = RememberPos.transform.position;

        Vector3 chRo = CenterLine.transform.eulerAngles;
        chRo.z += 180;
        CenterLine.transform.eulerAngles = chRo;
        chRo = SideLine.transform.eulerAngles;
        chRo.z += 180;
        SideLine.transform.eulerAngles = chRo;
        chRo = SideLine1.transform.eulerAngles;
        chRo.z += 180;
        SideLine1.transform.eulerAngles = chRo;
    }

    private void ChangePosition()
    {
        if(BlackPlayer.transform.position.x > 0)
        {
            RememberPos.transform.position = WhitePlayer.transform.position + Vector3.right * 0.1f;
            WhitePlayer.transform.position = BlackPlayer.transform.position + Vector3.left * 0.1f; 
            BlackPlayer.transform.position = RememberPos.transform.position;
        }
        else if(BlackPlayer.transform.position.x < 0)
        {
            RememberPos.transform.position = WhitePlayer.transform.position + Vector3.left * 0.1f;
            WhitePlayer.transform.position = BlackPlayer.transform.position + Vector3.right * 0.1f;
            BlackPlayer.transform.position = RememberPos.transform.position;
        }

        RememberPos.transform.position = WhiteBackGround.transform.position;
        WhiteBackGround.transform.position = BlackBackground.transform.position;
        BlackBackground.transform.position = RememberPos.transform.position;

        Vector3 chRo = CenterLine.transform.eulerAngles;
        chRo.z += 180;
        CenterLine.transform.eulerAngles = chRo;
        chRo = SideLine.transform.eulerAngles;
        chRo.z += 180;
        SideLine.transform.eulerAngles = chRo;
        chRo = SideLine1.transform.eulerAngles;
        chRo.z += 180;
        SideLine1.transform.eulerAngles = chRo;
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