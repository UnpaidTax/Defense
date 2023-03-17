using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public GameObject enemyMaker;
    public GameObject enemyController;
    public GameObject bulletPrefabs;
    public GameObject towerPrefabs;
    public int bulletPower;
    public float bulletSpeed;
    private void Start()
    {
        enemyMaker = GameObject.Find("EnemyMaker");
        enemyController.GetComponent<EnemyController>().enemyHp = 100;
        bulletSpeed = enemyController.GetComponent<EnemyController>().moveSpeed = 1;
        bulletPower = bulletPrefabs.GetComponent<BulletController>().bulletPower = 20;
        towerPrefabs.GetComponent<TowerController>().attackSpeed = 2f;
    }
    //level ���� �� ���� HP ���� 
    //l���߿� ���ʹ� ����Ŀ�� ���� ��������
    //  StageLvIUP()  ���� ���� ���ǵ� ���� �� �ؼ� ���������� �Ѿ ���� �÷��־�� ��
    public void NextStage()
    {
        enemyMaker.GetComponent<EnemyMaker>().enemyCnt = 1;
        enemyMaker.GetComponent<EnemyMaker>().enemyMaxCnt += 1;
        enemyMaker.GetComponent<EnemyMaker>().isRunning = true;
        enemyController.GetComponent<EnemyController>().enemyHp += 10;
        enemyController.GetComponent<EnemyController>().moveSpeed += 0.1f;
    }

    public void PowerUp()
    {
        bulletPrefabs.GetComponent<BulletController>().bulletPower += 10;
    }

    public void SpeedUp()
    {
        if (towerPrefabs.GetComponent<TowerController>().attackSpeed > 0.1f)
        {
            towerPrefabs.GetComponent<TowerController>().attackSpeed -= 0.1f;
        }
    }
}
