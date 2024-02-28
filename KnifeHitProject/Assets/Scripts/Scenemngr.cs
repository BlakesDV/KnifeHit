using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Scenemngr : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0; //pausa el juego incluyendo las animaciones
    }

    public void ClosePanel()
    {
        GetComponent<Animator>().SetTrigger("SceneChange");
    }
    
    public void SetTimePlay()
    {
        Time.timeScale = 1;
    }
    public void OpenCredits()
    {
        GetComponent<Animator>().SetTrigger("CreditsScene");
    }
    public void ExitCreditsScene()
    {
        GetComponent<Animator>().SetTrigger("ExitCreditsScene");
    }
    public void ExitGame()
    {
        Application.Quit();
        print("exit");
    }
}
