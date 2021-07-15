using UnityEngine;
using System.Collections;

public class EnemyFollow : MonoBehaviour
{

    Transform tr_Player;
    float f_RotSpeed = 3.0f, f_MoveSpeed = 2.0f;

    public float MobDist = 30f;
    private float currTime, targetTime = 20f;

    // Use this for initialization
    void Start()
    {

        tr_Player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        float distance = Vector3.Distance(tr_Player.position, transform.position);
        if ((distance < MobDist) && (currTime < targetTime) && (tr_Player.transform.position.y == 0))
        {
            /* Look at Player*/
            transform.rotation = Quaternion.Slerp(transform.rotation
                                                  , Quaternion.LookRotation(tr_Player.position - transform.position)
                                                  , f_RotSpeed * Time.deltaTime);

            /* Move at Player*/
            transform.position += transform.forward * f_MoveSpeed * Time.deltaTime;
            currTime += Time.deltaTime;
        }
        else
        {
            StartCoroutine("waitForEnemyFollow");
        }
    }

    IEnumerator waitForEnemyFollow()
    {
        yield return new WaitForSeconds(15f);
        currTime = 0f;
    }
}