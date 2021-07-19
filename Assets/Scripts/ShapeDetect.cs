using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeDetect : MonoBehaviour
{
    private Manageuiandmat scoreUpdate;
    public Animator anim;
    private void Start()
    {
        scoreUpdate = GameObject.Find("UI/MatManager").GetComponent<Manageuiandmat>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("AllyShape"))
        {
            scoreUpdate.score++;
            scoreUpdate.getScore.text = Mathf.Round(scoreUpdate.score * (100f / scoreUpdate.progressBar.maxValue) * 10) / 10 + "%";
            Destroy(other.gameObject);
            anim.SetBool("shapeCol", true);
            StartCoroutine("shapeWait");
        }
        else if (other.gameObject.CompareTag("EnemyShape"))
        {
            if(scoreUpdate.score < 0)
            {
                Debug.Log("Quit Game");
            }
            else
            {
                scoreUpdate.score--;
                scoreUpdate.getScore.text = Mathf.Round((scoreUpdate.score * (100f / scoreUpdate.progressBar.maxValue) * 10) / 10) + "%";
            }
            Destroy(other.gameObject);
            anim.SetBool("shapeCol", true);
            StartCoroutine("shapeWait");
        }
        scoreUpdate.progressBar.value = scoreUpdate.score;
    }
    IEnumerator shapeWait()
    {
        yield return new WaitForSeconds(1f);
        anim.SetBool("shapeCol", false);
    }
}
