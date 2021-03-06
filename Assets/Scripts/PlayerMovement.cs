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
    private Animator anim;

    private ParticleSystem bombExplosion;
    private bool playerSafe = false;

    private bool fallRotation = false;

    private canvasData playerData;
    public bool canAttract;

    private AudioSource bombAud;
    public AudioClip bombClip;

    private void Start()
    {
        playerData = GameObject.Find("canvasManager").GetComponent<canvasData>();
        bombAud = GetComponent<AudioSource>();
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
            anim = other.gameObject.GetComponent<Animator>();
            anim.SetBool("canExplode", true);
            playerSafe = false;
            StartCoroutine("exploseionWait");
            bombExplosion = other.gameObject.GetComponentInChildren<ParticleSystem>();
        }
        else if(other.gameObject.CompareTag("Magnet"))
        {
            canAttract = true;
            Destroy(other.gameObject);
            StartCoroutine("magnetLimit");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Bomb"))
        {
            anim = other.gameObject.GetComponent<Animator>();
            anim.SetBool("canExplode", false);
            playerSafe = true;
        }
    }

    IEnumerator magnetLimit()
    {
        yield return new WaitForSeconds(10f);
        canAttract = false;
    }
    IEnumerator exploseionWait()
    {
        yield return new WaitForSeconds(0.5f);
        if (!playerSafe)
        {
            bombExplosion.Play();
            bombAud.clip = bombClip;
            bombAud.Play();
        }
        if (!playerSafe)
        {
            forwardSpeed = 0f;
            rb.useGravity = true;
            StartCoroutine("RestartGame");
        }
    }
    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(1.5f);
        PlayerPrefs.SetInt("Scenelevel", playerData.level);
        PlayerPrefs.SetInt("materialInd", playerData.randInd);
        PlayerPrefs.SetInt("levelColor", playerData.levelTextColor);
        PlayerPrefs.SetFloat("Score", playerData.progressBar.value);
        PlayerPrefs.SetFloat("sliderMax", playerData.progressBar.maxValue);
        PlayerPrefs.SetString("ScoreText", playerData.getScore.text);
        SceneManager.LoadScene(0);
    }
}
