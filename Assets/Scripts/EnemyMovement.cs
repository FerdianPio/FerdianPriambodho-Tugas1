using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public int speed;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(new Vector3(0, -1f, 0) * speed * Time.deltaTime);
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
