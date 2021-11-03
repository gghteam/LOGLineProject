using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        soundButton[0].onClick.AddListener(() => SoundOnOff("BGM"));
        soundButton[1].onClick.AddListener(() => SoundOnOff("SFX"));
    }

    public void SoundOnOff(string type)
    {
        switch (type)
        {
            case "BGM":
                audioSource[0].volume = audioSource[0].volume == 0 ? audioSource[0].volume = 1 : audioSource[0].volume = 0;
                break;
            case "SFX":
                audioSource[1].volume = audioSource[1].volume == 0 ? audioSource[1].volume = 1 : audioSource[1].volume = 0;
                audioSource[2].volume = audioSource[2].volume == 0 ? audioSource[2].volume = 1 : audioSource[2].volume = 0;
                break;
        }
    }

    public void OnSound(int source, int clip)
    {
        Debug.Log("¤·");
        audioSource[source].clip = audioClip[clip];
        audioSource[source].Play();
    }
}