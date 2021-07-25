using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDestroy : MonoBehaviour
{
    [SerializeField] PlayerMovement PM;
    private canvasData playerData;
    void start()
    {
        playerData = GameObject.Find("canvasManager").GetComponent<canvasData>();
    }
    void Update()
    {
        transform.position = new Vector3(PM.transform.position.x,
            transform.position.y,
            PM.transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        playerData = GameObject.Find("canvasManager").GetComponent<canvasData>();

        if (other.gameObject.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("Scenelevel", playerData.level);
            PlayerPrefs.SetInt("materialInd", playerData.randInd);
            PlayerPrefs.SetInt("levelColor", playerData.levelTextColor);
            SceneManager.LoadScene(0);
        }
    }
}
