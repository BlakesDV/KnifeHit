using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject panelShip;
    [SerializeField] private GameObject shipPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowRestartButton()
    {
        restartButton.SetActive(true);
    }

    public void SetInitialDisplayedKnifeCount(int count)
    {
        for (int i = 0; i < count; i++)
            Instantiate(shipPrefab, panelShip.transform);
    }
    private int knifeIconIndexToChange = 0;
    public void DecrementDisplayedKnifeCount()
    {
        panelShip.transform.GetChild(knifeIconIndexToChange++);
    }
}
