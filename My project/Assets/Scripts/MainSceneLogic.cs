using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.SceneManagement;
using System;

public class SceneManager : MonoBehaviour
{
    int NumPlayers = 1;
    int PlayersRemaining = 0;
    int TotalTurnCount = 5;
    int RemainingTurns = 1;
    float TimePerTurn = 15f;
    float RemainingTime = 20f;
    GameObject[] playerRefs;
    GameObject[] playerStarts;
    static int currentPlayer = 0;
    bool timerpaused = false;


    static bool pauseTimer = true;
    // Start is called before the first frame update
    void Start()
    {
       InitializePlayerState();
    }

    void InitializePlayerState()
    {
        playerRefs = GameObject.FindGameObjectsWithTag("Player");
        playerStarts = GameObject.FindGameObjectsWithTag("Start");
        currentPlayer = 0;
        ResetPlayerLocations();
        PlayersRemaining = playerRefs.Length - 1;
        NumPlayers = playerRefs.Length;
        TotalTurnCount = NumPlayers - 1;
        RemainingTurns = TotalTurnCount;
        RemainingTime = TimePerTurn;
        Debug.Log(RemainingTurns);
        Debug.Log(currentPlayer);
        DisableOrEnablePlayers();
    }

    // Update is called once per frame
    void Update()
    {
       if (!timerpaused)
        {
            CountTimerDown();
            Debug.Log(RemainingTime);
        }
    }

    void CheckTurnCount() 
    {
        if (RemainingTurns > 0 && PlayersRemaining > 1) {

            RemainingTurns--;
            currentPlayer++;
            ResetPlayerLocations();
            DisableOrEnablePlayers();
            resetTheTimer();
        }
        else {
            Debug.Log("House Wins");
        }
    }

    void CountTimerDown()
    {
        if (RemainingTime > 0)
        {
            RemainingTime -= (2*Time.deltaTime);
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
        timerpaused = true;
    }

    void resetTheTimer()
    {
        RemainingTime = TimePerTurn;
        timerpaused = false;
    }

    void ResetPlayerLocations()
    {
        for (int i = 0; i < playerRefs.Length; i++)
        {
            if (playerRefs[i].transform.position != playerStarts[i].transform.position)
            {
                playerRefs[i].transform.Translate(playerStarts[i].transform.position);
            }
        }
    }
    void DisableOrEnablePlayers()
    {
        for (int i = 0; i < playerRefs.Length; i++)
        {
            if (i != currentPlayer)
            {
                playerRefs[i].GetComponent<PlayerMovement>().isActivePlayer = false;
                Debug.Log(playerRefs[i] + "is not the player" + i);
            }
            else
            {
                playerRefs[i].GetComponent<PlayerMovement>().isActivePlayer = true;
                Debug.Log(playerRefs[i] + "is the player" + i);
            }
        }
    }

    void StartNextTurn() { }
    void BeginFailPhase() { }
}
