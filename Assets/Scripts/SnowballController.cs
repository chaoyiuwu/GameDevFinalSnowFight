using UnityEngine;

public class SnowballController : MonoBehaviour {
    [Range(5.0f, 15.0f)]
    public float speed = 10.0f;

    [SerializeField] private float _timeToDestroy = 2.0f;

    private Rigidbody2D rb;
    
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, _timeToDestroy);
    }

    void Update() {
        ThrowSnowball();
    }

    private void ThrowSnowball() {
        transform.Translate(rb.linearVelocity * Time.deltaTime * speed);
    }

    
    private void OnTriggerEnter2D(Collider2D other) {

        switch (other.tag) {
            case "Tree":
                AudioManager.instance.playHitTreeSfx(transform);
                Destroy(gameObject);
                break;
            case "Snowman":
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }
}
