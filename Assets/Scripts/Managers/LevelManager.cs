using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public ScreenState currentScreen = 0;
    Stack<GameObject> sceneStack = new Stack<GameObject>();

    GameObject redGuyPrefab;
    GameObject blueGuyPrefab;
    GameObject greenGuyPrefab;
    GameObject playerPrefab;

    public bool IsLevelScene()
    {
        if (currentScreen == ScreenState.StartScreen || currentScreen == ScreenState.EndScreen)
            return false;
        else
            return true;
    }

    private void Awake()
    {
        greenGuyPrefab = Resources.Load<GameObject>("GreenGuy");
        redGuyPrefab = Resources.Load<GameObject>("RedGuy");
        blueGuyPrefab = Resources.Load<GameObject>("BlueGuy");
        playerPrefab = Resources.Load<GameObject>("Player");

        Init();
    }

    public void Init()
    {
        currentScreen = ScreenState.StartScreen;
    }

    public void NextLevel()
    {
        if (currentScreen == ScreenState.EndScreen) Init();
        else
        {
            currentScreen++;
        }

        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation op = SceneManager.LoadSceneAsync(currentScreen.ToString());
        while (!op.isDone)
        {
            yield return null;
        }

        switch (currentScreen)
        {
            case ScreenState.Level1:
                CreateLevel<Level1>();
                break;
            case ScreenState.Level2:
                CreateLevel<Level2>();
                break;
            case ScreenState.Level3:
                CreateLevel<Level3>();
                break;
            default:
                break;
        }

        if (ToolBox.GetInstance().GetManager<GameManager>().pressLoad)
        {
            ToolBox.GetInstance().GetManager<GameManager>().pressLoad = false;
            Load();
        }
    }

    private void CreateLevel<T>() where T : LevelBase
    {
        var go = new GameObject(typeof(T).ToString());
        PushScene(go);

        sceneStack.Peek().transform.parent = this.gameObject.transform;
        sceneStack.Peek().AddComponent<T>().SetPrefab(playerPrefab, redGuyPrefab, blueGuyPrefab, greenGuyPrefab);
        sceneStack.Peek().GetComponent<T>().CreateLevel();
    }

    private void PushScene(GameObject go)
    {
        if (sceneStack.Count > 0)
        {
            sceneStack.Pop();
            GameObject.Destroy(transform.GetChild(0).gameObject);
        }
        sceneStack.Push(go);
    }

    public void CurrentScreen()
    {
        StartCoroutine(LoadScene());
    }

    public void GotoScreen(string screen)
    {
        if (screen == "EndScreen") currentScreen = ScreenState.EndScreen;
        SceneManager.LoadScene(screen);
    }

    void Load()
    {
        string name = PlayerPrefs.GetString("armor");
        if (name != null)
            ToolBox.GetInstance().GetManager<GameManager>().player.GetComponent<PlayerController>().ArmorEquip((EquipmentItemObject)Resources.Load(name));

        name = PlayerPrefs.GetString("hammer");
        if (name != null)
            ToolBox.GetInstance().GetManager<GameManager>().player.GetComponent<PlayerController>().HammerEquip((EquipmentItemObject)Resources.Load(name));

        int cnt = PlayerPrefs.GetInt("invenCnt");
        for (int i = 0; i < cnt; i++)
        {
            name = PlayerPrefs.GetString("inven" + i.ToString());
            ToolBox.GetInstance().GetManager<GameManager>().player.GetComponent<PlayerController>().inventory.items.Add((EquipmentItemObject)Resources.Load(name));
        }
    }
}
