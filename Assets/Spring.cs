using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour, InteractableObject
{
    public float jumpImpulse;
    private bool isLaserDown;

    void InteractableObject.onCollidedWithCat(Cat cat)
    {
        var vel = cat.rigidBody.velocity;
        vel.y = jumpImpulse;
        cat.rigidBody.velocity = vel;
    }

    public bool hits(Vector3 worldPosition) {
        Collider2D foundElement = Physics2D.OverlapBox(worldPosition, new Vector2(1, 1), 0);
        if (foundElement && foundElement.GetComponent<Spring>()) return true;
        return false;
    }

    public void laserDown(Vector3 worldPosition) {
        isLaserDown = true;
    }

    public void Update() {
        isLaserDown = isLaserDown && Input.GetMouseButton(0);
        if (isLaserDown) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = transform.position.z;
            transform.position = mousePos;
        }
    }
}
