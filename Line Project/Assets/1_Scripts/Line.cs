using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    private int c = 0;

    public List<GameObject> Prefab = new List<GameObject>();
    private void Awake()
    {
        SetLine();
    }
    private void SetLine()
    {
        float c = -1.5f;
        Vector2 d = new Vector2(c, 0);
        for (int i = 0; i < 5; i++)
        {
            var obj = Instantiate(Prefab[0], this.transform);
            obj.transform.position = d;
            if (i >= 1)
            {
                d.x += 0.75f;
                Debug.Log(d);
                obj.transform.position = d;
            }
            Debug.Log(i);
        }
    }
    public void ScoreButton()
    {
        c += 100;
    }
}
