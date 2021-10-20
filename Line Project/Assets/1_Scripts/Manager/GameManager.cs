using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoSingleton<GameManager>
{
    private GameState state; //씬 상태
    private List<Component> components = new List<Component>();


    [SerializeField]
    private User user;
    private string SAVE_PATH = "";
    private readonly string SAVE_FILENAME = "/SaveFile.txt";
    private void Awake()
    {
        SAVE_PATH = Application.dataPath + "/Save"; //모바일때는 persistenDathPath로 변환
        if(!Directory.Exists(SAVE_PATH))
        {
            Directory.CreateDirectory(SAVE_PATH);
        }
        LoadFromJson();


        UpdateState(GameState.INIT);
        components.Add(new LineComponent());
        components.Add(new UiComponent());

        InvokeRepeating("SaveToJson", 0f, 60f);
    }
    private void Start()
    {
        UpdateState(GameState.INIT);
        InvokeRepeating("CreateCake", 0.5f, Random.Range(0.4f, 5f));
        InvokeRepeating("CreateStone", 0.5f, Random.Range(.4f, 5f));
    }

    private void LoadFromJson()
    {
        string json = "";

        if(File.Exists(SAVE_PATH + SAVE_FILENAME))
        {
            json = File.ReadAllText(SAVE_PATH + SAVE_FILENAME);
            user = JsonUtility.FromJson<User>(json);
        }
        else
        {
            SaveToJson();
            LoadFromJson();
        }
    }
    private void SaveToJson()
    {
        SAVE_PATH = Application.dataPath + "/Save";
        if (user == null) return;
        string json = JsonUtility.ToJson(user, true);
        File.WriteAllText(SAVE_PATH + SAVE_FILENAME, json, System.Text.Encoding.UTF8);
    }
    private void OnApplicationPause(bool pause)
    {
        SaveToJson();
    }
    private void OnApplicationQuit()
    {
        SaveToJson();
    }
    public void UpdateState(GameState state)
    {
        //상태 변경
        this.state = state;

        for (int i = 0; i < components.Count; i++)
        {
            components[i].UpdateState(state);
        }
        if (state == GameState.INIT)
            UpdateState(GameState.STANDBY);

    }

    private void CreateCake()
    {
        GameObject cake = PoolManager.Instance.GetPooledObject(1);
        cake.SetActive(true);
        int line = Random.Range(0, 2);
        switch (line)
        {
            case 0:
                cake.transform.position = new Vector2(-1.4f, 6f);
                break;
            case 1:
                cake.transform.position = new Vector2(0, 6f);
                break;
            case 2:
                cake.transform.position = new Vector2(1.4f, 6f);
                break;
        }
    }
    private void CreateStone()
    {
        GameObject stone = PoolManager.Instance.GetPooledObject(2);
        stone.SetActive(true);
        int line = Random.Range(0, 2);
        switch (line)
        {
            case 0:
                stone.transform.position = new Vector2(-1.4f, 6f);
                break;
            case 1:
                stone.transform.position = new Vector2(0, 6f);
                break;
            case 2:
                stone.transform.position = new Vector2(1.4f, 6f);
                break;
        }
    }
}
