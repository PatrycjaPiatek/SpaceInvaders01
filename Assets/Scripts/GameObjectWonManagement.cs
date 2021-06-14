using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameObjectWonManagement : MonoBehaviour
{    
    public void BackToMAinMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
        GameState.score = 0;
        GameState.nOAliensWAD = 0;
        //gra = true;
    }
    public void RetryGame()
    {
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1;
        GameState.score = 0;
        GameState.nOAliensWAD = 0;
        //gra = true;
    }
        
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    //public void PauseGame()
    //{
    //    Time.timeScale = 0;
    //    GameState.SoundOn = false;
    //}
    //public void PlayGame()
    //{
    //    Time.timeScale = 1;
    //    GameState.SoundOn = true;
    //}
}
