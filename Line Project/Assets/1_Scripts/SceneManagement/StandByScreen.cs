using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandByScreen : UiScreen
{
    public override void UpdateScreenStatus(bool open)
    {
        Debug.Log("stand");
        base.UpdateScreenStatus(open);
    }
}
