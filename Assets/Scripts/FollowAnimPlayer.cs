using UnityEngine;

public class FollowAnimPlayer : MonoBehaviour
{
    [SerializeField] GameObject animPlayer;
    void FixedUpdate()
    {
        transform.position = new Vector3(animPlayer.transform.position.x,
            transform.position.y,
            animPlayer.transform.position.z);
    }
}