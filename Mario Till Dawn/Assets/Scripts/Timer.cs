using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining;
    public Text timerText;
    public GameObject objDestr;

    public static float elapsedTime = 0f;

    void Start()
    {
        if (!ModeScript.isBeginner)
        {
            timeRemaining = 1200f;
        }
        else
        {
            timeRemaining = 6f;
        }
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            elapsedTime += Time.deltaTime;

            int minutes = Mathf.FloorToInt(timeRemaining / 60f);
            int seconds = Mathf.FloorToInt(timeRemaining % 60f);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            timeRemaining = 0;
            timerText.text = "00:00";
            Destroy(objDestr);
        }
    }
}