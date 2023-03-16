using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public GameObject enemyMaker;
    public GameObject enemyController;
    private void Start()
    {
        enemyMaker = GameObject.Find("EnemyMaker");
        enemyController.GetComponent<EnemyController>().enemyHp = 100;
        enemyController.GetComponent<EnemyController>().moveSpeed = 1;
    }
    //level 구현 적 현재 HP 선언 
    //l나중에 에너미 메이커에 연결 해줘어야함
    //  StageLvIUP()  적수 증가 스피드 증가 등 해서 스테이지가 넘어갈 수록 올려주어야 함
    public void NextStage()
    {
        enemyMaker.GetComponent<EnemyMaker>().enemyCnt = 1;
        enemyMaker.GetComponent<EnemyMaker>().enemyMaxCnt += 5;
        enemyMaker.GetComponent<EnemyMaker>().isRunning = true;
        enemyController.GetComponent<EnemyController>().enemyHp += 10;
        enemyController.GetComponent<EnemyController>().moveSpeed += 1;
    }
}
