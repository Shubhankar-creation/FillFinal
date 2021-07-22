using System.Collections;
using UnityEngine;

public class ShapeSpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject allyShape;
    public GameObject EnemShape;

    private Vector3 playerPos;
    private float playerRot;
    private Vector2 xPos, zPos;

    private void Start()
    {
        playerRot = player.transform.localEulerAngles.y;
        playerPos = player.transform.position;

        xPos.x = 0; xPos.y = 10f;
        zPos.x = 5f; zPos.y = 10f;

        InstanceShape();
    }

    private void Update()
    {
        playerPos = player.transform.position;
        playerRot = player.transform.localEulerAngles.y;
    }

    private void getSpawnPos()
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
        float newX = newZ * m;
        if(playerRot > 180 && playerRot < 360)
        {
            xPos.x = newX -14f; xPos.y = newX - 7f;
        }
        else
        {
            xPos.x = newX ; xPos.y = newX + 7f;
        }
    }

    float getZval(float z)
    {
        if (playerRot >= 90f && playerRot <= 270f)
        {
            z = -z;
            zPos.x = z; zPos.y = z - 5f;
        }
        else
        {
            zPos.x = z ; zPos.y = z + 5f;
        }
        return z;
    }
    private void InstanceShape()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector3 newPos = new Vector3(Random.Range(playerPos.x + xPos.x, playerPos.x + xPos.y),
                0.125f,
                Random.Range(playerPos.z + zPos.x, playerPos.z + zPos.y));

            GameObject newShape;
            if (i % 2 != 0)
            {
                newShape = Instantiate(EnemShape, newPos, Quaternion.identity) as GameObject;
            }
            else
            {
                newShape = Instantiate(allyShape, newPos, Quaternion.identity) as GameObject;
                newShape.AddComponent<PowerUp>();
            }

            newShape.transform.parent = this.transform;
        }
        StartCoroutine("waitShapeSpawn");
    }
    IEnumerator waitShapeSpawn()
    {
        yield return new WaitForSeconds(2f);
        getSpawnPos();
        InstanceShape();
    }
}
