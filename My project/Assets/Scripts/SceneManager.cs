using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    int NumPlayers = 1;
    int PlayersRemaining = 0;
    int TurnCount = 1;
    int TotalTurnCount = 5;
    int RemainingTurns = 1;
    float TimePerTurn = 20f;
    float RemainingTime = 20f;
    bool pauseTimer = false;
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

    void CheckTurnCount() 
    {
        if (RemainingTurns > 0 && PlayersRemaining > 1) {

            RemainingTurns--;
            StartNextTurn();
        }
        else { 
            BeginFailPhase();
        }
    }

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
}
