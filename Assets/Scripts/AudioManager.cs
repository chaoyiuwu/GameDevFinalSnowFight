using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;

    [SerializeField] private AudioSource hitGoalSfx;
    [SerializeField] private AudioSource hitTreeSfx;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    public void playHitGoalSfx(Transform spawnTransform) {
        AudioSource audioSource = Instantiate(hitGoalSfx, spawnTransform.position, spawnTransform.rotation);
        audioSource.clip = hitGoalSfx.clip;
        audioSource.Play();
        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
    }

    public void playHitTreeSfx(Transform spawnTransform) {
        AudioSource audioSource = Instantiate(hitTreeSfx, spawnTransform.position, spawnTransform.rotation);
        audioSource.clip = hitTreeSfx.clip;
        audioSource.Play();
        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
    }
}
