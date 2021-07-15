using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Touch touch;
    private Rigidbody rb;

    public float forwardSpeed;
    public float slideSensitivity;
    public float rotationSensitivity;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void FixedUpdate()
    {

        if (rb.useGravity)
        {
            rb.drag = 0;
            rb.AddForce(new Vector3(0f, -1f, 1f));
        }
        else
        {
            rb.AddForce(transform.forward * forwardSpeed, ForceMode.VelocityChange);
        }
        sideWaysMovement();
    }

    void sideWaysMovement()
    {

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {

                // Making player Move sideways on touch
                float xSlide = transform.position.x + touch.deltaPosition.x * slideSensitivity;
                transform.position = new Vector3(xSlide, transform.position.y, transform.position.z);

                // Rotating the player based on sidewaysMovement
                transform.Rotate(Vector3.up * touch.deltaPosition.x / (rotationSensitivity * 10 + 10), Space.Self);

            }
        }
    }
}
