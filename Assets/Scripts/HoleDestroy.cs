using UnityEngine;

public class HoleDestroy : MonoBehaviour
{
    [SerializeField] GameObject PM;
    void Update()
    {
        transform.position = new Vector3(PM.transform.position.x,
            transform.position.y,
            PM.transform.position.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, PM.transform.rotation, 0.1f);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hole"))
        {
            Destroy(other.gameObject.transform.parent.gameObject);
        }
        if(other.gameObject.CompareTag("Bomb"))
        {
            Destroy(other.gameObject);
        }
    }
}
