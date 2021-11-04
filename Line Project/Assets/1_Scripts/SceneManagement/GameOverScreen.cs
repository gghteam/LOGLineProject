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
    [SerializeField]
    private Text scoreText = null;
    [SerializeField]
    private Text bestText = null;
    private AudioSource audio;
    private void Awake()
    {
        Screen.SetResolution(1440, 2960, false);
        CheckBest();
        scoreText.text = string.Format("{0}", PlayerPrefs.GetInt("SCORE", 0));
        startButton.onClick.AddListener(() => SceneManager.LoadScene("MainStartScene"));
        retryButton.onClick.AddListener(() => SceneManager.LoadScene("StartScene"));
        audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        CheckSound();
    }
    void CheckSound()
    {
        if(PlayerPrefs.GetInt("BGM",1)== 0)
        {
            audio.volume = 0;
        }

    }
    private void CheckBest()
    {
        if(PlayerPrefs.GetInt("SCORE", 0) > PlayerPrefs.GetInt("BEST", 0))
        {
            PlayerPrefs.SetInt("BEST", PlayerPrefs.GetInt("SCORE", 0));
        }
        bestText.text = string.Format("Best\n{0}", PlayerPrefs.GetInt("BEST", 0));
    }
}
