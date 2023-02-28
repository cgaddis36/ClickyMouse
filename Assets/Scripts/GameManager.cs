using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isGameActive;
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;

    // Start is called before the first frame update
    void Start()
    {
        titleScreen.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        titleScreen.gameObject.SetActive(false);
        isGameActive = true;
        StartCoroutine(SpawnTarget(difficulty));
        UpdateScore(0);
    }

    public void RestartGame()
    {
        var currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }

    IEnumerator SpawnTarget(int difficulty)
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int randomTargetIndex = Random.Range(0, targets.Count); 
            GameObject randomTarget = targets[randomTargetIndex];
            Instantiate(randomTarget);
            UpdateScore(5);
        }
    }

    public void UpdateScore(int points)
    {
        score = score += points;
        scoreText.text = $"Score: {score}";
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

}
