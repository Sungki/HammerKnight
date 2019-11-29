using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : LevelBase
{
    private List<GameObject> objPrefab = new List<GameObject>();
    private List<Vector3> initPos = new List<Vector3>();

    private void Awake()
    {
        initPos.Add(new Vector3(-2.2f, 0, 0));
        initPos.Add(new Vector3(4.2f, 0, 0));
        initPos.Add(new Vector3(17.5f, 0, 0));
        initPos.Add(new Vector3(27.5f, 0, 0));
        initPos.Add(new Vector3(37.5f, 0, 0));
    }

    public override void SetPrefab(GameObject _player, GameObject _red, GameObject _blue)
    {
        objPrefab.Add(_player);
        objPrefab.Add(_red);
        objPrefab.Add(_blue);
        objPrefab.Add(_blue);
        objPrefab.Add(_blue);
    }

    public override void CreateLevel(List<Vector3> pos)
    {
        for (int i = 0; i < objPrefab.Count; i++)
        {
            Instantiate(objPrefab[i], pos[i], Quaternion.identity);
        }
    }

    public override void CreateLevel()
    {
        ToolBox.GetInstance().GetManager<GameManager>().player = Instantiate(objPrefab[0], initPos[0], Quaternion.identity);

        for (int i = 1; i < objPrefab.Count; i++)
        {
            Instantiate(objPrefab[i], initPos[i], Quaternion.identity);
        }
    }
}
