using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public GameObject player;


    //�̰ɷ� ���� �ٲٴ°� ��������(1�̸� ��ĭ 2�� 2ĭ��)
    [SerializeField]
    private int changeline = 1;

    [SerializeField]
    private GameObject line = null;
    int a = 0;
    //int a = GameManager.Instance.line.transform.childCount;
    private void Start()
    {
        player.transform.SetParent(line.transform.GetChild(2));
         player.transform.position = new Vector2(line.transform.GetChild(2).position.x, -4f);
        line.transform.GetChild(2).gameObject.SetActive(true);
    }

    private void Update()
    {
        //player.transform.position += new Vector3(0f,1f)*speed*Time.deltaTime;
        /*if(player.transform.position.y >= line.transform.GetChild(player.transform.parent.GetSiblingIndex() + 5).transform.position.y)
        {
            player.transform.SetParent(line.transform.GetChild(player.transform.parent.GetSiblingIndex() + 5));
        }*/
        //player.transform.DOLocalMoveY(line.transform.GetChild(player.transform.parent.GetSiblingIndex()).transform.position.y, line.transform.GetChild(player.transform.parent.GetSiblingIndex() + 5).transform.position.y);
    }

    public void OnclickRight()
    {
        //���� �ڽ��� ���° �ڽ��� �˰����ش�.
        a = player.transform.parent.GetSiblingIndex() + 1;
        int b = player.transform.parent.parent.childCount;
        Debug.Log(a);
        Debug.Log(b);
        if (b - 1 >= a && a % 5 != 0)
        {
            if(line.transform.GetChild(a).gameObject.activeSelf == true)
            {
            player.transform.position = new Vector2(line.transform.GetChild(a).position.x,player.transform.position.y);
            player.transform.parent = line.transform.GetChild(a);
            }
        }
        else
        {
            Debug.Log(" ");
            return;
        }
    }
    public void OnclickLeft()
    {
        a = player.transform.parent.GetSiblingIndex() - 1;
        int b = player.transform.parent.parent.childCount;
        Debug.Log(a);
        Debug.Log(b);
        if (a >= 0)
        {
                /*if (line.transform.GetChild(a).gameObject.activeSelf == true)
                {
                    player.transform.position = new Vector2(line.transform.GetChild(a).position.x, player.transform.position.y);
                }*/
                if (line.transform.GetChild(a).gameObject.activeSelf == true)
                {
                    player.transform.position = new Vector2(line.transform.GetChild(a).position.x, player.transform.position.y);
                    player.transform.parent = line.transform.GetChild(a);
                }
        }
    }
}
