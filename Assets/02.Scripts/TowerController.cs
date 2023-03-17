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
                // 리스트가 널이 아니면 디테팅 에너미 리스트에 0번을 타겟 하고 상태는 공격으로 변경
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
                // 널이 아니면  Lookat 적의 트랜스폼 
                // 타임델타타임을 커런트 공격에 더해서  어택스피드보다 커지면 공격
                // 널이면 어택 커런트타임이 0이 되고  상태는 Idle
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
