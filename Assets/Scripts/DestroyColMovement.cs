using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyColMovement : MonoBehaviour
{
    public GameObject PM;
    void Update()
    {
        transform.position = new Vector3(PM.transform.position.x,
            transform.position.y,
            PM.transform.position.z);
    }
}
