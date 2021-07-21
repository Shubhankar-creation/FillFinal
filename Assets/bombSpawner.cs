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
        yield return new WaitForSeconds(5f);
        instanceBomb();
    }
    
    void instanceBomb()
    {

        float newZ;

        if(playerPos.transform.localEulerAngles.y == 90 || playerPos.transform.localEulerAngles.y == 270)
        {
            return;
        }
        if (playerPos.transform.localEulerAngles.y > 49 && playerPos.transform.localEulerAngles.y <= 89)
        {
            float a = (playerPos.transform.localEulerAngles.y - 50) * 0.125f;
            newZ = 5 - a;
        }
        else if (playerPos.transform.localEulerAngles.y > 230 && playerPos.transform.localEulerAngles.y <= 269)
        {
            float a = (playerPos.transform.localEulerAngles.y - 230) * 0.125f;
            newZ = 5 - a;
        }
        else if(playerPos.transform.localEulerAngles.y > 90f && playerPos.transform.localEulerAngles.y <= 130)
        {
            float a = (130 - playerPos.transform.localEulerAngles.y) * 0.125f;
            newZ = 5 - a;
            Debug.Log(newZ);
        }
        else if (playerPos.transform.localEulerAngles.y > 270 && playerPos.transform.localEulerAngles.y <= 310)
        {
            float a = (310 - playerPos.transform.localEulerAngles.y) * 0.125f;
            newZ = 5 - a;
            Debug.Log(newZ);
        }
        else newZ = 7f;

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
}
