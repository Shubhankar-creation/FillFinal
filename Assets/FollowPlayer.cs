using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] PlayerMovement PM;
    void Update()
    {
        transform.position = new Vector3(PM.transform.position.x,
            transform.position.y,
            PM.transform.position.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, PM.transform.rotation, 0.1f);
    }
}