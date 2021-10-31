using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UiManager : MonoBehaviour
{
    //bool isSetting = false;
    [SerializeField]
    private RectTransform settingPanel;

    public bool linestop = false;

    public void OpenUI(GameObject ui)
    {
        ui.SetActive(true);
    }
    public void CloseUI(GameObject ui)
    {
        ui.SetActive(false);
    }
    /*
    public void SettingMode(GameObject setting)
    {
        if (isSetting)
            setting.SetActive(false);
        else
            setting.SetActive(true);
        isSetting = isSetting ? isSetting = false : isSetting = true;
    }
    */

    public void OnToggleChanged(bool isOn)
    {
        if(isOn == false) { Time.timeScale = 1;}
        settingPanel.DOAnchorPosX(isOn ? 0f : 1400f, 0.2f).SetEase(Ease.InCirc).OnComplete(() =>
        {
            if (isOn) { Time.timeScale = 0; }
        });
        Debug.Log("ch");
    }
}
