using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzelFlash : MonoBehaviour
{
    [Range(0.1f, 1f)] public float timeBetweenFrames = 1f;
    public Texture2D[] frames;

    private int frameIndex = 0;
    private MeshRenderer rendererMy;


    Coroutine firingCoroutine;
    private bool CR_running = false;

    void Start()
    {
        rendererMy = GetComponent<MeshRenderer>();
        rendererMy.sortingLayerName = "Player";
        rendererMy.sharedMaterial.SetTexture("_MainTex", frames[0]);
        rendererMy.enabled = false;
    }

    public void ResetAnimation()
    {
        if(CR_running)
        {
            StopCoroutine(firingCoroutine);
        }
        Animate();
    }

    void Animate()
    {
        rendererMy.enabled = true;
        rendererMy.sharedMaterial.SetTexture("_MainTex", frames[0]);

        NextFrame();
        firingCoroutine = StartCoroutine(NextFrame());
    }

    IEnumerator NextFrame()
    {
        CR_running = true;

        foreach (Texture frame in frames)
        {
            rendererMy.sharedMaterial.SetTexture("_MainTex", frame);
            yield return new WaitForSeconds(timeBetweenFrames);
        }
        rendererMy.enabled = false;
        CR_running = false;
        //SelfDestruct();

    }

    void SelfDestruct()
    {
        StopCoroutine(firingCoroutine);
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
