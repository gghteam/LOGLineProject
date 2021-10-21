using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBackground : Line
{
    private MeshRenderer render;

    public float linespeed;
    public float offsetspeed;
    private float offset;
    void Start()
    {
        render = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position -= new Vector3(0, linespeed * Time.deltaTime, 0);
        render.material.mainTextureOffset = new Vector2(offset, 0);
    }
}
