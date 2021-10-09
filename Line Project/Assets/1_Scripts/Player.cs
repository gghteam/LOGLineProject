using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject line = null;
    int a = 0;
    //int a = GameManager.Instance.line.transform.childCount;
    private void Start()
    {
        this.transform.position = line.transform.GetChild(2).position;
        this.transform.parent = line.transform.GetChild(2);
    }
    public void OnclickRight()
    {
        a = this.transform.parent.GetSiblingIndex() + 1;
        int b = this.transform.parent.parent.childCount;
        Debug.Log(a);
        Debug.Log(b);
        if (b - 1 >= a)
        {
            this.transform.position = line.transform.GetChild(a).position;
            this.transform.parent = line.transform.GetChild(a);
        }
        else
        {
            Debug.Log("�ȵȴٰ� ���ڽľ�");
            return;
        }
    }
    public void OnclickLeft()
    {
        a = this.transform.parent.GetSiblingIndex() - 1;
        int b = this.transform.parent.parent.childCount;
        Debug.Log(a);
        Debug.Log(b);
        if (0 <= a)
        {
            this.transform.position = line.transform.GetChild(a).position;
            this.transform.parent = line.transform.GetChild(a);
        }
    }
}
