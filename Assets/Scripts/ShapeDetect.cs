using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeDetect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("AllyShape"))
        {
            Debug.Log("Points should be awared");
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("EnemyShape"))
        {
            Debug.Log("Points should be deduced");
            Destroy(other.gameObject);
        }
    }
}
