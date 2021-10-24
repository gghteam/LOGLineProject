using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoSingleton<BackGround>
{
    [SerializeField]
    GameObject bktransform;

    [SerializeField]
    private float speed = 0.1f;

    public Vector2 d = new Vector2(-1.5f, 10f);

    private int c = 0;

    private bool b = false;

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
            for (int i = 20; i < 30; i++)
            {
                Vector3 f = bktransform.transform.GetChild(i).gameObject.transform.position;
                PoolManager.Instance.Despawn(bktransform.transform.GetChild(i).gameObject);
                switch (0)
                {
                    case 0:
                        GameObject a = PoolManager.Instance.GetPooledObject(0);
                        a.SetActive(true);
                        a.transform.SetParent(bktransform.transform);
                        a.transform.position = f;
                        Debug.Log("??");
                        break;
                }
            }
        }
    }
}
