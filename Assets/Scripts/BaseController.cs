using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseController : MonoBehaviour, ITapable
{
    [SerializeField] protected int speed = 1;
    protected abstract void Move();
    protected virtual void ActionOnClick() { }

    protected virtual void Update()
    {
        Move();
        if (Input.GetMouseButton(0))
        {
            HitByRaycast();
        }
    }

    protected virtual void DestroyOnDefenceLine()
    {
        if (transform.position.y <= -Camera.main.orthographicSize)
        {
            Destroy(gameObject);
        }
    }

    public virtual void HitByRaycast()
    {

        // Cast a ray straight down.
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1f);
        // If it hits something...
        if (hit.collider != null)
        {
            if (Time.timeScale == 0)
            {
                return;
            }
            Destroy(hit.collider.gameObject); // ASK : Why is it work while only "gameObject" doesn't
            ActionOnClick();
        }
    }

}
