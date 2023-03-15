using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuildingMgr : MonoBehaviour
{
    public GameObject towerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                //Debug.Log($"¸ÂÀº³ð transform :::{hit.collider.gameObject.transform.position}");

                switch(hit.collider.gameObject.tag)
                {
                    case "Block":
                        GameObject tower = Instantiate(towerPrefab);
                        tower.transform.position = hit.transform.position+ new Vector3(0,hit.collider.transform.localScale.y,0);
                        break;
                    case "Block_None":
                        break;
                    case "Tower":
                        Debug.Log("Å¸¿ö°¡ ¼±ÅÃ µÊ");
                        break;

                }
            }
        }
    }
}
