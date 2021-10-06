using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    bool isSetting = false;

    public void OpenUI(GameObject ui)
    {
        ui.SetActive(true);
    }
    public void CloseUI(GameObject ui)
    {
        ui.SetActive(false);
    }
    public void SettingMode(GameObject setting)
    {
        if (isSetting)
            setting.SetActive(false);
        else
            setting.SetActive(true);
        isSetting = isSetting ? isSetting = false : isSetting = true;
    }

}
