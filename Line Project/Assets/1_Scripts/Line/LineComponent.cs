using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineComponent : Component
{
    List<Line> obstacless = new List<Line>();

    public Vector2 d = new Vector2(-1.5f, 0);
    public void UpdateState(GameState state)
    {
        switch (state)
        {
            case GameState.INIT:
                SetLine();
                break;
            case GameState.STANDBY:
                break;
            case GameState.RUNNING:
                break;
        }
    }
    private void SetLine()
    {
        for (int i = 0; i < PoolManager.Instance.itemsToPool[0].amountToPool - 10;)
        {
            int j = 0;
            GameObject C = PoolManager.Instance.pooledObjectsList[0][i];
            C.transform.position = d;
            C.SetActive(true);//0?
                              //GameObject line = PoolManager.Instance.GetPooledObject(0                                                //line.transform.position = d;
                              //line.SetActive(true);
            i++;
            Debug.Log(i);
            for (j = 0; j < 4;)
            {
                d.x += 0.75f;
                GameObject b = PoolManager.Instance.pooledObjectsList[0][i];
                b.transform.position = d;
                b.SetActive(true);
                //GameObject line2 = PoolManager.Instance.GetPooledObject(0);
                //line2.transform.position = d;
                //line2.SetActive(true);
                i++;
                j++;
                Debug.Log(i);
            };
            d.x = -1.5f;
            d.y += 10f;
        }
    }

}
