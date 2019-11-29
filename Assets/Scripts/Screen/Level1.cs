﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : LevelBase
{
    private List<GameObject> objPrefab = new List<GameObject>();
    private List<Vector3> initPos = new List<Vector3>();

    private void Awake()
    {
        initPos.Add(new Vector3(-2.2f, 0, 0));
        initPos.Add(new Vector3(4.5f, 0, 0));
        initPos.Add(new Vector3(8.5f, 0, 0));
        initPos.Add(new Vector3(10.5f, 0, 0));
        initPos.Add(new Vector3(12.5f, 0, 0));
        initPos.Add(new Vector3(15.5f, 0, 0));
    }

    public override void SetPrefab(GameObject _player, GameObject _red, GameObject _blue)
    {
        objPrefab.Add(_player);
        objPrefab.Add(_red);
        objPrefab.Add(_blue);
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
        for (int i = 0; i < objPrefab.Count; i++)
        {
            Instantiate(objPrefab[i], initPos[i], Quaternion.identity);
        }
    }
}
