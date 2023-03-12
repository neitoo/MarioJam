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
    public int damage;
    public float timeRemaining = 20 * 60;
    public AudioSource audioSource;

    void Start()
    {
        hpt.text = "Hp " + hp.ToString();
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
            // 
            PlayerPrefs.SetFloat("RemainingTime", FindObjectOfType<Timer>().elapsedTime);
            PlayerPrefs.SetInt("RemainingHp", hp /* score */);

            SceneManager.LoadScene("GameOver");

            // 
            Timer timer = FindObjectOfType<Timer>();
            timer.enabled = false;
        }

    }
}
