using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject enemyTarget;
    public float bulletSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        if (enemyTarget != null)
        {
            transform.LookAt(enemyTarget.transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //타겟이 있으면 발사 
        if(enemyTarget != null)
        {
            transform.Translate(Vector3.forward * Time.deltaTime *bulletSpeed);
        }
        else
        {
            Destroy(gameObject);
        }    
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            if(other==null)
            {
                Destroy(this.gameObject); return;
            }
            else
            {

                other.gameObject.GetComponent<EnemyController>().TakeDamage(20);
                Destroy(this.gameObject);

            }

        }
        else
        {

            Destroy(this.gameObject);
        }

        
        //상대 파고
    }
}
