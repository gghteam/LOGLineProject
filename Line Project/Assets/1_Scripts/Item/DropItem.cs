using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public void ReadyItem()
    {
        //���� ��ġ
        int line = Random.Range(0, 2);
        Debug.Log("a");
        switch (line)
        {
            case 0:
                gameObject.transform.position = new Vector2(-1.4f, 6f);
                break;
            case 1:
                gameObject.transform.position = new Vector2(0, 6f);
                break;
            case 2:
                gameObject.transform.position = new Vector2(1.4f, 6f);
                break;
        }
               // PoolManager.Instance.pooledObjectsList[1][0].SetActive(true);
    }
}
