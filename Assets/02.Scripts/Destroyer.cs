using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log($"충돌  :  {other.gameObject}");
        //Destroy( other.gameObject );
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            other.transform.GetChild(1).gameObject.GetComponent<HUDHpBar>().DestoryHpBar();
            //Debug.Log("충돌 ");
        }
    }
}
