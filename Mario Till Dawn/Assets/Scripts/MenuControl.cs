using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{


    public void PlayGameEasy()
    {
        ModeScript.isBeginner = true;
        SceneManager.LoadScene("MainScene");
    }

    public void PlayGameHard()
    {
        ModeScript.isBeginner = false;
        SceneManager.LoadScene("MainScene");
    }

    public void ExitGame(){
        Application.Quit();
    }
}
