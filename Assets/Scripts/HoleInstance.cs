using System.Collections;
using UnityEngine;

public class HoleInstance : MonoBehaviour
{
    private GameObject HoleParent;
    private GameObject hole3dparent;
    private GameObject newHole;
    private GroundSpawner respawnColDetect;
    private float xVal, zVal;

    public GameObject HoleShape;

    private canvasData changeHMat;
    private void Start()
    {
        changeHMat = GameObject.Find("canvasManager").GetComponent<canvasData>();
        respawnColDetect = GameObject.FindGameObjectWithTag("Player").GetComponent<GroundSpawner>();
        for (int i = 0; i < 4; i++)
        {
            HoleCreation();
        }
    }

    private void Update()
    {
        HoleCreate();
    }

    private void HoleCreate()
    {


        if (respawnColDetect.canSpawn)
        {
            for (int i = 0; i < 4; i++)
            {
                HoleCreation();
            }
            respawnColDetect.canSpawn = false;
        }
    }

    void HoleCreation()
    {
        HoleParent = new GameObject("HoleParent");
        HoleParent.transform.parent = transform;

        randomPos(respawnColDetect.groundColPos.position.x + respawnColDetect.posX, respawnColDetect.groundColPos.position.z + respawnColDetect.posZ);

        newHole = Instantiate(HoleShape, new Vector3(xVal, 0f, zVal), Quaternion.identity) as GameObject;
        newHole.tag = "Hole";
        newHole.transform.parent = HoleParent.transform;

        if(PlayerPrefs.GetInt("materialInd") % 2 == 0)
        {
            newHole.GetComponent<MeshRenderer>().material = changeHMat.groundMaterials[1];
        }
        else
        {
            newHole.GetComponent<MeshRenderer>().material = changeHMat.groundMaterials[0];
        }

        newHole.AddComponent<EnemyFollow>();
        newHole.AddComponent<waitDestroyHole>();

    }
    void randomPos(float x, float y)
    {

        if (xVal < 0)
        {
            xVal = Random.Range(x - 50f, x + 50f);
            zVal = Random.Range(y, y + 50f);
        }
        else
        {
            xVal = Random.Range(x - 50f, x + 50f);
            zVal = Random.Range(y - 50f, y);
        }

    }
}
