using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Text timeText;
    public void Start()
    {
        // Получить сохраненное время
        float remainingTime = PlayerPrefs.GetFloat("RemainingTime");

        // Отобразить время на экране
        int minutes = Mathf.FloorToInt(remainingTime / 60f);
        int seconds = Mathf.FloorToInt(remainingTime % 60f);
        timeText.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);
    }
}
