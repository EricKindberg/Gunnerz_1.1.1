using UnityEngine;
using System.Collections;

public class AnimatedTexture : MonoBehaviour
{
    [Range(0.1f, 1f)] public float timeBetweenFrames = 0.2f;
    public Texture2D[] frames;

    private int frameIndex = 0;
    private MeshRenderer rendererMy;


    Coroutine firingCoroutine;
    void Start()
    {
        rendererMy = GetComponent<MeshRenderer>();
        rendererMy.sortingLayerName = "Player";

        NextFrame();
        firingCoroutine = StartCoroutine(NextFrame());
    }

    IEnumerator NextFrame()
    {
        foreach(Texture frame in frames)
        {
            rendererMy.sharedMaterial.SetTexture("_MainTex", frame);
            yield return new WaitForSeconds(timeBetweenFrames);
        }

        SelfDestruct();

    }

    void SelfDestruct()
    {
        StopCoroutine(firingCoroutine);
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}