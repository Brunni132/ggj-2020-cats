using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour, InteractableObject
{
    public float jumpImpulse;

    void InteractableObject.onCollidedWithCat(Cat cat)
    {
        var vel = cat.rigidBody.velocity;
        vel.y = jumpImpulse;
        cat.rigidBody.velocity = vel;
    }
}
