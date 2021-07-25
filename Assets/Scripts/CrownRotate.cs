using UnityEngine;

public class CrownRotate : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Rotate(Vector3.up * 180 * Time.deltaTime);
    }
}
