using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : BaseController, ILifeReduce, IPointMaker
{
    [SerializeField] private int point;
    [SerializeField] private int dammage;
    void Start()
    {

    }

    protected override void Move()
    {
        transform.Translate(speed * Time.deltaTime * new Vector3(0, -1f, 0));
        DestroyOnDefenceLine();
    }

    protected override void DestroyOnDefenceLine()
    {
        if (transform.position.y <= -Camera.main.orthographicSize)
        {
            Destroy(gameObject);
            ReduceLife(dammage);
        }
    }

    public void AddPoint(int i)
    {
        GameObject.Find("GameSetting").GetComponent<GameSetting>().point += i;
    }

    public void ReduceLife(int i)
    {
        GameObject.Find("GameSetting").GetComponent<GameSetting>().HP -= i;
    }

    protected virtual void OnDestroy()
    {
        if (transform.position.y > -Camera.main.orthographicSize)
            AddPoint(point);
    }
}
