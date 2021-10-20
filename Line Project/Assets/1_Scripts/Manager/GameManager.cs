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


}
