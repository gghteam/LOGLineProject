using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningScreen : MonoBehaviour
{
    private void Start()
    {
        SoundManager.Instance.GetVolume();
    }
}
