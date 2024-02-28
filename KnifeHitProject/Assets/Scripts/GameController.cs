using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(GameUI))]

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }
    [SerializeField] private int shipCount;
    [SerializeField] private Vector2 shipSpawnPosition;
    [SerializeField] private GameObject shipObject;
    public GameUI GameUI { get; private set; }

    private void Awake()
    {
        Instance = this;

        GameUI = GetComponent<GameUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        GameUI.SetInitialDisplayedKnifeCount(shipCount);
        SpawnShip();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnShip()
    {
        shipCount--;
        Instantiate(shipObject, shipSpawnPosition, Quaternion.identity/*Euler(0, -90, 0)*/); //solucionar rotacion -90 para la nave
    }

    public void OnSuccessfulKnifeHit()
    {
        if (shipCount > 0)
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
