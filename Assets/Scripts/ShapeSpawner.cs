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

        xPos.x = -4f; xPos.y = 4f;
        zPos.x = 0f; zPos.y = 10f;

        InstanceShape();
    }

    private void Update()
    {
        playerPos = player.transform.position;
        playerRot = player.transform.localEulerAngles.y;
    }

    private void getSpawnPos()
    {
        if (playerRot >= 0f && playerRot < 90f)
        {

            xPos.x = -2f; xPos.y = 15f;
            zPos.x = 10f; zPos.y = 20f;
        }
        else if (playerRot >= 90f && playerRot < 180f)
        {

            xPos.x = -2f; xPos.y = 15f;
            zPos.x = -10f; zPos.y = -20f;
        }
        else if (playerRot >= -180 && playerRot < -90)
        {

            xPos.x = -15f; xPos.y = 2f;
            zPos.x = -10f; zPos.y = -20f;
        }
        else if (playerRot >= -90 && playerRot < 0)
        {

            xPos.x = -15f; xPos.y = 2f;
            zPos.x = 10f; zPos.y = 20f;
        }
    }

    private void InstanceShape()
    {
        for (int i = 0; i < 4; i++)
        {
            Vector3 newPos = new Vector3(Random.Range(playerPos.x + xPos.x, playerPos.x + xPos.y),
                0.125f,
                Random.Range(playerPos.z + zPos.x, playerPos.z + zPos.y));

            GameObject newShape;
            if (i == 2)
            {
                newShape = Instantiate(EnemShape, newPos, Quaternion.identity) as GameObject;
            }
            else
            {
                newShape = Instantiate(allyShape, newPos, Quaternion.identity) as GameObject;
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
