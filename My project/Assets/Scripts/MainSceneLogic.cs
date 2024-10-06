using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;
using System.ComponentModel;

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
    public TextMeshProUGUI turncounter;
    public TextMeshProUGUI timercounter;
    public TextMeshProUGUI[] healthcounter;
    public TextMeshProUGUI[] namedisplay;


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
        UpdateTurnCounter();
        UpdateHealthCounter();
        UpdatePlayerName();
    }

    // Update is called once per frame
    void Update()
    {
       if (!timerpaused)
        {
            CountTimerDown();
            UpdateTimerCounter();
        }
    }

    void CheckTurnCount() 
    {
        if (RemainingTurns > 0 && PlayersRemaining > 1) {

            RemainingTurns--;
            currentPlayer++;
            UpdateTurnCounter();
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
        if (RemainingTime > 0 && RemainingTurns > 0)
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

    void UpdateTurnCounter()
    {
        turncounter.SetText(RemainingTurns + "/" + TotalTurnCount);
    }

    void UpdateTimerCounter()
    {
        int secs = Convert.ToInt32(RemainingTime);
        timercounter.SetText("Time:" + secs );
    }

    void UpdateHealthCounter()
    {
        List<int> currentplayerhealth = new List<int>();
        List<int> totalplayerHealth = new List<int>();
        for (int i =0; i < playerRefs.Length; ++i)
        {
            currentplayerhealth.Add(playerRefs[i].GetComponent<PlayerMovement>().currentHealth);
            totalplayerHealth.Add(playerRefs[i].GetComponent<PlayerMovement>().maxHealth);
        }
        currentplayerhealth.ToArray();
        for (int i = 0; i < healthcounter.Length; ++i)
        {
            healthcounter[i].SetText(currentplayerhealth[i].ToString() + " / " + totalplayerHealth[i].ToString());
        }
    }

    void UpdatePlayerName()
    {
        List<string> playernames = new List<string>();
       for (int i = 0; i < playerRefs.Length; ++i)
        {
            playernames.Add(playerRefs[i].GetComponent<PlayerMovement>().name);
        }
       playernames.ToArray();
        for (int i = 0; i < namedisplay.Length; ++i)
        {
            namedisplay[i].SetText(playernames[i]);
        }
    }
}
