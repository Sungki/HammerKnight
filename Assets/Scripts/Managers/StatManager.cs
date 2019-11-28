using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public int playerHP = 10;
    public int coins = 0; 
    private bool died = false;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        playerHP = 10;
        coins = 0;
        died = false;
    }

    public string GetPlayerHP()
    {
        return "Player HP: " + playerHP.ToString();
    }

    public string GetScore()
    {
        return "Coin score: " + coins.ToString();
    }

    public void ReduceHP(int ap)
    {
        playerHP -= ap;
        if (playerHP <= 0)
        {
            Destroy(transform.parent.GetComponentInChildren<GameManager>().player.gameObject);
            died = true;
        }
    }

    public void AddCoin()
    {
        coins++;
    }

    private void OnGUI()
    {
        if (died)
        {
            GUI.Box(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 100, 300, 50), "You Died!!");

            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2, 300, 100), "Do you want to Restart?"))
            {
                died = false;
                Init();
                transform.parent.GetComponentInChildren<LevelManager>().Init();
                transform.parent.GetComponentInChildren<LevelManager>().NextLevel();
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 150, 300, 100), "Do you want to end?"))
            {
                died = false;
                transform.parent.GetComponentInChildren<LevelManager>().GotoScreen("EndScreen");
                transform.parent.GetComponentInChildren<GameManager>().ShowSummary();
            }
        }
    }
}
