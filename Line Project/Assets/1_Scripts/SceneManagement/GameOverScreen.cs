using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField]
    Button startButton;
    [SerializeField]
    Button retryButton;
    private void Awake()
    {
        startButton.onClick.AddListener(() => SceneManager.LoadScene("MainStartScene"));
        retryButton.onClick.AddListener(() => SceneManager.LoadScene("StartScene"));
    }
}
