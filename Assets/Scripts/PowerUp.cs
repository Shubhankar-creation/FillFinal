using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private PlayerMovement pm;
    float distance;
    private void Start()
    {
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        distance = Vector3.Distance(pm.transform.position, transform.position);
    }
    private void FixedUpdate()
    {
        if (pm.canAttract && distance < 10f)
        {
            attractShape();
        }
    }

    void attractShape()
    {
        transform.position = Vector3.Lerp(transform.position, pm.transform.position, 7f * Time.deltaTime);
    }
}
