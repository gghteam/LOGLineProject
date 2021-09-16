using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private GameState state; //�� ����
    private List<Component> components = new List<Component>();

    public void UpdateState(GameState state)
    {
        //���� ����
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
