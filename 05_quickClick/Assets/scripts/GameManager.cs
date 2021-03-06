using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targetPrefabs;

    private float spawnRate = 1.0f;

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
    
    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.inGame;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void GameOver()
    {
        gameState = GameState.gameOver;
        gameOverText.gameObject.SetActive(true);
    }
}
