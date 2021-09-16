using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiComponent : Component
{
    List<UiScreen> screens = new List<UiScreen>();
    public UiComponent()
    {
        //ui스크린 가져오기
        this.screens.Add(GameObject.Find("StandByScreen").GetComponent<UiScreen>());
        this.screens.Add(GameObject.Find("RunningScreen").GetComponent<UiScreen>());
        this.screens.Add(GameObject.Find("GameOverScreen").GetComponent<UiScreen>());
    }
    public void UpdateState(GameState state)
    {
        switch(state)
        {
            case GameState.INIT:
                CloseAllScreens();
                break;
            default:
                ActiveScreen(state);
                break;
              
        }
    }
    void CloseAllScreens()
    {
        foreach(var screen in screens)
        {
            screen.UpdateScreenStatus(false);
        }
    }
    void ActiveScreen(GameState type)
    {
        CloseAllScreens();

        GetScreen(type).UpdateScreenStatus(true);
    }
    UiScreen GetScreen(GameState screenState)
    {
        return screens.Find(el => el.screenState == screenState);
    }
}
