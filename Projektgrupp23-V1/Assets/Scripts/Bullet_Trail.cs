using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Trail : MonoBehaviour
{
    // Start is called before the first frame update

    public float display_time = 0.1f;

    void Start()
    {
        StartCoroutine(Self_destory());
    }

    IEnumerator Self_destory()
    {
        yield return new WaitForSeconds(display_time);
        GetComponent<LineRenderer>().enabled = false;
        Destroy(gameObject);

    }
}
