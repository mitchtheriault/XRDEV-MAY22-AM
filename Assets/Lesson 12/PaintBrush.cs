using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBrush : MonoBehaviour
{
    public Transform paintTrailPrefab;

    public Transform paintBrushTip;

    private Transform currentTrail;

    private bool colorSelected = false;

    public void StartPainting()
    {
        //instantiate a trail renderer, make the parent the paint brush tip
        if (colorSelected == true)
        {
            currentTrail = Instantiate(paintTrailPrefab, paintBrushTip);
            currentTrail.GetComponent<TrailRenderer>().material.color = paintBrushTip.GetComponent<Renderer>().material.color;
        }
    }

    public void StopPainting()
    {
        //set the instantiated trail renderer's parent to null
        currentTrail.parent = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        Renderer paintSampleRenderer = other.GetComponent<Renderer>();

        if (paintSampleRenderer != null)
        {
            paintBrushTip.GetComponent<Renderer>().material.color = paintSampleRenderer.material.color;
        }

        if (colorSelected == false)
        {
            colorSelected = true;
        }
    }
}
