using System.Collections;
using UnityEngine;

public class ShapeSpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject allyShape;
    public GameObject EnemShape;
    public Vector3 playerPos;
    private void Start()
    {
        InstanceShape();
    }

    private void Update()
    {
        playerPos = player.transform.position;
    }
    IEnumerator waitShapeSpawn()
    {
        yield return new WaitForSeconds(4f);
        InstanceShape();
    }

    private void InstanceShape()
    {
        for (int i = 0; i < 4; i++)
        {
            Vector3 newPos = new Vector3(Random.Range(playerPos.x - 3.5f, playerPos.x + 10f),
                0.125f,
                Random.Range(playerPos.z + 10f, playerPos.z + 20f));

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
}
