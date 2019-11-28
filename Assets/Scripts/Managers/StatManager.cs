using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    private int playerLife = 3;
    private int playerCoin = 0;
    private bool allDied = false;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        playerLife = 3;
        playerCoin = 0;
        allDied = false;
    }

    public string GetPlayerLife()
    {
        return "Player: " + playerLife.ToString();
    }

    public string GetScore()
    {
        return "Score: " + playerCoin.ToString();
    }

    public void ReduceLife()
    {
        playerLife--;
        if (playerLife <= 0)
        {
            Destroy(transform.parent.GetComponentInChildren<GameManager>().player.gameObject);
            allDied = true;
        }
        else
        {
            transform.parent.GetComponentInChildren<GameManager>().RespawnPlayer();
        }
    }

    public void AddCoin()
    {
        playerCoin++;
    }

    private void OnGUI()
    {
        if (allDied)
        {
            GUI.Box(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 100, 300, 50), "All Dead!!");

            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2, 300, 100), "Do you want to Restart?"))
            {
                allDied = false;
                Init();
                transform.parent.GetComponentInChildren<LevelManager>().Init();
                transform.parent.GetComponentInChildren<LevelManager>().NextLevel();
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 150, 300, 100), "Do you want to end?"))
            {
                allDied = false;
                transform.parent.GetComponentInChildren<LevelManager>().GotoScreen("EndScreen");
                transform.parent.GetComponentInChildren<GameManager>().ShowSummary();
            }
        }
    }
}
