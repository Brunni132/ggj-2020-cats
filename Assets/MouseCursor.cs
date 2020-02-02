using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    private static Color DEFAULT_POINTER_COLOR = Color.white;
    private Color pointerColor = DEFAULT_POINTER_COLOR;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    void setLaserColor(Color color) {
        GetComponent<SpriteRenderer>().color = color;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = transform.position.z;
        this.transform.position = worldPos;

        if (Input.GetMouseButtonUp(0)) {
            pointerColor = DEFAULT_POINTER_COLOR;
        }

        if (Input.GetMouseButtonDown(0)) {
            bool affectedSomeone = false;
            foreach (Spring spring in FindObjectsOfType<Spring>()) {
                if (spring.hits(worldPos)) {
                    spring.laserDown(worldPos);
                    affectedSomeone = true;
                    break;
                }
            }

            if (!affectedSomeone) {
                foreach (Cat cat in FindObjectsOfType<Cat>()) {
                    if (cat.laserWasClicked(worldPos)) {
                        pointerColor = cat.catColor;
                        affectedSomeone = true;
                    }
                }
            }
        }

        bool nonDefaultColor = pointerColor != DEFAULT_POINTER_COLOR;
        transform.localScale = new Vector3(nonDefaultColor ? 2 : 1, nonDefaultColor ? 2 : 1, 1);
        setLaserColor(pointerColor);
    }
}
