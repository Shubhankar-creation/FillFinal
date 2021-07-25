using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnetInstantiate : MonoBehaviour
{

    public GameObject magnetPrefab;

    private GameObject newMagnet;
    private canvasData getLevel;
    private float playerRot;
    private Vector3 playerPos;
    void Start()
    {
        getLevel = GameObject.Find("canvasManager").GetComponent<canvasData>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        playerRot = GameObject.FindGameObjectWithTag("Player").transform.localEulerAngles.y;
        StartCoroutine("spawnMagnet");
    }

    private void Update()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        playerRot = GameObject.FindGameObjectWithTag("Player").transform.localEulerAngles.y;
    }

    IEnumerator spawnMagnet()
    {
        float randomTime = Random.Range(40f, 60f);
        yield return new WaitForSeconds(randomTime);
        if(getLevel.level % 2 == 0)
            instanceMagnet();
    }

    void instanceMagnet()
    {
        float newZ;

        if (playerRot == 90 || playerRot == 270)
        {
            return;
        }
        if (playerRot > 49 && playerRot <= 89)
        {
            float a = (playerRot - 50) * 0.125f;
            newZ = 5 - a;
        }
        else if (playerRot > 230 && playerRot <= 269)
        {
            float a = (playerRot - 230) * 0.125f;
            newZ = 5 - a;
        }
        else if (playerRot > 90f && playerRot <= 130)
        {
            float a = (130 - playerRot) * 0.125f;
            newZ = 5 - a;
            Debug.Log(newZ);
        }
        else if (playerRot > 270 && playerRot <= 310)
        {
            float a = (310 - playerRot) * 0.125f;
            newZ = 5 - a;
            Debug.Log(newZ);
        }
        else newZ = 7f;

        newZ = getZval(newZ);
        float m = Mathf.Tan(playerRot * Mathf.PI / 180);
        Debug.Log("Radian value is " + playerRot * Mathf.PI / 180);
        Debug.Log("Tan thetha value is " + m);
        float newX = newZ * m;
        Vector3 magnetPos = new Vector3(playerPos.x + newX, 0.3f, playerPos.z + newZ);
        newMagnet = Instantiate(magnetPrefab, magnetPos, Quaternion.identity) as GameObject;
        newMagnet.transform.parent = transform;
        StartCoroutine("spawnMagnet");
    }

    float getZval(float z)
    {
        if (playerRot >= 90f && playerRot <= 270f)
        {
            z = -z;
        }
        return z;
    }
}
