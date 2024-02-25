using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneManager : MonoBehaviour
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
}