using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [SerializeField]
    internal GameObject playerGameobject;

    public List<Vector3> playerPosition = new List<Vector3>();

    private int playerPositionIndex = 1;

    private int playerMaxIndex;
    public void Start()
    {
        playerGameobject.transform.position = playerPosition[playerPositionIndex];
        playerMaxIndex = playerPosition.Count-1;
    }
    public void OnclickRight()
    {
        if (playerPositionIndex == playerMaxIndex)
            return;
        playerGameobject.transform.position = playerPosition[++playerPositionIndex];

        //GameManager.Instance.backGround.BackGroundMove();
    }

    public void OnclickLeft()
    {
        if (playerPositionIndex == 0)
            return;
        playerGameobject.transform.position = playerPosition[--playerPositionIndex];

        //GameManager.Instance.backGround.BackGroundMove();
    }
}
