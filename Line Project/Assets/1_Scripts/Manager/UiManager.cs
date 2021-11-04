using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    //bool isSetting = false;
    [SerializeField]
    private RectTransform settingPanel;
    [SerializeField]
    private Text myScore = null;


    [SerializeField]
    private Text time = null;

    public bool linestop = false;



    //public void OpenUI(GameObject ui)
    //{
    //    ui.SetActive(true);
    //}
    //public void CloseUI(GameObject ui)
    //{
    //    ui.SetActive(false);
    //}
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
        if (isOn == false)
        {
            if (SceneManager.GetActiveScene().name == "StartScene")
            {
                Debug.Log("³²¼ÒÁ¤");
                StartCoroutine(Timer());
            }
            else
            {
                Time.timeScale = 1;
            }
        }
        settingPanel.DOAnchorPosX(isOn ? 0f : 1400f, 0.2f).SetEase(Ease.InCirc).OnComplete(() =>
        {
            if (isOn)
            {
                Time.timeScale = 0;
            }
        });
    }

    public void UpdateUI()
    {
        myScore.text = string.Format("Score\n{0}", GameManager.Instance.score);
    }

    private IEnumerator Timer()
    {
        for (int i = 3; i > 0; i--)
        {
            time.text = string.Format("{0}", i);
            yield return new WaitForSecondsRealtime(1f);
        }
        time.text = "";
        Time.timeScale = 1;
    }
}
