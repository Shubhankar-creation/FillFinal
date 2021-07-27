using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class mainMenuCanvas : MonoBehaviour
{
    private canvasData playerData;
    public GameObject Textname;
    public GameObject placeHolder;

    public Slider progressBar;
    public Text scoreText;

    private void Start()
    {
        playerData = GetComponent<canvasData>();

        progressBar.maxValue = PlayerPrefs.GetFloat("sliderMax", 25f);
        progressBar.value = PlayerPrefs.GetFloat("Score", 0);
        scoreText.text = PlayerPrefs.GetString("ScoreText", "0%");

        placeHolder.GetComponent<TMPro.TextMeshProUGUI>().text = PlayerPrefs.GetString("P_Name", "Player");
    }

    public void changeName()
    {
        PlayerPrefs.SetString("P_Name", Textname.GetComponent<TMPro.TextMeshProUGUI>().text);
    }
}
