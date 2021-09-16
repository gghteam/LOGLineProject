using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiScreen : MonoBehaviour
{
    [SerializeField]
    internal GameState screenState=GameState.STANDBY;
    [SerializeField]
    protected CanvasGroup canvasGroup;

    public virtual void UpdateScreenStatus(bool open)
    {
        canvasGroup.alpha = open ? 1 : 0;
        canvasGroup.interactable = open;
        canvasGroup.blocksRaycasts = open;
    }
}
