using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject traps;
    public bool notOpenCheck;
    public GameObject notOpen;
    public Player playerObject;
    public GameObject Player;
    public GameObject gameOver;
    public void Trap()
    {
        Time.timeScale = 0f;
        Player.SetActive(false);
        gameOver.SetActive(true);
    }

    public void Update()
    {
        if (playerObject.keyCount == 18)
        {
           traps.SetActive(false);
        }
    }
    public void Retry()
    {
        SceneManager.LoadScene("Room1");
        
    }
    
    public void Yes()
    {
        if(playerObject.keyCount == 1)
        {
            SceneManager.LoadScene(1);
            
        }
        else if(playerObject.keyCount == 18)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            notOpen.SetActive(true);
            notOpenCheck = true;
            playerObject.exitText.SetActive(false);

        }
    }
    public void No()
    {
        playerObject.exitText.SetActive(false);
    }
}
