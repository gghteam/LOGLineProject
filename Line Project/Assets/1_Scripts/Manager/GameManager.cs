using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private GameState state; //씬 상태
    private List<Component> components = new List<Component>();

    public void UpdateState(GameState state)
    {
        //상태 변경
        this.state = state;

        for (int i = 0; i < components.Count; i++)
        {
            components[i].UpdateState(state);
        }
        if (state == GameState.INIT)
            UpdateState(GameState.STANDBY);

    }
    private void Awake()
    {
        components.Add(new UiComponent());

        UpdateState(GameState.INIT);
    }
}
