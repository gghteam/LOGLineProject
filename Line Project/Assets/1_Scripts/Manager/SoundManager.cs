using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private Button soundButton = null;


    private void Start()
    {
        soundButton.onClick.AddListener(() => SoundOnOff());
    }



    public void SoundOnOff()
    {
        AudioListener.volume = AudioListener.volume == 1 ? AudioListener.volume = 0 : AudioListener.volume = 1;
    }
}
