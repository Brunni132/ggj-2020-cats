using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ScrollingBackgrounds : MonoBehaviour
{
    public Tilemap background1, background2, background3;
    private float scrolling = 0;

    // Update is called once per frame
    void Update()
    {
        scrolling += Time.deltaTime;

        scrollBg(background1, scrolling * 0.6f, 8);
        scrollBg(background2, scrolling * 0.5f, 8);
        scrollBg(background3, scrolling * 0.4f, 11);
    }

    private void scrollBg(Tilemap bg, float x, float planeSize) {
        var pos = bg.transform.localPosition;
        pos.x = -(x - Mathf.Floor(x / planeSize) * planeSize);
        bg.transform.localPosition = pos;
    }
}
