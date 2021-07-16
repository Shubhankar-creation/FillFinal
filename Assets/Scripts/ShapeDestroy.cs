using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeDestroy : MonoBehaviour
{
    [SerializeField] PlayerMovement PM;
    void Update()
    {
        transform.position = new Vector3(PM.transform.position.x,
            transform.position.y,
            PM.transform.position.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, PM.transform.rotation, 0.1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("AllyShape") || other.gameObject.CompareTag("EnemyShape"))
        {
            Destroy(other.gameObject);
        }
    }
}
