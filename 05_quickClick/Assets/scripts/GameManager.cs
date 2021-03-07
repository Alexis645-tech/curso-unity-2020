using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private const string MAX_SCORE = "Max_Score";
    
    public List<GameObject> targetPrefabs;

    private float spawnRate = 1.5f;

    public TextMeshProUGUI scoreText;

    private int _score;

    public TextMeshProUGUI gameOverText;
    
    private int score
    {
        set
        {
            _score = Mathf.Clamp(value, 0, 9999);
        }
        get
        {
            return _score;
        }
    }

    public enum GameState
    {
        loading,
        inGame,
        paused,
        gameOver
    }

    public GameState gameState;

    public Button restartButton;

    public GameObject titleScreen;

    private int numberOfLives = 4;

    public List<GameObject> lives;
    
    void Start()
    {
        ShowMaxScore();
    }

    /// <summary>
    /// Método que inicia la partida cambiando el valor del estado del juego
    /// </summary>
    /// <param name="difficulty">Número entero que indica la dificultad del juego</param>
    public void StartGame(int difficulty)
    {
        gameState = GameState.inGame;
        titleScreen.gameObject.SetActive(false);
        spawnRate /= difficulty;
        numberOfLives -= difficulty;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
        
        for (int i = 0; i < numberOfLives; i++)
        {
            lives[i].SetActive(true);
        }
    } 

    IEnumerator SpawnTarget()
    {
        while (gameState == GameState.inGame)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targetPrefabs.Count);
            Instantiate(targetPrefabs[index]);
        }
    }

    /// <summary>
    /// Actualiza la puntuación y lo muestra por pantalla
    /// </summary>
    /// <param name="scoreToAdd">Número de puntos a añadir a la puntuación global</param>
    /// <param name="scoreToAdd"></param>
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Puntuacion: " + score;
    }

    public void ShowMaxScore()
    {
        int maxScore = PlayerPrefs.GetInt(MAX_SCORE, 0);
        scoreText.text = "Maxima Puntuacion: " + maxScore;
    }

    private void SetMaxScore()
    {
        int maxSocore = PlayerPrefs.GetInt(MAX_SCORE, 0);
        if (score > maxSocore)
        {
            PlayerPrefs.SetInt(MAX_SCORE, score);
        }
    }
    
    public void GameOver()
    {
        numberOfLives--;
        if (numberOfLives>=0)
        {
            Image heartImage = lives[numberOfLives].GetComponent<Image>();
            var tempColor = heartImage.color;
            tempColor.a = 0.3f;
            heartImage.color = tempColor;
        }
        
        if (numberOfLives<=0)
        {
            SetMaxScore();
            gameState = GameState.gameOver;
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
