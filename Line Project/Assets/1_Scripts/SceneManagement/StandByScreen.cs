using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StandByScreen : MonoBehaviour
{
    [SerializeField]
    Button[] button;
    
    private void Awake()
    {
        Screen.SetResolution(1440, 2960, false);
        button[0].onClick.AddListener(() => SceneManager.LoadScene("StartScene"));
        button[1].onClick.AddListener(() => Quit());
    }
    private void Quit()
    {
        Application.Quit();
    }
}
