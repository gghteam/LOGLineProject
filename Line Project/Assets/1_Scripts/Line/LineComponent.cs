using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineComponent : MonoBehaviour
{
    public Vector2 d = new Vector2(-1.5f, -7f);

    float lm = -20f;

    public GameObject lineobject;

    private void Start()
    {
        SetLine();
    }
    private void Update()
    {
        lineobject.transform.position -= new Vector3(0, 2 * Time.deltaTime, 0);
        if (lineobject.transform.position.y < lm)
        {
            lineck();
            lm += -10f;
        }
    }
    private void SetLine()
    {
        for (int i = 0; i < 20;)
        {
            int j = 0;
            int count = 0;
            for (j = 0; j < 3;)
            {
                if (i < 9)
                {
                    GameObject c = PoolManager.Instance.GetPooledObject(0);
                    c.transform.SetParent(lineobject.transform);
                    c.transform.localPosition = d;
                    c.SetActive(true);
                    d.x += 1.5f;
                    i++;
                    j++;
                }
                else
                {
                    int RandomNumber2 = Random.Range(0, 101);
                    if (RandomNumber2 >= 80)
                    {
                        if (count < 1)
                        {
                            GameObject e = PoolManager.Instance.GetPooledObject(3);
                            e.transform.SetParent(lineobject.transform);
                            e.transform.localPosition = d;
                            e.SetActive(true);
                            i++;
                            j++;
                            Debug.Log(i);
                            d.x += 1.5f;
                            count++;
                        }
                        else
                        {
                            GameObject b = PoolManager.Instance.GetPooledObject(0);
                            b.transform.SetParent(lineobject.transform);
                            b.transform.localPosition = d;
                            b.SetActive(true);
                            i++;
                            j++;
                            Debug.Log(i);
                            d.x += 1.5f;
                        }
                    }
                    else
                    {
                        GameObject e = PoolManager.Instance.GetPooledObject(0);
                        e.transform.SetParent(lineobject.transform);
                        e.transform.localPosition = d;
                        e.SetActive(true);
                        i++;
                        j++;
                        Debug.Log(i);
                        d.x += 1.5f;
                    }
                }
            }
            d.x = -1.5f;
            d.y += 10f;
        }
    }
    public void lineck()
    {
        for (int i = 0; i < 3; i++)
        {
            Debug.Log(i);
            PoolManager.Instance.Despawn(lineobject.transform.GetChild(i).gameObject);
        }
        int count = 0;
        for (int i = 0; i < 3; i++)
        {
            int RandomNumber2 = Random.Range(0, 101);
            if (RandomNumber2 >= 80)
            {
                if (count < 1)
                {
                    GameObject e = PoolManager.Instance.GetPooledObject(3);
                    e.transform.SetParent(lineobject.transform);
                    e.transform.localPosition = d;
                    e.SetActive(true);
                    Debug.Log(i);
                    d.x += 1.5f;
                    count++;
                }
                else
                {
                    GameObject b = PoolManager.Instance.GetPooledObject(0);
                    b.transform.SetParent(lineobject.transform);
                    b.transform.localPosition = d;
                    b.SetActive(true);
                    Debug.Log(i);
                    d.x += 1.5f;
                }
            }
            else
            {
                GameObject e = PoolManager.Instance.GetPooledObject(0);
                e.transform.SetParent(lineobject.transform);
                e.transform.localPosition = d;
                e.SetActive(true);
                Debug.Log(i);
                d.x += 1.5f;
            }
        }
        d.x = -1.5f;
        d.y += 10f;
        Debug.Log("o");
    }
}
