using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{

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


        bool affectedSomeone = false;
        Color cursorColor = Color.white;

        if (Input.GetMouseButton(0)) {
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
                        cursorColor = cat.catColor;
                        affectedSomeone = true;
                    }
                }
            }
        }

        transform.localScale = new Vector3(affectedSomeone ? 2 : 1, affectedSomeone ? 2 : 1, 1);
        setLaserColor(cursorColor);
    }
}
