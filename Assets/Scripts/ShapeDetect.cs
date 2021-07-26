using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShapeDetect : MonoBehaviour
{
    private canvasData scoreUpdate;
    public Animator anim;

    private AudioSource coin;
    public AudioClip coinCollect;

    private void Start()
    {
        scoreUpdate = GameObject.Find("canvasManager").GetComponent<canvasData>();
        coin = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("AllyShape"))
        {
            scoreUpdate.score++;
            scoreUpdate.getScore.text = Mathf.Round(scoreUpdate.score * (100f / scoreUpdate.progressBar.maxValue) * 10) / 10 + "%";
            coin.clip = coinCollect;
            coin.Play();
            Destroy(other.gameObject);
            anim.SetBool("shapeCol", true);
            StartCoroutine("shapeWait");
        }
        else if (other.gameObject.CompareTag("EnemyShape"))
        {
            coin.clip = coinCollect;
            coin.Play();
            if (scoreUpdate.score <= 0)
            {
                StartCoroutine("waitBeforeExit");
            }
            else
            {
                scoreUpdate.score -= 2;
                scoreUpdate.getScore.text = Mathf.Round((scoreUpdate.score * (100f / scoreUpdate.progressBar.maxValue) * 10) / 10) + "%";
            }
            Destroy(other.gameObject);
            anim.SetBool("shapeCol", true);
            StartCoroutine("shapeWait");
        }
        scoreUpdate.progressBar.value = scoreUpdate.score;
    }

    IEnumerator waitBeforeExit()
    {

        yield return new WaitForSeconds(1.5f);
        PlayerPrefs.SetInt("Scenelevel", scoreUpdate.level);
        PlayerPrefs.SetInt("materialInd", scoreUpdate.randInd);
        PlayerPrefs.SetInt("levelColor", scoreUpdate.levelTextColor);
        PlayerPrefs.SetFloat("Score", scoreUpdate.score);
        SceneManager.LoadScene(0);
    }
    IEnumerator shapeWait()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("shapeCol", false);
    }
}
