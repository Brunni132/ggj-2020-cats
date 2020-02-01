using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public GameObject leftCollider, rightCollider, bottomCollider;
    public SpriteRenderer catSprite;
    public int direction = 1; // initial direction
    public float catVelocity = 1;
    private const int wallLayer = 1 << 8;

    public Rigidbody2D rigidBody {
        get { return GetComponent<Rigidbody2D>(); }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        pos.x += catVelocity * direction * Time.deltaTime;
        transform.position = pos;

        if (collides(leftCollider)) {
            UnityEngine.Debug.LogWarningFormat("TEMP left");
            direction = +1;
        }
        if (collides(rightCollider)) {
            UnityEngine.Debug.LogWarningFormat("TEMP right");
            direction = -1;
        }

        catSprite.transform.localScale = new Vector3(direction, 1, 1);
    }

    private bool collides(GameObject obj) {
        return Physics2D.OverlapCircle(obj.transform.position, 0.01f, wallLayer);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        var interactable = other.gameObject.GetComponent<InteractableObject>();
        if (interactable != null) {
            interactable.onCollidedWithCat(this);
        }
    }
}
