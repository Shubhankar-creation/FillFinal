using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class mainMenuCanvas : MonoBehaviour
{
    private canvasData playerData;
    public GameObject Textname;
    public GameObject placeHolder;

    public Slider progressBar;

    private void Start()
    {
        playerData = GetComponent<canvasData>();

        placeHolder.GetComponent<TMPro.TextMeshProUGUI>().text = PlayerPrefs.GetString("P_Name", "Player");
    }

    public void changeName()
    {
        PlayerPrefs.SetString("P_Name", Textname.GetComponent<TMPro.TextMeshProUGUI>().text);
    }
}
