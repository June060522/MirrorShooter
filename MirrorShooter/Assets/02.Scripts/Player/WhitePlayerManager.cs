using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhitePlayerManager : MonoBehaviour
{
    [SerializeField] ShowPlayerHp showPlayerHp;
    PlayerManager playerManager;
    private Vector2 MinPos = new Vector2 (-17.28f,-9.5f);
    private Vector2 MaxPos = new Vector2 (17.28f,9.5f);

    SpriteRenderer spriteRenderer;
    SpriteRenderer spriteRenderer1;
    TwinkePlayer tp;
    private void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer1 = GameObject.Find("BlackPlayer").GetComponent<SpriteRenderer>();
        tp = GameObject.Find("GameManager").GetComponent<TwinkePlayer>();
    }
    void Start()
    {
        playerManager = GameObject.Find("BlackPlayer").GetComponent<PlayerManager>();
    }

    void Update()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x,MinPos.x,MaxPos.x),Mathf.Clamp(transform.position.y,MinPos.y,MaxPos.y));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("WhiteEnemyBullet") || other.CompareTag("GrayEnemyBullet") || other.CompareTag("HWhiteEnemyBullet"))
        {
            playerManager.TotalPlayerHp--;
            showPlayerHp.showHp();
            tp.Twinke();
            PoolManager.Instance.Push(other.gameObject);
        }
    }
}
