using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public GameObject player;


    //이걸로 라인 바꾸는거 조종가능(1이면 한칸 2면 2칸씩)
    [SerializeField]
    private int changeline = 1;

    [SerializeField]
    private GameObject line = null;
    private float speed = 1;
    int a = 0;
    int o = 0;

    Vector2 d = new Vector2(-1.5f, 0);
    //int a = GameManager.Instance.line.transform.childCount;
    private void Start()
    {
        player.transform.SetParent(BackGround.Instance.transform.GetChild(2));
        player.transform.position = new Vector2(line.transform.GetChild(2).position.x, -4f);
        line.transform.GetChild(2).gameObject.SetActive(true);
    }

    private void Update()
    {
        player.transform.position += new Vector3(0f, 1f) * speed * Time.deltaTime;
        if (player.transform.position.y >= BackGround.Instance.transform.GetChild(player.transform.parent.GetSiblingIndex() + 5).transform.position.y)
        {
            player.transform.SetParent(BackGround.Instance.transform.GetChild(player.transform.parent.GetSiblingIndex() + 5));
            o += 5;
        }
        //player.transform.DOLocalMoveY(line.transform.GetChild(player.transform.parent.GetSiblingIndex()).transform.position.y, line.transform.GetChild(player.transform.parent.GetSiblingIndex() + 5).transform.position.y);
    }
    public void OnclickRight()
    {
        //지금 자신이 몇번째 자신이 알게해준다.
        a = player.transform.parent.GetSiblingIndex() + 1;
        int b = player.transform.parent.parent.childCount;
        Debug.Log(a);
        Debug.Log(b);
        if (b - 1 >= a && a % 5 != 0)
        {
            if (BackGround.Instance.transform.GetChild(a).gameObject.activeSelf == true)
            {
                player.transform.position = new Vector2(BackGround.Instance.transform.GetChild(a).position.x, player.transform.position.y);
                player.transform.parent = BackGround.Instance.transform.GetChild(a);
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
        a = player.transform.parent.GetSiblingIndex() > o ? player.transform.parent.GetSiblingIndex()-1 : player.transform.parent.GetSiblingIndex();
        int b = player.transform.parent.parent.childCount;
        Debug.Log(a);
        Debug.Log(b);
        if (6 > a && a >= 0)
        {
            if (BackGround.Instance.transform.GetChild(a).gameObject.activeSelf == true)
            {
                player.transform.position = new Vector2(BackGround.Instance.transform.GetChild(a).position.x, player.transform.position.y);
                player.transform.parent = BackGround.Instance.transform.GetChild(a);
            }
        }
        else if(a%5 != 0)
        {
            Debug.Log(a);
            player.transform.parent = BackGround.Instance.transform.GetChild(a);
            player.transform.position = new Vector2(BackGround.Instance.transform.GetChild(a).position.x, player.transform.position.y);
        }
    }
}
