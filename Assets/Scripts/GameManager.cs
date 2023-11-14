using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    [FormerlySerializedAs("prefabs")]
    public List<GameObject> Obstacleprefabs;
    public float obstacleInterval = 2f;
    public float obstacleSpeed = 6f;
    public Vector2 obstacleOffSetY = new Vector2(0, 4.5f);
    public float obstacleOffSetX = 25f;
    [HideInInspector]
    public int score = 0;
    private bool gameOver = false;
    

    void Awake()
    {
        //Singleton
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    public bool isGameOver()
    {
        return gameOver;
    }

    public bool isGameActive()
    {
        return !gameOver;
    }

    public void EndGame()
    {
        gameOver = true;
        Debug.Log("GameOver, your final score: " + score);
        StartCoroutine(ReloadScene(2));
    }

    private IEnumerator ReloadScene(float delay)
    {   
        //wait
        yield return new WaitForSeconds(delay);
        //Reload scene
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }
}
