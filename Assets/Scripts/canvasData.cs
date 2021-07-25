using UnityEngine;
using UnityEngine.UI;
public class canvasData : MonoBehaviour
{
    public float score = 0;

    public int level = 1;
    public int randInd = 0;
    public int levelTextColor = 0;
    public Text getLevel;
    public Text getScore;

    public Slider progressBar;

    public Material[] groundMaterials;
    
    void Start()
    {

        getLevel.text = "Level " + PlayerPrefs.GetInt("Scenelevel", 1).ToString();
        level = PlayerPrefs.GetInt("Scenelevel", 1);
        levelTextColor = PlayerPrefs.GetInt("levelColor", 0);
        if(levelTextColor == 0)
        {
            getLevel.color = Color.black;
        }
        else
        {
            getLevel.color = Color.white;
        }
        randInd = PlayerPrefs.GetInt("materialInd", 0);
       
    }

    void Update()
    {

        if (score >= progressBar.maxValue)
        {
            gettingnewMaterials();
            changingProgressBar();
        }
    }

    private void changingProgressBar()
    {
        getLevel.text = "Level " + ++level;
        getScore.text = "0%";
        progressBar.value = 0f;
        progressBar.maxValue += level * 10;
        score = 0f;
        if (randInd % 2 == 0)
        {
            getLevel.color = Color.black;
            levelTextColor = 0;
        }
        else
        {
            getLevel.color = Color.white;
            levelTextColor = 1;
        }
    }
    void gettingnewMaterials()
    {
        getInd(randInd);
        changeInitialSpawnObj();
    }

    void getInd(int i)
    {
        while(randInd == i)     randInd = Random.Range(0, groundMaterials.Length);
    }
    void changeInitialSpawnObj()
    {
        GameObject[] allGround = GameObject.FindGameObjectsWithTag("Ground");

        foreach(GameObject g in allGround)
        {
            g.GetComponent<MeshRenderer>().material = groundMaterials[randInd];
        }
        GameObject[] allHoles = GameObject.FindGameObjectsWithTag("Hole");

        foreach(GameObject hole in allHoles)
        {
            if(randInd % 2 == 0)    hole.GetComponent<MeshRenderer>().material = groundMaterials[1];
            else    hole.GetComponent<MeshRenderer>().material = groundMaterials[0];
        }
    }

}
