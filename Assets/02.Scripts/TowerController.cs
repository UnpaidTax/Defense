using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{

    public int attackPower;
    public float attackCurTime = 0;
    public float attackSpeed;
    public GameObject targetEnermy;
    public GameObject bulletPrefab;
    public GameObject muzzleEffect;
    public GameObject bullet;
    public GameObject bulletStartPos;


    public enum TOWERSTATE
    {
        IDLE,
        ATTACK,
        UPGRADE,
        NONE,
    }

    TOWERSTATE towerstate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {




        switch (towerstate)
        {

            case TOWERSTATE.IDLE:
                // ����Ʈ�� ���� �ƴϸ� ������ ���ʹ� ����Ʈ�� 0���� Ÿ�� �ϰ� ���´� �������� ����
                if (targetEnermy!=null)
                {
                    towerstate = TOWERSTATE.ATTACK;
                }
                else
                {
                    targetEnermy= null;
                }
                break;
            case TOWERSTATE.ATTACK:
                // ���� �ƴϸ�  Lookat ���� Ʈ������ 
                // Ÿ�ӵ�ŸŸ���� Ŀ��Ʈ ���ݿ� ���ؼ�  ���ý��ǵ庸�� Ŀ���� ����
                // ���̸� ���� Ŀ��ƮŸ���� 0�� �ǰ�  ���´� Idle
                if (targetEnermy != null)
                {
                    transform.LookAt(new Vector3(targetEnermy.transform.position.x, transform.position.y, targetEnermy.transform.position.z));
                    attackCurTime += Time.deltaTime;

                    if(attackCurTime>attackSpeed)
                    {
                        attackCurTime = 0;
                        bullet = Instantiate(bulletPrefab, bulletStartPos.transform.position,Quaternion.identity);
                        bullet.GetComponent<BulletController>().enemyTarget = targetEnermy;

                    }

                }
                else
                {
                    attackCurTime = 0;
                    towerstate= TOWERSTATE.IDLE;
                }

                break;
            case TOWERSTATE.UPGRADE:
                break;
            case TOWERSTATE.NONE:
                break;
        }

    }
}
