using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public List<Transform> targetPos;
    public Transform curTargetPos;
    public CharacterController characterController;
    public float moveSeppd = 1f;
    public float rotationSpeed = 10f;
    public int enemyHp = 100;
    private bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            targetPos.Add(GameObject.Find($"Node ({i})").transform);
        }
    }

    // Update is called once per frame
    void Update()
    {   
        if(!isDead) {  
        curTargetPos = targetPos[0];
        float distance = Vector3.Distance(transform.position, curTargetPos.position);
        //Debug.Log(distance);
        Vector3 dir = curTargetPos.position - transform.position;
        dir.y = 0;
        dir.Normalize();
        characterController.SimpleMove(dir * moveSeppd);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), rotationSpeed * Time.deltaTime);
        //transform.LookAt(curTargetPos.position+new Vector3(0,transform.position.y,0));
        //회전해야 하는데
        if(distance < 0.8f)
        {

            targetPos.RemoveAt(0);
        }
        }

    }
}
