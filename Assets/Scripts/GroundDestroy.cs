using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDestroy : MonoBehaviour
{
    private GroundSpawner getvectorPos;
    public GameObject PM;
    void Update()
    {
        transform.position = new Vector3(PM.transform.position.x,
            transform.position.y,
            PM.transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {

        GameObject GPrefab = other.gameObject.transform.parent.gameObject;
        getvectorPos = PM.GetComponent<GroundSpawner>();

        if(GPrefab.layer == LayerMask.NameToLayer("Ground"))
        {
            Vector2 currGround = new Vector2(GPrefab.transform.position.x, GPrefab.transform.position.z);
            for(int i = 0; i<8; i++)
            {
                if (currGround == getvectorPos.allGroundPos[i])
                {
                    getvectorPos.allGroundPos[i] = new Vector2(0f, 0f);
                }
            }
            Destroy(GPrefab);
        }
    }
}
