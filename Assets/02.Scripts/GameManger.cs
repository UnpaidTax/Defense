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
    //level ���� �� ���� HP ���� 
    //l���߿� ���ʹ� ����Ŀ�� ���� ��������
    //  StageLvIUP()  ���� ���� ���ǵ� ���� �� �ؼ� ���������� �Ѿ ���� �÷��־�� ��
    public void NextStage()
    {
        enemyMaker.GetComponent<EnemyMaker>().enemyCnt = 1;
        enemyMaker.GetComponent<EnemyMaker>().enemyMaxCnt += 5;
        enemyMaker.GetComponent<EnemyMaker>().isRunning = true;
        enemyController.GetComponent<EnemyController>().enemyHp += 10;
        enemyController.GetComponent<EnemyController>().moveSpeed += 1;
    }
}
