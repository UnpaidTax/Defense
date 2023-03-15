using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject enemyTarget;
    public float bulletSpeed = 10;

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
        //Ÿ���� ������ �߻� 
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

            Destroy(other.gameObject);
            Destroy(this.gameObject);

            Debug.Log(other.transform.GetChild(1).gameObject);
            other.transform.GetChild(1).gameObject.GetComponent<HUDHpBar>().DestoryHpBar();
        }
        else
        {

            Destroy(this.gameObject);
        }

        
        //��� �İ�
    }
}
