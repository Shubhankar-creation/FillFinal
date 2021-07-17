using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Manageuiandmat : MonoBehaviour
{
    public int score = 0;
    public int level = 1;
    public Text getLevel;
    public Text getScore;
    public Slider progressBar;
    private float fillSpeed = 0.75f;
    void Start()
    {
        getLevel.text = "Level " + level;
    }

    void Update()
    {
        
        if(progressBar.value < score)
        {
            progressBar.value += fillSpeed * Time.deltaTime;
        }
    }
}
