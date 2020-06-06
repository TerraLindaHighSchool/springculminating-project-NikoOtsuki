using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI timerText;
    public float targetTime = 30.0f;
    public bool isGameActive;
    public Button restartButton;
    public GameObject titleScreen;
    public TextMeshProUGUI winText;
    public Button mainMenuButton;

    public GameObject[] obstaclesPrefabs;
    private float spawnRangeX = -7;
    private float spawnPosZ = 9;
    private float startDelay = 0.5f;
    private float spawnInterval;
    Transform[] spawnpoints;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomObstacle", startDelay, spawnInterval);
        titleScreen.gameObject.SetActive(true);
        isGameActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        while (isGameActive)
        {
            targetTime -= Time.deltaTime;
            timerText.text = "Time Left: " + targetTime;
        }
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartLevel(float difficulty)
    {
        isGameActive = true;
        spawnInterval = spawnInterval / difficulty;
        titleScreen.gameObject.SetActive(false);
        timerText.text = "Time Left: " + targetTime;
        timerText.gameObject.SetActive(true);
    }

    public void WinLevel()
    {
        if (targetTime <= 0.0f)
        {
            isGameActive = false;
            winText.gameObject.SetActive(true);
            mainMenuButton.gameObject.SetActive(true);
        }
    }

    void SpawnRandomObstacle()
    {
        while (isGameActive)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            int obstacleIndex = Random.Range(0, obstaclesPrefabs.Length);
            Instantiate(obstaclesPrefabs[obstacleIndex], spawnPos, obstaclesPrefabs[obstacleIndex].transform.rotation);
        }
    }
}
