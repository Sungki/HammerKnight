using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Vector3 respawnPosition = Vector3.zero;
    [HideInInspector] public GameObject player;
    private Text[] textArray;
    private GameObject myCanvas;
    private bool isPause = false;

    private void Awake()
    {
        player = GameObject.Find("Player");
        myCanvas = GameObject.Find("Canvas");
        textArray = myCanvas.GetComponentsInChildren<Text>();
        DontDestroyOnLoad(myCanvas);
    }

    public void SetRespawnPos(Vector3 pos)
    {
        respawnPosition = pos;
    }

    public void RespawnPlayer()
    {
        if (!player) player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = respawnPosition;
    }

    public void ShowHUD()
    {
        textArray[0].transform.position = new Vector2(Screen.width / 2 - 150, Screen.height - 150);
        textArray[1].transform.position = new Vector2(Screen.width / 2 + 300, Screen.height - 150);

        textArray[0].text = transform.parent.GetComponentInChildren<StatManager>().GetPlayerLife();
        textArray[1].text = transform.parent.GetComponentInChildren<StatManager>().GetScore();
    }

    public void ShowSummary()
    {
        textArray[0].transform.position = new Vector2(Screen.width / 2 - 150, Screen.height - 500);
        textArray[1].transform.position = new Vector2(Screen.width / 2 + 300, Screen.height - 500);

        textArray[0].text = transform.parent.GetComponentInChildren<StatManager>().GetPlayerLife();
        textArray[1].text = transform.parent.GetComponentInChildren<StatManager>().GetScore();
    }

    public void InitText()
    {
        textArray[0].text = null;
        textArray[1].text = null;
    }

    private void Update()
    {
        if (Input.GetKey("escape") && transform.parent.GetComponentInChildren<LevelManager>().IsLevelScene())
        {
            isPause = true;
            Time.timeScale = 0.0f;
        }
    }

    private void OnGUI()
    {
        if (isPause)
        {
            GUI.Box(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 100, 300, 50), "Pause!!");

            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2, 300, 100), "Do you want to continue?"))
            {
                isPause = false;
                Time.timeScale = 1.0f;
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 150, 300, 100), "Do you want to quit?"))
            {
                isPause = false;
                Time.timeScale = 1.0f;
                InitText();
                transform.parent.GetComponentInChildren<StatManager>().Init();
                transform.parent.GetComponentInChildren<LevelManager>().Init();
                transform.parent.GetComponentInChildren<LevelManager>().CurrentScreen();
            }
        }
    }
}
