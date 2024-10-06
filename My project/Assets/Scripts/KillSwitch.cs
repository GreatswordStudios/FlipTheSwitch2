using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSwitch : MonoBehaviour
{
    int playerToKill = 0;
    public GameObject[] playerRefs;
    AudioSource audioData = null;
    public GameObject sceneRef;

    // Start is called before the first frame update
    void Start()
    {
        GameObject audioObject = GameObject.Find("switch sound");
        Debug.Log("Kill Switch");
        if (audioObject != null)
        {
            audioData = audioObject.GetComponent<AudioSource>();

            // Check if the AudioSource was found
            if (audioData != null)
            {
                Debug.Log("Audio Found");
            }
        }

        selectPlayerToRemove();   
    }

    // Update is called once per frame
    void Update()
    {
    }

    void selectPlayerToRemove()
    {
        if (playerRefs.Length > 0)
        {
            playerToKill = Random.Range(0, playerRefs.Length - 1);
        }
    }

    private void OnMouseDown()
    {
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Your code here

        //if (collision.gameObject.name == play)
        audioData.Play();
        GameObject playerToKillRef = playerRefs[playerToKill];
        Debug.Log(playerToKill + "is the target");
        if(collision.gameObject.name == playerToKillRef.gameObject.name)
        {
            playerRefs[playerToKill].GetComponent<PlayerMovement>().KillPlayer();
            sceneRef.GetComponent<SceneManager>().ReadPlayerAmount();
            sceneRef.GetComponent<SceneManager>().ChooseNextPlayer();
            Debug.Log("Player KILLED");
            UnityEngine.SceneManagement.SceneManager.LoadScene("House Wins");
        }
        else
        {
            sceneRef.GetComponent<SceneManager>().ChooseNextPlayer();
        }
        
    }
}
