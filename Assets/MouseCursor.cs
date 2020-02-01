using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = transform.position.z;
        this.transform.position = worldPos;


        if (Input.GetMouseButtonDown(0)) {
            foreach (Cat cat in FindObjectsOfType<Cat>()) {
                cat.laserWasClicked(worldPos);
            }
        }
    }
}
