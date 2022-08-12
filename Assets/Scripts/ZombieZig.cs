using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieZig : Enemy
{
    [SerializeField] private float timeToZig;
    [SerializeField] private float zigTime;
    private float x=0;

    public float maxZigSpeed;
    public float timeOnDirection;

    void Start()
    {
        StartCoroutine(ZigZag(timeToZig, zigTime));
    }

    protected override void Move()
    {
        FlipDirection();
        transform.Translate(speed * Time.deltaTime * new Vector3(x, -1f, 0));
        DestroyOnDefenceLine();
    }

    IEnumerator ZigZag(float timeStraight, float timeZig)
    {
        yield return new WaitForSeconds(timeStraight);
        for(int i = 0; i < timeZig; i++)
        {
            x = Random.Range(-maxZigSpeed, maxZigSpeed);
            yield return new WaitForSeconds(timeOnDirection);
        }
        x = 0;
    }

    protected void FlipDirection()
    {
        if(transform.position.x<=-Camera.main.orthographicSize*Camera.main.aspect || transform.position.x >= Camera.main.orthographicSize * Camera.main.aspect)
        {
            x = -x;
        }
    }
}
