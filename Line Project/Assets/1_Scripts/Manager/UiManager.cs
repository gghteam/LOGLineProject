using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UiManager : MonoBehaviour
{
    //bool isSetting = false;
    [SerializeField]
    private RectTransform settingPanel;
    [SerializeField]
    private Text myScore = null;

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

    public void UpdateUI()
    {
        myScore.text = string.Format("Score\n{0}", GameManager.Instance.score);
    }
}
