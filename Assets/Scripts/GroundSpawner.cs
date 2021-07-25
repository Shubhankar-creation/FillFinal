using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject G_Prefab;
    public GameObject G_Holder;
    private GameObject groundInstance;

    public Transform groundColPos;

    public bool canSpawn;

    public float posX, posZ;
    private int k = 7;

    private Vector2 currGround;
    public Vector2[] allGroundPos;

    private canvasData changeGMat;

    private void Start()
    {
        changeGMat = GameObject.Find("canvasManager").GetComponent<canvasData>();

        allGroundPos = new Vector2[]
        {
            new Vector2(-1f, -1f),
            new Vector2(-1f, -1f),
            new Vector2(-1f, -1f),
            new Vector2(-1f, -1f),
            new Vector2(-1f, -1f),
            new Vector2(-1f, -1f),
            new Vector2(-1f, -1f),
            new Vector2(-1f, -1f)
        };

        GInstance();

        allGroundPos[k] = new Vector2(0f, 0f);
        k--;

        
    }

    private void OnTriggerEnter(Collider other)
    {
        string col = other.gameObject.tag;

        if(col == "G_F")
        {
            posX = 0f; posZ = 100f;

            checkGPos(other.gameObject.transform.parent);
            if(canSpawn)
            {
                GInstance();

            }

        }

        if (col == "G_B")
        {
            posX = 0f; posZ = -100f;

            checkGPos(other.gameObject.transform.parent);
            if (canSpawn)
            {
                GInstance();

            }
        }

        if (col == "G_R")
        {
            posX = 100f; posZ = 0f;

            checkGPos(other.gameObject.transform.parent);
            if (canSpawn)
            {
                GInstance();

            }
        }

        if (col == "G_L")
        {
            posX = -100f; posZ = 0f;

            checkGPos(other.gameObject.transform.parent);
            if (canSpawn)
            {
                GInstance();

            }
        }

        if (col == "G_FR")
        {
            posX = 100f; posZ = 100f;

            checkGPos(other.gameObject.transform.parent);
            if (canSpawn)
            {
                GInstance();

            }
        }

        if (col == "G_FL")
        {
            posX = -100f; posZ = 100f;

            checkGPos(other.gameObject.transform.parent);
            if (canSpawn)
            {
                GInstance();

            }
        }

        if (col == "G_BR")
        {
            posX = 100f; posZ = -100f;

            checkGPos(other.gameObject.transform.parent);
            if (canSpawn)
            {
                GInstance();

            }
        }

        if (col == "G_BL")
        {
            posX = -100f; posZ = -100f;

            checkGPos(other.gameObject.transform.parent);
            if (canSpawn)
            {
                GInstance();

            }
        }
    }

    void checkGPos(Transform GPos)
    {
        groundColPos = GPos;
        checkGroundPos(groundColPos.transform.position.x + posX, groundColPos.transform.position.z + posZ);
    }
    void checkGroundPos(float x, float y)
    {
        int flag = 0;
        currGround.x = x;
        currGround.y = y;

        for (int i = 0; i < 8; i++)
        {

            if (allGroundPos[i] == currGround)
            {

                canSpawn = false;
                return;
            }
            else
            {
                flag++;
            }
        }
        if (flag == 8)
        {
            allGroundPos[k] = currGround;
            canSpawn = true;
            if (k < 1) k = 7;
            k--;
        }
    }
    void GInstance()
    {
        groundInstance = Instantiate(G_Prefab,
                                new Vector3(groundColPos.transform.position.x + posX, 0f, groundColPos.transform.position.z + posZ), Quaternion.Euler(90f, 0f, 0f)) as GameObject;
        groundInstance.transform.parent = G_Holder.transform;

        groundInstance.GetComponent<MeshRenderer>().material = changeGMat.groundMaterials[changeGMat.randInd];

    }
}
