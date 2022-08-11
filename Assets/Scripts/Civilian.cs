using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Civilian : BaseController, ILifeReduce
{
    void Start()
    {
        
    }
    
    protected override void Move()
    {
        transform.Translate(speed * Time.deltaTime * new Vector3(0, -1f, 0));
        DestroyOnDefenceLine();
    }

    protected override void ActionOnClick()
    {
        //ReduceLife(GameObject.Find("GameSetting").GetComponent<GameSetting>().HP);
    }


    public void ReduceLife(int i)
    {
        GameObject.Find("GameSetting").GetComponent<GameSetting>().HP -= i;
    }

    private void OnDestroy()
    {
        if (transform.position.y>-Camera.main.orthographicSize)
        ReduceLife(GameObject.Find("GameSetting").GetComponent<GameSetting>().HP);
    }
}
