using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Flag Stats")]
    public bool hasFlag;
    public bool flagPlaced;

    public int scoreToWin;
    public int curScore;

    public bool gamePaused;

    // instance
    public static GameManager instance;

    void Awake()
    {
        // Set instance to this script
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Flag bools
        hasFlag = false;
        flagPlaced = false;

        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (flagPlaced)
        {
            //---------AddScore();
            WinGame();
        }

        if (Input.GetButtonDown("Cancel"))
        {
            TogglePauseGame();
        }
    }

    public void TogglePauseGame()
    {
        gamePaused = !gamePaused;
        Time.timeScale = gamePaused == true ? 0.0f : 1.0f;

        //Toggle the pause menu with the cursor
        //GameUI.instance.TogglePauseMenu(gamePaused);
        Cursor.lockState = gamePaused == true ? CursorLockMode.None : CursorLockMode.Locked;
    }
    
    public void PlaceFlag()
    {
        flagPlaced = true;
    }

    public void AddScore(int scoreToAdd)
    {
        curScore += scoreToAdd;

        //Update score text
        //GameUI.instance.UpdateScoretext(curScore);

        //If enough points, win
        if (curScore >= scoreToWin)
            WinGame();
    }

    void WinGame()
    {
        Debug.Log("The player has won the game!");
        //Time.timeScale = 0; //Freeze the game

        //Show win screen
        //GameUI.instance.SetEndGameScreen(true, curScore);
    }
}
