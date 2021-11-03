using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    [SerializeField]
    Camera selectedCamera;
    public bool CheckObjectIsInCamera(GameObject _target)
    {
        Vector3 screenPoint = selectedCamera.WorldToViewportPoint(_target.transform.position);
        bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0
        && screenPoint.y < 1;
        return onScreen;
    }
}
