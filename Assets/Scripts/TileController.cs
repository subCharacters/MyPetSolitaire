using UnityEngine;
using System.Collections;

public class TileController : MonoBehaviour
{
    public int tileId;
    public int x, y, z;

    private bool isSelected = false;
    private Vector3 defaultScale;
    private Coroutine pulseRoutine;
    private SpriteRenderer sr;

    private void Awake()
    {
        defaultScale = transform.localScale;
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        if (!isSelected)
        {
            isSelected = true;
            transform.localScale = defaultScale * 1.1f;
            pulseRoutine = StartCoroutine(PulseAnimation());
        }
        else
        {
            isSelected = false;
            transform.localScale = defaultScale;
            if (pulseRoutine != null)
                StopCoroutine(pulseRoutine);
        }
    }

    private IEnumerator PulseAnimation()
    {
        float time = 0f;
        float duration = 0.5f;
        float minScale = 1.1f;
        float maxScale = 1.2f;

        while (true)
        {
            time += Time.deltaTime;
            float scaleFactor = Mathf.Lerp(minScale, maxScale, (Mathf.Sin(time * Mathf.PI * 2f / duration) + 1f) / 2f);
            transform.localScale = defaultScale * scaleFactor;
            yield return null;
        }
    }

    public void SetColor(Color color)
    {
        if (sr == null)
            sr = GetComponent<SpriteRenderer>();
        sr.color = color;
    }
}
