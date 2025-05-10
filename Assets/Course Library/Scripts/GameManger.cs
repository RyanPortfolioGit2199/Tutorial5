using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    public List<GameObject> targets; //Lists let us pass in the type of thing we want, and array you have to declare what it is when you make it(?)
    private float spawnRate = 1.0f;
    private int score;
    public bool isGameActive; // A Bool to stop elements of the game when The GameOver method is called, made it public to trigger this bool outside of this script.
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)/// Using the isGameActive Bool to control this while loop when it GameOver method makes this bool false it will stop spawning targets. ------ A While Loop is a fusion of a For Loop and an If Statement, A While Loop will continually run the code but instead of giving it a defined number of times(Like a For Loop). It uses a condition(True/False) to stop running (Like an If Statement)
        {
            // Every 1 second(spawnRate) get a random number between 0 and the number of objects in the List, then spawn the object based on its number in the List.
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }

    }

    public void UpdateScore(int scoreToAdd)// Need to make it public so I can reference this methoed outside of this script.
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
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

    public void StartGame(int difficulty)
    {
        //Make sure to declare your variables before starting your methods in the Start Method because they are need for the methods to run.
        isGameActive = true;
        score = 0;

        spawnRate/= difficulty;

        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
    }
}
