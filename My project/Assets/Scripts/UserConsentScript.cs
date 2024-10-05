
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserConsentScript : MonoBehaviour
{
    public Text playerPromptText;  // Text to show which player is being asked
    public Button yesButton;  // Yes button
    public Button noButton;   // No button

    private int totalPlayers = 5;  // Total number of players
    private int currentPlayer = 0; // Index for current player being asked
    private bool[] consentResults; // Array to store consent (true = Yes, false = No)


    void Start()
    {
        // Initialize consent results
        consentResults = new bool[totalPlayers];

        // Start asking for consent from the first player
        //AskConsentFromPlayer(currentPlayer);

        // Attach listeners to buttons
        yesButton.onClick.AddListener(() => OnConsentGiven(true));
        noButton.onClick.AddListener(() => OnConsentGiven(false));
    }

    void update()
    {
        
    }
    // Function to prompt a player for consent
    //void AskConsentFromPlayer(int playerIndex)
    //{
    //    playerPromptText.text = "Player " + (playerIndex + 1) + ", do you consent?";
    //}

    // Called when a player gives their consent
    void OnConsentGiven(bool consent)
    {
        // Store the player's consent (true for Yes, false for No)
        consentResults[currentPlayer] = consent;

        // Move to the next player
        currentPlayer++;
        Debug.Log("It worked " );

        if (currentPlayer < totalPlayers)
        {
            // Ask the next player for consent
     //       AskConsentFromPlayer(currentPlayer);
        }
        else
        {
            // All players have been asked, aggregate the results
            AggregateConsentResults();
        }
    }

    // Function to aggregate the consent results and take further action
    void AggregateConsentResults()
    {
        int yesCount = 0;
        int noCount = 0;

        foreach (bool consent in consentResults)
        {
            if (consent)
                yesCount++;
            else
                noCount++;
        }

        // Example: Display aggregated result in the console
        Debug.Log("Total Yes: " + yesCount);
        Debug.Log("Total No: " + noCount);

        // Take further action based on the aggregated results
        // For example: Load the next scene or display a final message
    }
}
