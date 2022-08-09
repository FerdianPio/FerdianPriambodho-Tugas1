using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "enemy")
        {
            GameObject.Find("GameSetting").GetComponent<GameSetting>().HP -= 1;
        }
    }
}
