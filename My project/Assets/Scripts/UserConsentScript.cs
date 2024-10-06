
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserConsentScript : MonoBehaviour
{
    public Text playerPromptText;  // Text to show which player is being asked
    public Button yesButton;  // Yes button
    public Button noButton;   // No button

    private int totalPlayers = 4;  // Total number of players
    private int currentPlayer = 0; // Index for current player being asked
    private bool[] consentResults; // Array to store consent (true = Yes, false = No)

    public int numclicks = 0;

    private bool isInvisible = false;

    public GameObject[] makevisible;


    void Start()
    {
        // Initialize consent results
        consentResults = new bool[totalPlayers];

        // Start asking for consent from the first player
        //AskConsentFromPlayer(currentPlayer);

        // Attach listeners to buttons
        if(!isInvisible)
        {
            yesButton.onClick.AddListener(() => OnConsentGiven(true));
            noButton.onClick.AddListener(() => OnConsentGiven(false));
        }
        for (int i = 0; i < makevisible.Length; i++)
    {
        Renderer renderer = makevisible[i].GetComponent<Renderer>();

        if (renderer != null)
        {
            Material mat = renderer.material;

            Color color = mat.color;
            color.a = 1f; // Set alpha to 0 (fully transparent)
            mat.color = color;

            Debug.Log(makevisible[i].name + " transparency changed to invisible");
        }

    }
    }

    void Update()
    {
        
    }
    // Function to prompt a player for consent
    //void AskConsentFromPlayer(int playerIndex)
    //{
    //    playerPromptText.text = "Player " + (playerIndex + 1) + ", do you consent?";
    //}

    // Called when a player gives their consent
    public void ButtonFinallyClicked()
{
    Debug.Log("Button Clicked");

    // Iterate over each player object and change transparency
    for (int i = 0; i < makevisible.Length; i++)
    {
        Renderer renderer = makevisible[i].GetComponent<Renderer>();

        if (renderer != null)
        {
            // Ensure the material uses a shader that supports transparency
            Material mat = renderer.material;

            Color color = mat.color;
            color.a = 0f; // Set alpha to 1 (fully visible)
            mat.color = color;

            Debug.Log(makevisible[i].name + " transparency changed to visible");
        }
    }
    UnityEngine.SceneManagement.SceneManager.LoadScene("Selection");

}

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
            yesButton.interactable = false;
            noButton.interactable = false;
            Debug.Log("running AggregateConsentResults()");


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
        Debug.Log("yescount "+yesCount);
        Debug.Log("nocount "+noCount);

        if (yesCount>noCount)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("FlipTheSwitchMain");
            //transition to main scene
        }
        else{
            Debug.Log("Players lose");
            UnityEngine.SceneManagement.SceneManager.LoadScene("Player Sign In");
        }

        // Example: Display aggregated result in the console
        Debug.Log("Total Yes: " + yesCount);
        Debug.Log("Total No: " + noCount);

        // Take further action based on the aggregated results
        // For example: Load the next scene or display a final message
    }
}
