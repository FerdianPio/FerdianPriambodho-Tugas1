using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D Rb;

    public int speed;
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -1f, 0) * speed * Time.deltaTime);
        
        /*if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                Debug.Log(hit.transform.gameObject.name);
                Debug.Log(Input.mousePosition);
            }
        }*/
    }

    private void OnMouseDown()
    {
        if(Time.timeScale == 0){
            return;
        }
        Destroy(this.gameObject);
        if (gameObject.tag == "enemy")
        {
            GameObject.Find("GameSetting").GetComponent<GameSetting>().point += 1;
        } else if (gameObject.tag == "civilian")
        {
            GameObject.Find("GameSetting").GetComponent<GameSetting>().HP = 0;
        }
    }
}
