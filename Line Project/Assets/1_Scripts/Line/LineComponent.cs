using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineComponent : Component
{
    List<Line> obstacless = new List<Line>();

    public Vector2 d = new Vector2(-1.5f, -7f);
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
        for (int i = 0; i < PoolManager.Instance.itemsToPool[0].amountToPool;)
        {
            int j = 0;
            int RandomNumber = Random.Range(0, 101);
            GameObject C = RandomNumber >= 80 ? PoolManager.Instance.GetPooledObject(3) : PoolManager.Instance.GetPooledObject(0);
            C.transform.position = d;
            C.transform.SetParent(GameManager.Instance.backGround.transform);
            C.SetActive(true);//0?
            //C.transform.SetParent()
                              //GameObject line = PoolManager.Instance.GetPooledObject(0                                                //line.transform.position = d;
                              //line.SetActive(true);
            i++;
            Debug.Log(i);
            for (j = 0; j < 4;)
            {
                d.x += 0.75f;
                int RandomNumber2 = Random.Range(0, 101);
                GameObject b = RandomNumber2 >= 80 ? PoolManager.Instance.GetPooledObject(3) : PoolManager.Instance.GetPooledObject(0);
                b.transform.position = d;
                b.transform.SetParent(GameManager.Instance.backGround.transform);
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
