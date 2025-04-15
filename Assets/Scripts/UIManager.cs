using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour {
    public static UIManager Instance { get; private set; }

    private const int MAIN_MENU = 0;
    public TextMeshProUGUI scoreText;
    public GameObject GameOverMenu;
    private int score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        if (Instance != null) {
            Destroy(gameObject);
        }
        Instance = this;
        GameOverMenu.SetActive(false);
        score = 0;
        updateScore(0);
        StartCoroutine(GameOver());
    }

    public void updateScore(int scoreToAdd = 1) {
        score += scoreToAdd;
        scoreText.text = score.ToString();
    }

    
    public void RestartLevel() {
        // Restart the current level
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public IEnumerator GameOver() {
        yield return new WaitForSeconds(20);
        Time.timeScale = 0;
        GameOverMenu.SetActive(true);
    }

        public void GoToMainMenu() {
        // Load the main menu
        SceneManager.LoadScene(MAIN_MENU);
    }

}
