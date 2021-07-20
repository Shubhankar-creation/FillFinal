using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombSpawner : MonoBehaviour
{
    public GameObject Bomb;
    public Transform playerPos;

    private GameObject newBomb;
    void Start()
    {
        instanceBomb();
    }

    IEnumerator SpawnBomb()
    {
        yield return new WaitForSeconds(10f);
        instanceBomb();
        //destroyBomb();
    }
    
    void instanceBomb()
    {
        if(playerPos.transform.localEulerAngles.y > 74f && playerPos.transform.localEulerAngles.y <= 106f 
            && playerPos.transform.localEulerAngles.y > 254f && playerPos.transform.localEulerAngles.y <= 286f)
        {
            return;
        }
        float newZ = Random.Range(12f, 15f);
        newZ = getZval(newZ);
        float m = Mathf.Tan(playerPos.localEulerAngles.y * Mathf.PI / 180);
        Debug.Log("Radian value is " + playerPos.localEulerAngles.y * Mathf.PI / 180);
        Debug.Log("Tan thetha value is " + m);
        float newX = newZ * m;
        Vector3 bombPos = new Vector3(playerPos.transform.position.x + newX, 1f, playerPos.transform.position.z + newZ);
        newBomb = Instantiate(Bomb, bombPos, Quaternion.identity) as GameObject;
        newBomb.transform.parent = transform;
        StartCoroutine("SpawnBomb");
    }
    float getZval(float z)
    {
        if(playerPos.transform.localEulerAngles.y >= 90f && playerPos.transform.localEulerAngles.y <= 270f)
        {
            z = -z;
        }        
        return z;
    }

    /*
    void destroyBomb()
    {
        float distance = Vector3.Distance(playerPos.transform.position, newBomb.transform.position);
        if(distance > 15f)
        {
            Debug.Log("Destroyed GameObject");
            Destroy(newBomb);
        }
    }
    */
}
