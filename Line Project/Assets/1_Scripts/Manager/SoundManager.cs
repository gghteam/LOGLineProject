using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField]
    private Button[] soundButton = null;

    [SerializeField]
    List<AudioClip> audioClip = new List<AudioClip>();
    [SerializeField]
    List<AudioSource> audioSource = new List<AudioSource>();
    [SerializeField]
    Image[] soundImage;
    [SerializeField]
    Sprite[] spriteImage;


    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        GetVolume();
        ImageSound();
        soundButton[0].onClick.AddListener(() => SoundOnOff("BGM"));
        soundButton[1].onClick.AddListener(() => SoundOnOff("SFX"));
    }

    public void SoundOnOff(string type)
    {
        switch (type)
        {
            case "BGM":
                audioSource[0].volume = audioSource[0].volume == 0 ? audioSource[0].volume = 1 : audioSource[0].volume = 0;
                if(audioSource[0].volume==0)
                    PlayerPrefs.SetInt("BGM", 0);
                else
                    PlayerPrefs.SetInt("BGM", 1);
                ImageSound();
                break;
            case "SFX":
                audioSource[1].volume = audioSource[1].volume == 0 ? audioSource[1].volume = 1 : audioSource[1].volume = 0;
                if (SceneManager.GetActiveScene().name != "MainStartScene")
                {
                audioSource[2].volume = audioSource[2].volume == 0 ? audioSource[2].volume = 1 : audioSource[2].volume = 0;
                }
                if (audioSource[1].volume == 0)
                    PlayerPrefs.SetInt("SFX", 0);
                else
                    PlayerPrefs.SetInt("SFX", 1);
                ImageSound();
                break;
        }
    }
    public void SetVolume()
    {

                PlayerPrefs.SetInt("BGM", PlayerPrefs.GetInt("BGM",1) == 0 ? 1 : 0);
                PlayerPrefs.SetInt("SFX", PlayerPrefs.GetInt("SFX", 0) == 0 ? 1 : 0);
    }
    public void GetVolume()
    {
                audioSource[0].volume = PlayerPrefs.GetInt("BGM",1);
                audioSource[1].volume = PlayerPrefs.GetInt("SFX",1);
        if (SceneManager.GetActiveScene().name != "MainStartScene")
        {
                audioSource[2].volume = PlayerPrefs.GetInt("SFX",1);
        }
    }
    public void SoundOn(int source, int clip)
    {
        audioSource[source].clip = audioClip[clip];
        audioSource[source].Play();
    }

    public void OnSound()
    {
        audioSource[1].Play();
    }
    private void ImageSound()
    {
        if(PlayerPrefs.GetInt("BGM", 1) == 1)
        {
            soundImage[0].sprite = spriteImage[0];
        }
        else
        {
            soundImage[0].sprite = spriteImage[1];
        }
        if(PlayerPrefs.GetInt("SFX", 1) == 1)
        {
            soundImage[1].sprite = spriteImage[0];
        }
        else
        {
            soundImage[1].sprite = spriteImage[1];
        }

    }
}