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
        if (bktransform.transform.position.y <= -35f)
        {
            Vector3 playerposition = player.transform.position;
            player.transform.SetParent(null);
            Debug.Log("o");
            bktransform.transform.position = new Vector2(0, -10f);
            for (int i = 20; i < 30; i++)
            {
                Vector3 f = bktransform.transform.GetChild(i).gameObject.transform.position;
                PoolManager.Instance.Despawn(bktransform.transform.GetChild(i).gameObject);
                int Randomnumber = Random.Range(0, 2);
                Debug.Log(Randomnumber);
                switch (Randomnumber)
                {
                    case 0:
                        GameObject a = PoolManager.Instance.GetPooledObject(0);
                        a.SetActive(true);
                        a.transform.SetParent(bktransform.transform);
                        a.transform.position = f;
                        Debug.Log("??");
                        break;
                    case 1:
                        GameObject c = PoolManager.Instance.GetPooledObject(3);
                        c.SetActive(true);
                        c.transform.SetParent(bktransform.transform);
                        c.transform.position = f;
                        Debug.Log("c");
                        break;
                }
               //player.transform.position = playerposition;
            }
        }
    }
}
