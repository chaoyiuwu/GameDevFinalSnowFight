using UnityEngine;

public class GoalController : MonoBehaviour {
    [SerializeField] private float _timeToDestroy = 4.0f;

    void Start() {
        Destroy(gameObject, _timeToDestroy);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Snowball")) {
            UIManager.Instance.updateScore();
            AudioManager.instance.playHitGoalSfx(transform);
            Destroy(gameObject);
        }
    }
}
