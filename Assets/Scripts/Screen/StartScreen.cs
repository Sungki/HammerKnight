using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    private bool mainMenu = false;
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKey("escape")) Application.Quit();
            mainMenu = true;
        }
    }

    private void OnGUI()
    {
        if (mainMenu)
        {
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
