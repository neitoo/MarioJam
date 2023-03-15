using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class HP : MonoBehaviour
{
    public int hp;
    public Text hpt;
    public Text timeText;
    public GameObject deadMenu;
    public int damage;
    private Timer timer;
    public AudioSource audioSource;

    void Start()
    {
        timer = FindObjectOfType<Timer>();
        hpt.text = "Hp " + hp.ToString();
        Time.timeScale = 1f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            audioSource.Play();
            hp = hp - damage;
            hpt.text = "Hp " + hp.ToString();
        }
    }
    void Update()
    {
        if (hp <= 0)
        {
            Time.timeScale = 0f;
            deadMenu.SetActive(true);
            timer.enabled = false;
            float saveTime = timer.elapsedTime;
            int minutes = Mathf.FloorToInt(saveTime / 60f);
            int seconds = Mathf.FloorToInt(saveTime % 60f);
            timeText.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);
            
        }

    }
}
