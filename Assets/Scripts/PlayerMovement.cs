using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    private Touch touch;
    private Rigidbody rb;

    public float forwardSpeed;
    public float slideSensitivity;
    public float rotationSensitivity;

    private ParticleSystem bombExplosion;
    private bool playerSafe = false;

    private bool fallRotation = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void FixedUpdate()
    {

        if (rb.useGravity)
        {
            rb.drag = 0;
            rb.AddForce(new Vector3(0f, -1f, 0f));
        }
        else
        {
            rb.AddForce(transform.forward * forwardSpeed, ForceMode.VelocityChange);
        }
        sideWaysMovement();

        if(fallRotation)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0f, transform.rotation.y, 50f)), 0.1f);
        }
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
                transform.Rotate(Vector3.up * touch.deltaPosition.x / (rotationSensitivity * 10 + 10), Space.World);

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Hole"))
        {
            rb.useGravity = true;
            fallRotation = true;
        }
        else if (other.gameObject.CompareTag("Bomb"))
        {
            playerSafe = false;
            StartCoroutine("exploseionWait");
            Debug.Log("PlayerUnsafe");
            bombExplosion = other.gameObject.GetComponentInChildren<ParticleSystem>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Bomb"))
        {
            playerSafe = true;
            Debug.Log("PlayerSafe");
        }
    }

    IEnumerator exploseionWait()
    {
        yield return new WaitForSeconds(3f);
        if(!playerSafe)  bombExplosion.Play();
        if (!playerSafe)
        {
            forwardSpeed = 0f;
            StartCoroutine("RestartGame");
        }
    }
    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(2f);
        playerSafe = false;
        SceneManager.LoadScene(0);
    }
}
