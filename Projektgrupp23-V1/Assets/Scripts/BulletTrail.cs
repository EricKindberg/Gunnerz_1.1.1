using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrail : MonoBehaviour
{
    [SerializeField] float displayTime = 0.1f;

    void Start()
    {
        StartCoroutine(SelfDestroy());
    }

    IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(displayTime);
        GetComponent<LineRenderer>().enabled = false;
        Destroy(gameObject);

    }
}
