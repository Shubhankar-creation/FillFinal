using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Manageuiandmat : MonoBehaviour
{
    public float score = 0;

    public int level = 1;
    public int randInd = 0;

    public Text getLevel;
    public Text getScore;

    public Slider progressBar;

    public Material[] groundMaterials;

    void Start()
    {
        getLevel.text = "Level " + level;
    }

    void Update()
    {
        if(score >= 100f)
        {
            changingProgressBar();
            gettingnewMaterials();
        }
    }

    private void changingProgressBar()
    {
        getLevel.text = "Level " + ++level;
        getScore.text = "0%";
        progressBar.value = 0f;
        score = 0f;
        if(level % 2 == 0) getLevel.color = Color.white;
    }
    void gettingnewMaterials()
    {
        getInd(randInd);
        changeInitialSpawnObj();
    }

    void getInd(int i)
    {
        while(randInd == i)     randInd = Random.Range(0, 2);
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
            hole.GetComponent<MeshRenderer>().material = groundMaterials[1 - randInd];
        }
    }
}
