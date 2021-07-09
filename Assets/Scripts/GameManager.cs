using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static Camera Cam;
    public static GameManager manager;
    public int score;
    public Text ScoreText;
    public GameObject ninjaPlayer;
    public GameObject startMenu;
    public GameObject allKnife;
    public GameObject finishMenu;
    public GameObject deadMenu;
    public GameObject levelone;






    public enum GameState
    {
        Prepare,
        MainGame,
        Finish,
    }
    private GameState _currentGameState;

    public GameState CurrentGameState
    {
        get { return _currentGameState; }
        set
        {
            switch (value)
            {
                case GameState.Prepare:
                    startMenu.SetActive(true);



                    break;
                case GameState.MainGame:
                    startMenu.SetActive(false);


                    break;
                case GameState.Finish:
                    ninjaPlayer.SetActive(false);
                    break;
            }
            _currentGameState = value;
        }
    }

    private void Awake()
    {


        Cam = Camera.main;
        manager = this;

    }
    private void Start()
    {
    }
    private void Update()
    {
        switch (CurrentGameState)
        {
            case GameState.Prepare:
                allKnife.SetActive(false);
                ninjaPlayer.SetActive(false);
                finishMenu.SetActive(false);
                deadMenu.SetActive(false);
                levelone.SetActive(false);
                break;
            case GameState.MainGame:
                allKnife.SetActive(true);
                ninjaPlayer.SetActive(true);
                levelone.SetActive(true);

                break;
            case GameState.Finish:
                finishMenu.SetActive(true);


              
                break;
            default:
                throw new ArgumentOutOfRangeException();

        }
        
    }
    public void UpdateScore()
    {
        score++;
        ScoreText.text = score.ToString();
    }
    public void PlayButton()
    {
        CurrentGameState = GameState.MainGame;
    }
    public void BacktoMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void NextLevel2()
    {
        SceneManager.LoadScene(1);
    }
    public void NextLevel3()
    {
        SceneManager.LoadScene(2);
    }
   
    
}


