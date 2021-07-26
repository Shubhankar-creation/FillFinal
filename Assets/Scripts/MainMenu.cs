using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    private RectTransform rectTransSetting;
    private GameObject settingGO, musicGO;
    private int settingCount = 0, musicCount = 0;

    public Sprite[] music;

    private void Start()
    {
        settingGO = GameObject.FindGameObjectWithTag("Setting");
        musicGO = GameObject.FindGameObjectWithTag("Music");
        rectTransSetting = settingGO.GetComponent<RectTransform>();
        musicGO.GetComponent<Image>().sprite = music[0];

    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void settingBtnAmin()
    {
        if (settingCount % 2 == 0) rectTransSetting.anchoredPosition = new Vector3(rectTransSetting.anchoredPosition.x, 960f, 0f);
        else rectTransSetting.anchoredPosition = new Vector3(rectTransSetting.anchoredPosition.x, 1150f, 0f);
        settingCount++;
    }
    public void MusicBtn()
    {

        if (musicCount == 0)
        {
            musicGO.GetComponent<Image>().sprite = music[1];
            musicCount = 1;
            AudioListener.volume = 0f;
        }
        else
        {
            musicGO.GetComponent<Image>().sprite = music[0];
            musicCount = 0;
            AudioListener.volume = 0.25f;
        }
    }
}
