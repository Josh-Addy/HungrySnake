using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public GameState State;
    // public static GameManager Instance { get { return instance; } }
    public static event Action<GameState> onGameStateChanged;
    void Awake() {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }
    }  
    void Start() {
        
    }
     public void UpdateGameState(GameState newState) {
         State = newState;
          switch (newState)
          {
            case GameState.PlayScreenMM:
                
                break;
            case GameState.StartScreen:
                pressKeyScreen();
                break;
            case GameState.PlayScreen:
                break;
            case GameState.GameOver:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState),newState, null);
          }

          onGameStateChanged.Invoke(newState);
     }
     private void pressKeyScreen() {

     }
     private void pressPlayKeyMM() {
         
     }
     public void playClassic() {
         SceneManager.LoadScene("Classic_Snake");
     }
     public void quitGame() {
         Application.Quit();
     }
}

public enum GameState {
    PlayScreenMM,
    StartScreen,
    PlayScreen,
    GameOver
}


