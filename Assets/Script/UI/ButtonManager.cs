using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public PlayerFeet playerFeet;
    public Canvas gameOver;

    private void Start()
    {
        gameOver.enabled = false; //a faire ailleurs dans un mannger de canvas
    }
    public void Update()
    {
        if (playerFeet.isDead)
        {
            Debug.Log("is dead");
            gameOver.enabled = true;
            Time.timeScale = 0;

        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    
}
