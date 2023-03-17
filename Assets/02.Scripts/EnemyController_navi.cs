using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController_navi : MonoBehaviour
{

    public Transform curTargetPos;
    public CharacterController characterController;
    public float moveSpeed;
    public float rotationSpeed = 10f;
    public int enemyHp;
    private bool isDead = false;
    public NavMeshAgent nav;
    // Start is called before the first frame update
    void Start()
    {

        nav = GetComponent<NavMeshAgent>();
        curTargetPos = gameObject.transform.Find("Destroyer").transform;
        nav.SetDestination(curTargetPos.position);

    }

    // Update is called once per frame
    void Update()
    {   
        if(!isDead) 
        {  

            float distance = Vector3.Distance(transform.position, curTargetPos.position);
            //Debug.Log(distance);
            Vector3 dir = curTargetPos.position - transform.position;
            dir.y = 0;
            dir.Normalize();
            characterController.SimpleMove(dir * moveSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), rotationSpeed * Time.deltaTime);
            //transform.LookAt(curTargetPos.position+new Vector3(0,transform.position.y,0));
            //회전해야 하는데


            if (enemyHp <= 0)
            {
                isDead = true;
            }
        }
        else
        {
            
            Destroy(this.gameObject);
        }

    }

    public void TakeDamage(int damage)
    {
        if (!isDead)
        {
            enemyHp -= damage;
        }
        if(enemyHp <= 0)
        {
            isDead = true;
            Destroy(this.gameObject);
            transform.GetChild(1).gameObject.GetComponent<HUDHpBar>().DestoryHpBar();
        }


    }
}
