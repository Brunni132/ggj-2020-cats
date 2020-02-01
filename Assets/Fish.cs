using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour, InteractableObject
{
    void InteractableObject.onCollidedWithCat(Cat cat)
    {
        cat.hasPickupFish = true;
        Destroy(this.gameObject);
    }
}
