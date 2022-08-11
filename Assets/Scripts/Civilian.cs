using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Civilian : BaseController, ILifeReduce
{
    void Start()
    {
        
    }
    void Update()
    {
        Move();   
    }
    protected override void Move()
    {
        transform.Translate(speed * Time.deltaTime * new Vector3(0, -1f, 0));
        DestroyOnDefenceLine();
    }

    public override void OnMouseDown()
    {
        base.OnMouseDown();
        ReduceLife(GameObject.Find("GameSetting").GetComponent<GameSetting>().HP);
    }


    public void ReduceLife(int i)
    {
        GameObject.Find("GameSetting").GetComponent<GameSetting>().HP -= i;
    }
}