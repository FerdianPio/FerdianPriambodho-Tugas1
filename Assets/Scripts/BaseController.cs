using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseController : MonoBehaviour
{
    [SerializeField] protected int speed = 1;
    protected abstract void Move();

    protected virtual void DestroyOnDefenceLine()
    {
        if (transform.position.y <= -Camera.main.orthographicSize)
        {
            Destroy(gameObject);
        }
    }

    protected void OnMouseDown()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        Destroy(gameObject);
    }
}
