using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrownRotate : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * 180 * Time.deltaTime);
    }
}
