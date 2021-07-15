using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeDestroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("AllyShape") || other.gameObject.CompareTag("EnemyShape"))
        {
            Destroy(other.gameObject);
        }
    }
}
