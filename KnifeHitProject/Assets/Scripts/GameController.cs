using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(GameUI))]

public class GameController : MonoBehaviour
{
    public ScriptablesObjects patron;

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
        //Bool-Revisar si está spawneado para detener el spawn de más naves
        if (patron != null)
        {
            GameUI.SetInitialDisplayedKnifeCount(patron.shipCount);
            SpawnShip();
        }
    }

    private void SpawnShip()
    {
        patron.shipCount--;
        Instantiate(shipObject, shipSpawnPosition, Quaternion.Euler(0, 0, -90)); //solucionar rotacion -90 para la nave
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
            //hacer panel de win
            yield return new WaitForSecondsRealtime(0.3f);
            RestartGame();
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
