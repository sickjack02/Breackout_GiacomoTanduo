using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int score = 0;

    public int lives = 3;

    public int initialLives = 3;

    public UIController UIController;
    public AudioController AudioController;
    public BlockController BlockController;

    public Ball Ball;
    public Paddle Paddle;

    public Vector3 ballResetPos;
    public Vector3 paddleResetPos;

    public GameObject ExplosionPrefab;

    private bool isPlaying = false;
    public bool IsPlaying { get { return isPlaying; } }
    private bool isPaused = false;
    public bool IsPaused { get { return isPaused; } }

    public void Start()
    {
        UIController.UpdateScore(score);
        UIController.UpdateLives(lives);
        PauseGame();
    }

    private void Update()
    {
        /*if (!isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
        else if (isPaused && Input.anyKeyDown)
        {
            UnpauseGame();
        }*/
    }

    public void UnpauseGame()
    {
        isPaused = false;
        Time.timeScale = 1;
        UIController.HidePauseGamePannel();
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;
        if (isPlaying)
        {
            UIController.ShowPauseGamePannel();
        }
    }

    public void AddScore(int value)
    {
        score += value;
        UIController.UpdateScore(score);
    }

    public void BallLost()
    {
        Ball.transform.position = ballResetPos;

        Vector3 currentVelocity = Ball.velocity;
        currentVelocity.y = Mathf.Abs(currentVelocity.y);
        Ball.velocity = currentVelocity;

        lives--;
        UIController.UpdateLives(lives);
        if (lives < 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        UIController.ShowGameOver();
        isPlaying = false;
        PauseGame();
    }

    public void StartGame()
    {
        isPlaying = true;
        ResetGame();
        UnpauseGame();
    }

    public void ResetGame()
    {
        lives = initialLives;
        score = 0;
        Ball.transform.position = ballResetPos;
        Paddle.transform.position = paddleResetPos;
        UIController.UpdateScore(score);
        UIController.UpdateLives(lives);
        UIController.HideStartGamePannel();
        UIController.HideGameOver();
        BlockController.ResetBlocks();
    }

    public void QuitGame()
    {
        isPlaying = false;
        PauseGame();
        UIController.HideGameOver();
        UIController.HidePauseGamePannel();
        UIController.ShowStartGamePannel();

        Ball.transform.position = ballResetPos;
        Paddle.transform.position = paddleResetPos;
    }
}
