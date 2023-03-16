using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDHpBar : MonoBehaviour
{
    public Transform target;
    public RectTransform canvas;
    public RectTransform hpBar;
    public Camera mainCam;
    public GameObject hpBarPrefab;
    public GameObject hpObj;
    public int maxHp;
    // Start is called before the first frame update
    void Start()
    {
        maxHp = transform.parent.GetComponent<EnemyController>().enemyHp;
        hpObj = Instantiate(hpBarPrefab);
        target = gameObject.transform;
        canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
        hpObj.transform.SetParent(canvas);
        hpBar = hpObj.GetComponent<RectTransform>();
        hpBar.localScale = Vector3.one;
        hpBar.localRotation = Quaternion.Euler(0,0,0);
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 curPos = target.transform.position;
        Vector2 screenPoint = Camera.main.WorldToScreenPoint(curPos);
        Vector2 canvasPos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas,screenPoint, mainCam,out canvasPos);

        if(hpBar != null)
        {

                hpBar.localPosition = canvasPos;
                hpBar.GetComponent<Slider>().value = (float)transform.parent.GetComponent<EnemyController>().enemyHp / maxHp;

           
        }
    }

    public void DestoryHpBar()
    {
        Destroy(hpBar.gameObject);
    }
}
