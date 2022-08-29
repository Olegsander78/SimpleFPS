using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int scoreToWin;
    public int curScore;

    public bool gamePaused;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        Time.timeScale = 1f;
    }
    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
            TogglePauseGame();
    }
    public void TogglePauseGame()
    {
        gamePaused = !gamePaused;
        Time.timeScale = gamePaused == true ? 0f : 1f;

        Cursor.lockState = gamePaused == true ? CursorLockMode.None : CursorLockMode.Locked;

        GameUI.instance.TogglePauseMenu(gamePaused);
    }
    public void AddScore(int score)
    {
        curScore += score;

        GameUI.instance.UpdateScoreText(curScore);

        if (curScore >= scoreToWin)
            WinGame();
    }
    public void WinGame()
    {
        GameUI.instance.SetEndGameScreen(true, curScore);

        Time.timeScale = 0f;
        gamePaused = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void LoseGame()
    {
        GameUI.instance.SetEndGameScreen(false, curScore);

        Time.timeScale = 0f;
        gamePaused = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
