using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StandByScreen : MonoBehaviour
{
    [SerializeField]
    Button button;
    private void Awake()
    {
        button.onClick.AddListener(() => SceneManager.LoadScene("StartScene"));
    }
}
