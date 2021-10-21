using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField]
    GameObject bktransform;

    [SerializeField]
    private float speed = 0.1f;

    private bool one = false;

    private void Start()
    {

    }
    private void Update()
    {
        bktransform.transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        BackGroundCk();
    }



    private void BackGroundCk()
    {
        if (bktransform.transform.position.y <= -22f)
        {
            Debug.Log("o");
            bktransform.transform.position = new Vector3(0, -10f, 0);
        }
    }
}
