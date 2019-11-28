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
        player = Resources.Load<GameObject>("Player");
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

        textArray[0].text = transform.parent.GetComponentInChildren<StatManager>().GetPlayerHP();
        textArray[1].text = transform.parent.GetComponentInChildren<StatManager>().GetScore();
    }

    public void ShowSummary()
    {
        textArray[0].transform.position = new Vector2(Screen.width / 2 - 150, Screen.height - 500);
        textArray[1].transform.position = new Vector2(Screen.width / 2 + 300, Screen.height - 500);

        textArray[0].text = transform.parent.GetComponentInChildren<StatManager>().GetPlayerHP();
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

    private void Save()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("hp", transform.parent.GetComponentInChildren<StatManager>().playerHP);
        PlayerPrefs.SetInt("coins", transform.parent.GetComponentInChildren<StatManager>().coins);
        PlayerPrefs.SetInt("level", (int)transform.parent.GetComponentInChildren<LevelManager>().currentScreen);

        if(player.GetComponent<PlayerController>().inventory.items.Count != 0)
        {
            PlayerPrefs.SetString("armor", player.GetComponent<PlayerController>().inventory.myArmor.name);
            PlayerPrefs.SetString("hammer", player.GetComponent<PlayerController>().inventory.myHammer.name);

            PlayerPrefs.SetInt("invenCnt", player.GetComponent<PlayerController>().inventory.items.Count);
            for (int i = 0; i < player.GetComponent<PlayerController>().inventory.items.Count; i++)
            {
                PlayerPrefs.SetString("inven" + i.ToString(), player.GetComponent<PlayerController>().inventory.items[i].name);
            }
        }

        PlayerPrefs.Save();
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("hp"))
        {
            transform.parent.GetComponentInChildren<StatManager>().playerHP = PlayerPrefs.GetInt("hp");
            transform.parent.GetComponentInChildren<StatManager>().coins = PlayerPrefs.GetInt("coins");
            transform.parent.GetComponentInChildren<LevelManager>().currentScreen = (ScreenState)PlayerPrefs.GetInt("level");

            string name = PlayerPrefs.GetString("armor");
            player.GetComponent<PlayerController>().inventory.myArmor = (EquipmentItemObject)Resources.Load(name);
            name = PlayerPrefs.GetString("hammer");
            player.GetComponent<PlayerController>().inventory.myHammer = (EquipmentItemObject)Resources.Load(name);

            int cnt = PlayerPrefs.GetInt("invenCnt");
            for (int i = 0; i < cnt; i++)
            {
                name = PlayerPrefs.GetString("inven" + i.ToString());
                player.GetComponent<PlayerController>().inventory.items[i] = (EquipmentItemObject)Resources.Load(name);
            }
        }
    }

    private void OnGUI()
    {
        if (isPause)
        {
            GUI.Box(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 200, 300, 50), "Pause!!");

            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 100, 300, 100), "Do you want to Continue?"))
            {
                isPause = false;
                Time.timeScale = 1.0f;
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 50, 300, 100), "Do you want to Save?"))
            {
                Save();
                isPause = false;
                Time.timeScale = 1.0f;
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 200, 300, 100), "Do you want to Quit?"))
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
