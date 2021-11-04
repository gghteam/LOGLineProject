using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    //private GameState state; //╬ю ╩Себ
    //private List<Component> components = new List<Component>();
    public BackGround backGround { get; private set; }

    public int score { get; private set; }
    public Tiger tiger { get; private set; }
    public LineComponent lineComponent { get; private set; }
    public UiManager uiManager { get; private set; }

    private bool isCatch = false;

    
    private void Awake()
    {
        Screen.SetResolution(1440, 2960, false);
        Instance = this;
        backGround = FindObjectOfType<BackGround>();
        lineComponent = FindObjectOfType<LineComponent>();
        uiManager = FindObjectOfType<UiManager>();
        tiger = FindObjectOfType<Tiger>();

        
        score = 0;
    }

    public void Judgment()
    {
        if(!isCatch)
        {
            isCatch = true;
            tiger.Up();
            StartCoroutine(Timer());
        }
        else if(isCatch)
        {
            tiger.End();
            Invoke("Fun", 0.5f);
            PlayerPrefs.SetInt("SCORE", score);
        }
    }
    void Start()
    {
        InvokeRepeating("CreateCake", 0.5f, Random.Range(0.4f, 5f));
        InvokeRepeating("CreateStone", 0.5f, Random.Range(.4f, 5f));
        InvokeRepeating("TimeAddScore", 5f, 5f);
    }



    private void CreateCake()
    {
        Debug.Log("Hi");
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
    public void EndGame()
    {
        CancelInvoke("CreateCake");
        CancelInvoke("CreateStone");
        CancelInvoke("TimeAddScore");
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
    private void TimeAddScore()
    {
        score += 10;
        uiManager.UpdateUI();
    }
    public void AddScore()
    {
        score += 100;
        uiManager.UpdateUI();
    }
    private IEnumerator Timer()
    {
        int i = 20;
        while(i > 0)
        {
            yield return new WaitForSeconds(1f);
            i--;
        }
        isCatch = false;
        tiger.Down();
    }

    public void Fun()
    {
        EndGame();
        SceneManager.LoadScene("GameOverScene");
    }
}
