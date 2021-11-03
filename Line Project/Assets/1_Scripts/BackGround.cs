using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField]
    GameObject bktransform;

    [SerializeField]
    private float speed = 0.1f;

    public Vector2 d = new Vector2(-1.5f, 10f);

    private int c = 0;

    private bool b = false;

    private bool one = false;

    [SerializeField]
    private GameObject player;
    private void Update()
    {
        bktransform.transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        BackGroundCk();
    }

    public Vector3 BackGroundMove()
    {
        return bktransform.transform.position += new Vector3(0, -0.05f, 0);
    }

    private void BackGroundCk()
    {
        if (bktransform.transform.position.y <= -43f)
        {
            bktransform.transform.position = new Vector2(0, -7f);
        }
    }
}
