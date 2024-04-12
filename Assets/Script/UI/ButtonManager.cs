using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public PlayerFeet playerFeet;
    public Canvas gameOver;
    public Canvas pause;
    public GameObject player;

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

        if(Input.GetKey(KeyCode.Escape) && pause.enabled == false)
        {
            pause.enabled = true;
            Time.timeScale = 0;
        }
    }

    public void RestartGame()
    {
        Destroy(player);
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void BackToMainMenu()
    {
        Destroy(player);
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void returnInGame()
    {
        pause.enabled = false;
        Time.timeScale = 1;
    }
    
}
