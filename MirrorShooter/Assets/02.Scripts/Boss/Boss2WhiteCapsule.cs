using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss2WhiteCapsule : MonoBehaviour
{
    Boss2 boss2;
    ShowPlayerHp showPlayerHp;

    PlayerManager playerManager;
    GameObject WhitePlayer;
    float i = 0f;

    float hp = 0f;
    float maxhp = 10f;

    float timeScale = 0f;
    void Start()
    {
        showPlayerHp = GameObject.Find("PlayerHp").GetComponent<ShowPlayerHp>();
        playerManager = GameObject.Find("BlackPlayer").GetComponent<PlayerManager>();

        boss2 = GameObject.Find("Boss2").GetComponent<Boss2>();
        hp = maxhp;
        WhitePlayer = GameObject.Find("WhitePlayer");
        
        i = Random.Range(0,360);
        transform.rotation = Quaternion.Euler(0,0,i);
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0,0,i);
        i -= 0.1f;

        if(WhitePlayer.transform.position.x < 0)
        {
            transform.position = new Vector3(-13,4.5f,0);
        }
        else
        {
            transform.position = new Vector3(13,4.5f,0);
        }

        if(hp < 0)
        {
            Destroy(gameObject);
        }

        timeScale += Time.deltaTime;

        if(timeScale > 8)
        {
            Destroy(gameObject);
            boss2.hp += 30;
            playerManager.TotalPlayerHp--;
            showPlayerHp.showHp();
        }
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
