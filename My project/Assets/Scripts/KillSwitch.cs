using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSwitch : MonoBehaviour
{
    string[] playerList = { };
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
        if (playerList.Length > 0)
        {
            playerToKill = Random.Range(0, playerList.Length - 1);
        }
    }

    private void OnMouseDown()
    {
    }

    void FlipSwitch(int PlayerEnum, int PTK)
    {
        if (PlayerEnum == PTK)
        {

        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Your code here

        //if (collision.gameObject.name == play)
        audioData.Play();
        GameObject playerToKillRef = playerRefs[playerToKill];
        if(collision.gameObject.name == playerToKillRef.gameObject.name)
        {
            sceneRef.GetComponent<SceneManager>().KillPlayer();
        }
        else
        {
             sceneRef.GetComponent<SceneManager>().ChooseNextPlayer();
        }
        
    }
}
