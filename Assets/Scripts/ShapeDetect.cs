using UnityEngine;

public class ShapeDetect : MonoBehaviour
{
    private Manageuiandmat scoreUpdate;

    private void Start()
    {
        scoreUpdate = GameObject.Find("UI/MatManager").GetComponent<Manageuiandmat>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("AllyShape"))
        {
            scoreUpdate.score += (scoreUpdate.progressBar.maxValue / 100f);
            scoreUpdate.getScore.text = scoreUpdate.score + "%";
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("EnemyShape"))
        {
            if(scoreUpdate.score < 0)
            {
                Debug.Log("Quit Game");
            }
            else
            {
                scoreUpdate.score -= (scoreUpdate.progressBar.maxValue / 100f);
                scoreUpdate.getScore.text = scoreUpdate.score + "%";
            }
            Destroy(other.gameObject);
        }
        scoreUpdate.progressBar.value = scoreUpdate.score;
    }
}
