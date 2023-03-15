using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetecting : MonoBehaviour
{
    public TowerController towerController;

    public List<GameObject> enemies;

    private void Start()
    {
        enemies = new List<GameObject>();
    }



    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Enemy")
            return;

        //Debug.Log("적이네");
        enemies.RemoveAll(item => item == null);
        enemies.Add(other.gameObject);
        towerController.targetEnermy = enemies[0];

        
    }

    public void OnTriggerExit(Collider other)
    {
        //Debug.Log("탈출");//2번나오네
        if (other.gameObject.tag != "Enemy")
            return;
        enemies.RemoveAll(item => item == null);
        enemies.Remove(other.gameObject);

    }
}
