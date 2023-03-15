using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public Text timeText;
    public float saveTime = 0f;
    void Awake()
    {
        saveTime = PlayerPrefs.GetFloat("RemainingTime");
    }
    void Start()
    {
        float saveTime = PlayerPrefs.GetFloat("RemainingTime");
        int minutes = Mathf.FloorToInt(saveTime / 60f);
        int seconds = Mathf.FloorToInt(saveTime % 60f);
        timeText.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);
    }

    public void Restart()
    {
        PlayerPrefs.SetFloat("RemainingTime", 0f);
        SceneManager.LoadScene("MainScene");
    }
    public void ExitGame(){
        Application.Quit();
    }
}
