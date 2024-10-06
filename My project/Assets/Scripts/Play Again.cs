using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayAgain : MonoBehaviour
{
    // Start is called before the first frame update
   public Button Replay;
    public void OnButtonClick() 
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Player Sign In");
    }
      
    
}
