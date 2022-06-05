using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrail : MonoBehaviour
{
    public float display_time = 0.1f;

    void Start()
    {
        StartCoroutine(SelfDestroy());
    }

    IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(display_time);
        GetComponent<LineRenderer>().enabled = false;
        Destroy(gameObject);

    }
}
