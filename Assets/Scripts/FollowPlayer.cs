using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] PlayerMovement PM;
    void FixedUpdate()
    {
        transform.position = new Vector3(PM.transform.position.x,
            transform.position.y,
            PM.transform.position.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.x, PM.transform.localEulerAngles.y, transform.rotation.x), 0.1f);
    }
}