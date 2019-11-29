using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    private void Start()
    {
        ToolBox.GetInstance().GetManager<GameManager>().ShowSummary();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToolBox.GetInstance().GetManager<GameManager>().InitText();
            ToolBox.GetInstance().GetManager<StatManager>().Init();
            ToolBox.GetInstance().GetManager<LevelManager>().Init();
            ToolBox.GetInstance().GetManager<LevelManager>().CurrentScreen();
        }
    }
}
