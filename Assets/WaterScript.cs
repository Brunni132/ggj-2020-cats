using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WaterScript : MonoBehaviour {
    private float angle = 0;
    public float waterLevel = -11;
    public Tilemap waterTilemap;
    private Cat[] cats;

    void Start() {
        cats = FindObjectsOfType<Cat>();
    }

    // Update is called once per frame
    void Update() {
        var pos = waterTilemap.transform.position;
        pos.y = waterLevel + Mathf.Sin(angle) * 0.2f;
        pos.x = Mathf.Cos(angle) * 0.6f;
        waterTilemap.transform.position = pos;

        waterLevel += 0.1f * Time.deltaTime;
        angle -= 8.0f * Time.deltaTime;

        foreach (Cat cat in cats) {
            cat.notifyWaterLevel(waterLevel);
        }
    }
}
