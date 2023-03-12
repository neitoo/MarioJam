using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerText : MonoBehaviour
{
    public string message = "|Внимание|\nКанализация откроется после истечения времени";
    public float displayTime = 7.0f;
    public Text messageText;
    public AudioSource audioSource;

    private bool playerInTrigger = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true;
            audioSource.Play();
            StartCoroutine(DisplayMessage());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;
            messageText.text = "";
            StopAllCoroutines();
        }
    }

    IEnumerator DisplayMessage()
    {
        messageText.text = message;
        yield return new WaitForSeconds(displayTime);
        if (playerInTrigger)
        {
            messageText.text = "";
        }
    }
}
