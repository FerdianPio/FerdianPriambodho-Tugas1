using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSetting : MonoBehaviour
{
    public int HP;
    public int point;
    public int wave;
    public GameObject HPText, pointText, waveText, 
        gameOverPanel, finalScoreText;

    void Start()
    {
        wave = 1;
        Time.timeScale = 1;
    }

    void Update()
    {
        HPText.GetComponent<Text>().text = "HP: " + HP;
        pointText.GetComponent<Text>().text = "Point: " + point;
        waveText.GetComponent<Text>().text = "Wave " + wave;

        if (HP <= 0)
        {
            finalScoreText.GetComponent<Text>().text = point.ToString();
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
