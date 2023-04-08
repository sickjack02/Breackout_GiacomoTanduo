using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text score;

    public List<GameObject> lifes = new List<GameObject>();

    public GameObject GameOverPannel;
    public GameObject StartGamePannel;
    public GameObject PauseGamePannel;

    private void Start()
    {
        /*
        GameOverPannel.SetActive(false);
        PauseGamePannel.SetActive(false);
        */

        HideGameOver();
        HidePauseGamePannel();
        ShowStartGamePannel();
    }
    public void UpdateScore(int value)
    {
        score.text = value.ToString();
    }

    public void UpdateLives (int value)
    {
        for (int i = lifes.Count -1; i >=0; i--)
        {
            lifes[i].SetActive(value >= i);
        }
    }

    public void ShowGameOver()
    {
        GameOverPannel.SetActive(true);
    }

    public void HideGameOver()
    {
        GameOverPannel.SetActive(false);
    }

    public void ShowStartGamePannel()
    {
        StartGamePannel.SetActive(true);
    }

    public void HideStartGamePannel()
    {
        StartGamePannel.SetActive(false);
    }

    public void ShowPauseGamePannel()
    {
        PauseGamePannel.SetActive(true);
    }

    public void HidePauseGamePannel()
    {
        PauseGamePannel.SetActive(false);
    }
}
