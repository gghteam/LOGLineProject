using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    //아래 있는게 기본 라인 위치 기본값 
    Vector2 d = new Vector2(-1.5f, 0);

    private void Start()
    {
        SetLine();
    }


    //--------------------------------------------------라인 위치 정해주는 코드---------------------------------------------------------------
    private void SetLine()
    {
        int a = 0;
        for(int i = 0; i < PoolManager.Instance.itemsToPool[0].amountToPool;)
        {
            Vector2 d = new Vector2(-1.5f, a);
            int j = 0;
            PoolManager.Instance.pooledObjects[i].transform.position = d;
            PoolManager.Instance.pooledObjects[i].SetActive(true);//0?
            i++; //1
            Debug.Log(i);
            for (j = 0; j<4;)
            {
                d.x += 0.75f;
                PoolManager.Instance.pooledObjects[i].transform.position = d;
                PoolManager.Instance.pooledObjects[i].SetActive(true);
                j++;
                i++;
                Debug.Log(i);
            }
        }
    }
}
