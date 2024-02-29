using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(GameUI))]

public class GameController : MonoBehaviour
{
    public ScriptablesObjects patron;
    private bool spawnedShip = false;

    public static GameController Instance { get; private set; }
    [SerializeField] private Vector2 shipSpawnPosition;
    [SerializeField] private GameObject shipObject;
    public GameUI GameUI { get; private set; }

    private void Awake()
    {
        Instance = this;

        GameUI = GetComponent<GameUI>();
    }

    void Update()
    {
        /*Bool-Revisar si está spawneado para detener el spawn de más naves*/
        
        if (patron != null)
        {
            GameUI.SetInitialDisplayedKnifeCount(patron.shipCount);
            if (!spawnedShip)
            {
                // Lógica para spawnear la nave
                SpawnShip();

                // Marcar que la nave ha sido spawneda
                spawnedShip = true;
            }
        }
    }

    private void SpawnShip()
    {   
        if(patron.shipCount > 0 )
        {
            patron.shipCount--;
            Instantiate(shipObject, shipSpawnPosition, Quaternion.Euler(0, 0, -90)); //solucionar rotacion -90 para la nave
        }
        /*else que le llame a random gen y repita el start (hacer una funcion caon las lineas de start q la llame el start y se pueda llamar aca)*/
    }

    public void OnSuccessfulKnifeHit()
    {
        if (patron.shipCount > 0)
        {
            SpawnShip();
        }
        else
        {
            
            StartGameOverSequence(true);
        }
    }

    public void StartGameOverSequence(bool win)
    {
        StartCoroutine("GameOverSequenceCoroutine", win);
    }

    private IEnumerator GameOverSequenceCoroutine(bool win)
    {
        if (win)
        {
            /*hacer panel de win*/
            yield return new WaitForSecondsRealtime(0.3f);
            //RestartGame();
        }
        else
        {
            GameUI.ShowRestartButton();
        }
    }

    public void RestartGame()
    {
        //restart the scene by reloading the currently active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}
