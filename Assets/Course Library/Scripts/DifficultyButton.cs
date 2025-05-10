using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private GameManger gameManger;
    public int difficulty;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty); // AddListener is a function in unity, to make the engine to pay attention for when a certain event has happened. In this case when a Difficulty Button is clicked run the SetDifficulty method.
        gameManger = GameObject.Find("Game Manager").GetComponent<GameManger>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDifficulty()
    {
        Debug.Log(button.gameObject.name + " was clicked.");
        gameManger.StartGame(difficulty); // When a Difficulty Button is pressed runs the Start Game method in the Game Manager Script to start the game.
    }
}
