using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKey("escape")) Application.Quit();
            ToolBox.GetInstance().GetManager<LevelManager>().NextLevel();
            ToolBox.GetInstance().GetManager<GameManager>().InitText();
        }
    }
}
