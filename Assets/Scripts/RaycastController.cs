using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour
{
    public LayerMask InteractableObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            HitByRaycast();
        }
    }
    public void HitByRaycast()
    {

        // Cast a ray straight down.
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1f, InteractableObject);
        // If it hits something...
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject.name);
            if (Time.timeScale == 0)
            {
                return;
            }
            //Destroy(hit.collider.gameObject);
            //ActionOnClick();
        }
    }
}
