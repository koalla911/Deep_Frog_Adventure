using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tongue : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private int resolution, waveCount, wobbleCount;
    [SerializeField] private float waveSize, animSpeed;

    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(AnimateTongue(target.position));
        }
    }


    private IEnumerator AnimateTongue(Vector3 targetPos)
    {
        lineRenderer.positionCount = resolution;

        float percent = 0;
        while (percent <= 1f)
        {
            percent += Time.deltaTime * animSpeed;
            SetPoints(targetPos, percent);
            yield return null;
        }

        SetPoints(targetPos, 1);
    }

    private void SetPoints(Vector3 targetPos, float percent)
    {
        Vector3 tongueEnd = Vector3.Lerp(transform.position, targetPos, percent);
        float length = Vector2.Distance(transform.position, tongueEnd);

        for (int i = 0; i < resolution; i++)
        {
            float horizontalPosition = (float) i / resolution * length;
            float reversePercent = (i - percent);

            float amplitude = Mathf.Sin(reversePercent * wobbleCount * Mathf.PI); 

            float verticalPosition = Mathf.Sin((float) waveCount * i / resolution * 2 * Mathf.PI * reversePercent) * amplitude;
            Vector2 pos = new Vector2(horizontalPosition, verticalPosition);
            lineRenderer.SetPosition(i, pos);       
        }
    }

}
