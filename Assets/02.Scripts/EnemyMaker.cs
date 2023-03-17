using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaker : MonoBehaviour
{
    public GameObject enermyPrefab;
    public float curTime;
    public float coolTime = 1f;
    public int enemyCnt = 0;
    public int enemyMaxCnt = 10;
    public bool isRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        isRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            curTime += Time.deltaTime;
            if(curTime > coolTime)
            {
                curTime = 0;
                GameObject enemy = Instantiate(enermyPrefab, transform.position + new Vector3(0, 1f, 0),Quaternion.identity);
                enemy.transform.position = transform.position+new Vector3(0,1f,0);
                enemy.name = "Enemy_" + enemyCnt;
                enemyCnt++;
                if(enemyMaxCnt < enemyCnt)
                {
                    isRunning=false;
                }
            }
        }
    }

    //  Damage �Լ� ����  Dead �� false ��   �������� �ް�  ������ 0���� �۰ų� ������ Dead �� true

}
