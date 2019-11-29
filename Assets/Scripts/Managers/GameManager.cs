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
    private bool isInventory = false;

    [HideInInspector] public bool pressLoad = false;

    private void Awake()
    {
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
        textArray[0].transform.position = new Vector2(Screen.width / 2 - 250, Screen.height - 50);
        textArray[1].transform.position = new Vector2(Screen.width / 2 + 400, Screen.height - 50);

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
        if (Input.GetKeyDown("escape") && transform.parent.GetComponentInChildren<LevelManager>().IsLevelScene())
        {
            isPause = true;
            Time.timeScale = 0.0f;
        }

        if (Input.GetKeyDown("escape") && isInventory)
        {
            isPause = false;
            isInventory = false;
            Time.timeScale = 1.0f;
        }
    }

    private void Save()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetFloat("hp", transform.parent.GetComponentInChildren<StatManager>().playerHP);
        PlayerPrefs.SetInt("coins", transform.parent.GetComponentInChildren<StatManager>().coins);
        PlayerPrefs.SetInt("level", (int)transform.parent.GetComponentInChildren<LevelManager>().currentScreen);

        if(player.GetComponent<PlayerController>().inventory.items.Count != 0)
        {
            if(player.GetComponent<PlayerController>().inventory.myArmor != null)
                PlayerPrefs.SetString("armor", player.GetComponent<PlayerController>().inventory.myArmor.name);

            if (player.GetComponent<PlayerController>().inventory.myHammer != null)
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
        pressLoad = true;

        if (PlayerPrefs.HasKey("hp"))
        {
            transform.parent.GetComponentInChildren<StatManager>().playerHP = PlayerPrefs.GetFloat("hp");
            transform.parent.GetComponentInChildren<StatManager>().coins = PlayerPrefs.GetInt("coins");
            transform.parent.GetComponentInChildren<LevelManager>().currentScreen = (ScreenState)PlayerPrefs.GetInt("level");
        }
    }

    private void OnGUI()
    {
        if (isPause)
        {
            if (isInventory)
            {
                int itemCount = player.GetComponent<PlayerController>().inventory.items.Count;
                int x = 0;
                int y = 0;

                for (int i =0; i< itemCount; i++)
                {
                    if (GUI.Button(new Rect(x * 102, y*102, 100, 100), player.GetComponent<PlayerController>().inventory.items[i].name))
                    {
                        if (Event.current.button == 0)
                        {
                            if(player.GetComponent<PlayerController>().inventory.items[i].name.Contains("Hammer"))
                            {
                                isPause = false;
                                isInventory = false;
                                Time.timeScale = 1.0f;
                                player.GetComponent<PlayerController>().HammerEquip(player.GetComponent<PlayerController>().inventory.items[i]);
                            }
                            else
                            {
                                isPause = false;
                                isInventory = false;
                                Time.timeScale = 1.0f;
                                player.GetComponent<PlayerController>().ArmorEquip(player.GetComponent<PlayerController>().inventory.items[i]);
                            }
                        }
                    }
                    x++;
                    if(x>=10)
                    {
                        y++;
                        x = 0;
                    }
                }
            }
            else
            {
                GUI.Box(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 200, 300, 50), "Pause!!");

                if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 100, 300, 100), "Do you want to Equip?"))
                {
                    isInventory = true;
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
}
