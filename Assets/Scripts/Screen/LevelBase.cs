using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelBase : MonoBehaviour
{
    public abstract void SetPrefab(GameObject _red, GameObject _blue, GameObject _player);
    public abstract void CreateLevel();
    public abstract void CreateLevel(List<Vector3> pos);

}
