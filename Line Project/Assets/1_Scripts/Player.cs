using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [SerializeField]
    internal GameObject playerGameobject;
    [SerializeField]
    private Animator playerAnimator = null;
    [SerializeField]
    private Animator headAnimator = null;
    [SerializeField]
    private GameObject tiger = null;

    public List<Vector3> playerPosition = new List<Vector3>();

    [SerializeField]
    private int playerPositionIndex = 1;

    private int playerMaxIndex;


    private bool isleft = false;
    public void Start()
    {
        playerGameobject.transform.position = playerPosition[playerPositionIndex];
        playerMaxIndex = playerPosition.Count-1;
        playerAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.tag == "CutLine")
            {
            Die();
            }
    }
    private void Die()
    {
        Debug.Log("fall");
     //   GameManager.Instance.CancelInvoke("CreateCake");
      //  GameManager.Instance.CancelInvoke("CreateStone");
       // GameManager.Instance.CancelInvoke("TimeAddScore");
        PlayerPrefs.SetInt("SCORE", GameManager.Instance.score);
        playerAnimator.SetBool("isDie", true);
        transform.GetChild(0).gameObject.SetActive(false);
        transform.DOMoveY(-19, 2f);
        GameManager.Instance.Invoke("Fun", 1f);
    }
    public void OnclickRight()
    {
        if (playerPositionIndex == playerMaxIndex)
            return;
        isleft = false;
        GetComponent<SpriteRenderer>().flipX = false;
        tiger.GetComponent<SpriteRenderer>().flipX = false;
        SoundManager.Instance.SoundOn(3);
        playerAnimator.SetBool("isMove", true);
        tiger.GetComponent<Animator>().SetBool("isMove", true);
        Invoke("MoveAni", 0.3f);


        GameManager.Instance.backGround.BackGroundMove();
    }

    public void OnclickLeft()
    {
        if (playerPositionIndex == 0)
            return;
        isleft = true;
        GetComponent<SpriteRenderer>().flipX = true;
        tiger.GetComponent<SpriteRenderer>().flipX = true;
        SoundManager.Instance.SoundOn(3);
        playerAnimator.SetBool("isMove", true);
        tiger.GetComponent<Animator>().SetBool("isMove", true);
        Invoke("MoveAni", 0.3f);
        GameManager.Instance.backGround.BackGroundMove();
    }

    private void MoveAni()
    {
        if (!isleft)
        {
            if (playerPositionIndex == playerMaxIndex)
                return;
            playerGameobject.transform.position = playerPosition[++playerPositionIndex];
        }
        else if(isleft)
        {
            if (playerPositionIndex == 0)
                return;
            playerGameobject.transform.position = playerPosition[--playerPositionIndex];
        }
        tiger.transform.position = new Vector3(playerPosition[playerPositionIndex].x, tiger.transform.position.y, tiger.transform.position.z);
        playerAnimator.SetBool("isMove", false);
        tiger.GetComponent<Animator>().SetBool("isMove", false);
    }
}
