using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tiger : MonoBehaviour
{
    public void Up()
    {
        transform.DOMoveY(-9.5f, 0.5f);
    }

    public void Down()
    {
        transform.DOMoveY(-14, 0.5f);
    }
}
