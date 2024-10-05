using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
<<<<<<< Updated upstream
    int NumPlayers = 1;
    int PlayersRemaining = 0;
    int TurnCount = 1;
    int TotalTurnCount = 5;
    int RemainingTurns = 1;
    float TimePerTurn = 20f;
    float RemainingTime = 20f;
    bool pauseTimer = false;
=======
    static int NumPlayers = 1;
    static int PlayersRemaining = 0;
    static int TurnCount = 1;
    static int TotalTurnCount = 5;
    static int RemainingTurns = 1;
    static float TimePerTurn = 20f;
    static float RemainingTime = 20f;
>>>>>>> Stashed changes
    // Start is called before the first frame update
    void Start()
    {
        TurnCount = NumPlayers - 1;
        TimePerTurn *= (1 / Time.deltaTime);
        TotalTurnCount = RemainingTurns;
    }

    // Update is called once per frame
    void Update()
    {
       if (pauseTimer)
        {
            CountTimerDown();
        }
    }

    static void CheckTurnCount() 
    {
        if (RemainingTurns > 0 && PlayersRemaining > 1) {

            RemainingTurns--;
            StartNextTurn();
        }
        else { 
            BeginFailPhase();
        }
    }

<<<<<<< Updated upstream
    private void ResetTurnTimer()
    {
        RemainingTime = TimePerTurn;
    }

    private void CountTimerDown()
    {
        if (RemainingTime > 0)
        {
            RemainingTime = TimePerTurn - Time.deltaTime;
        }
        else
        {
            pauseTheTimer();
            RemainingTime = 0;
            CheckTurnCount();
        }
    }

    void pauseTheTimer()
    {
        pauseTimer = true;
    }

    void resumeTheTimer()
    {
        pauseTimer = false;
    }

void StartNextTurn() { }
    void BeginFailPhase() { }
=======
    static void StartNextTurn() { }
    static void BeginFailPhase() { }
>>>>>>> Stashed changes
}
