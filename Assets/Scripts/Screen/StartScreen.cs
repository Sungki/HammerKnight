using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    private bool mainMenu = false;
    GUIStyle style = new GUIStyle();
    Texture2D texture;

    private void Start()
    {
        texture = new Texture2D(Screen.width, Screen.height);
        for (int y = 0; y < texture.height; ++y)
        {
            for (int x = 0; x < texture.width; ++x)
            {
                texture.SetPixel(x, y, Color.gray);
            }
        }
        texture.Apply();
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKey("escape"))
            {
                mainMenu = false;
                Application.Quit();
            }
            else
            {
                mainMenu = true;
                ToolBox.GetInstance().GetManager<GameManager>().InitText();
            }
        }
    }

    private void OnGUI()
    {
        if (mainMenu)
        {
            style.normal.background = texture;
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), new GUIContent(""), style);

            ToolBox.GetInstance().GetManager<GameManager>().InitText();
            GUI.Box(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 200, 300, 50), "Main Menu");

            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 100, 300, 100), "Play"))
            {
                mainMenu = false;
                ToolBox.GetInstance().GetManager<LevelManager>().NextLevel();
                ToolBox.GetInstance().GetManager<GameManager>().InitText();
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 50, 300, 100), "Load"))
            {
                mainMenu = false;
                ToolBox.GetInstance().GetManager<GameManager>().Load();
                ToolBox.GetInstance().GetManager<GameManager>().InitText();
                ToolBox.GetInstance().GetManager<LevelManager>().CurrentScreen();
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 + 200, 300, 100), "Exit"))
            {
                mainMenu = false;
                Application.Quit();
            }
        }
    }
}
