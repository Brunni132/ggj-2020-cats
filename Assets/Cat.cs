using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public const float BLOCK_SIZE = 1;
    public GameObject leftCollider, rightCollider, bottomCollider, bottomCollider2;
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
        // if (collides(bottomCollider) || collides(bottomCollider2) || rigidBody.velocity.y > 0) {
            var pos = transform.position;
            pos.x += catVelocity * direction * Time.deltaTime;
            transform.position = pos;
        // }

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

    // Overrides
    private void OnCollisionEnter2D(Collision2D other) {
        var cat = other.gameObject.GetComponent<Cat>();
        if (cat != null) {
            cat.collidedWithCat(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        var interactable = other.gameObject.GetComponent<InteractableObject>();
        if (interactable != null) {
            interactable.onCollidedWithCat(this);
        }
    }

    // Notifications
    public void laserWasClicked(Vector3 worldPosition)
    {
        if (Math.Abs(worldPosition.y - transform.position.y) < BLOCK_SIZE) {
            direction = worldPosition.x > transform.position.x ? +1 : -1;
        }
    }

    public void collidedWithCat(Cat otherCat) {
        UnityEngine.Debug.LogWarningFormat("TEMP win");
        SceneManager.LoadScene("GameFinished");
    }

    // Private
    private bool collides(GameObject obj) {
        return Physics2D.OverlapCircle(obj.transform.position, 0.01f, wallLayer);
    }
}
