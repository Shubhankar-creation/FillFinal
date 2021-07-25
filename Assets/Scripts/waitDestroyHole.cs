using System.Collections;
using UnityEngine;

public class waitDestroyHole : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("waitDestroy");
    }

    IEnumerator waitDestroy()
    {
        yield return new WaitForSeconds(40f);
        Destroy(this.transform.parent.gameObject);
    }

}
