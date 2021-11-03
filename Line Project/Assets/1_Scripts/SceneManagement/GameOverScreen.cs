using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField]
    Button button;
    private void Awake()
    {
        button.onClick.AddListener(() => SceneManager.LoadScene("MainStartScene"));
    }
}
