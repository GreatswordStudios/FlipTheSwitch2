using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSwitch : MonoBehaviour
{
    string[] playerList = { };
    int playerToKill = 0;
    public GameObject[] playerRefs;
    AudioSource audioData = null;
    

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
            playerRefs = GameObject.FindGameObjectsWithTag("Player");
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
        Debug.Log("Collision Detected with: " );
        Debug.Log(collision.gameObject.name);
        audioData.Play();
        
    }
}
