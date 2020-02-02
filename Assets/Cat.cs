using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public const float BLOCK_SIZE = 1;
    public GameObject leftCollider, rightCollider, bottomCollider, bottomCollider2;
    public SpriteRenderer catSprite;
    public float diesAfterDrowningForSeconds = 20;
    public int direction = 1; // initial direction
    public float catVelocity = 1;
    public Color catColor;
    public SpriteRenderer fishIcon, helpIcon;
    internal bool hasPickupFish = false;
    private float drowningForSeconds = 0;
    private const int wallLayer = 1 << 8;

    public Rigidbody2D rigidBody {
        get { return GetComponent<Rigidbody2D>(); }
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<SpriteRenderer>().color = catColor;
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
            direction = +1;
        }
        if (collides(rightCollider)) {
            direction = -1;
        }

        if (drowningForSeconds > 0) {
            drowningForSeconds += Time.deltaTime;
			if (drowningForSeconds > diesAfterDrowningForSeconds) {
                SceneManager.LoadScene("LoseGame");
            }
        }

        catSprite.transform.localScale = new Vector3(direction, 1, 1);
        fishIcon.gameObject.SetActive(hasPickupFish);
        helpIcon.color = Color.Lerp(Color.white,
            Color.Lerp(Color.yellow, Color.red, 2 * drowningForSeconds / diesAfterDrowningForSeconds - 0.5f),
            2 * drowningForSeconds / diesAfterDrowningForSeconds);
        helpIcon.gameObject.SetActive(drowningForSeconds > 0 && drowningForSeconds - Mathf.Floor(drowningForSeconds) < 0.8f);
    }

    // Overrides
    private void OnCollisionEnter2D(Collision2D other) {
        var cat = other.gameObject.GetComponent<Cat>();
        if (cat != null) {
            cat.collidedWithCat(this);
        }
        var interactable = other.gameObject.GetComponent<InteractableObject>();
        if (interactable != null) {
            interactable.onCollidedWithCat(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        var interactable = other.gameObject.GetComponent<InteractableObject>();
        if (interactable != null) {
            interactable.onCollidedWithCat(this);
        }
    }

    // Notifications
    public bool laserWasClicked(Vector3 worldPosition)
    {
        if (Math.Abs(worldPosition.y - transform.position.y) < BLOCK_SIZE) {
            direction = worldPosition.x > transform.position.x ? +1 : -1;
            return true;
        }
        return false;
    }

    public void collidedWithCat(Cat otherCat) {
        SceneManager.LoadScene("GameFinished");
    }

    public void notifyWaterLevel(float level) {
        if (transform.position.y < level) {
            drowningForSeconds = Mathf.Max(0.01f, drowningForSeconds);
        } else {
            drowningForSeconds = 0;
        }
    }

    // Private
    private bool collides(GameObject obj) {
        return Physics2D.OverlapCircle(obj.transform.position, 0.01f, wallLayer);
    }
}
