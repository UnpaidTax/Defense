using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject enemyTarget;
    public float bulletSpeed = 20;
    public int bulletPower;
    public GameObject getShootVFX;
    public GameObject getShoot;

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
                getShoot = Instantiate(getShootVFX, transform.position, Quaternion.identity);
                Destroy(getShoot,2f);
                other.gameObject.GetComponent<EnemyController>().TakeDamage(bulletPower);
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
