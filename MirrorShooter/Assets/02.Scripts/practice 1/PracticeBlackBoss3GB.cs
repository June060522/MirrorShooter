using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeBlackBoss3GB : MonoBehaviour
{
    PracticePlayerHpView showPlayerHp;
    PracticePlayerManager playerManager;
    GameObject target;
    void Start()
    {
        showPlayerHp = GameObject.Find("PlayerHp").GetComponent<PracticePlayerHpView>();
        playerManager = GameObject.Find("BlackPlayer").GetComponent<PracticePlayerManager>();
        target = GameObject.Find("BlackPlayer");
        Destroy(gameObject,5f);
    }

    void Update()
    {
        Vector3 dir = target.transform.position - transform.position;
        transform.position += dir *Time.deltaTime * 1f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("BlackPlayer"))
        {
            playerManager.TotalPlayerHp--;
            showPlayerHp.showHp();
            Destroy(gameObject);
        }
    }
}
