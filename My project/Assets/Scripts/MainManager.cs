using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    private void Awake()
{
    // start of new code
    if (Instance != null)
    {
        Destroy(gameObject);
        return;
    }
    // end of new code

    Instance = this;
    DontDestroyOnLoad(gameObject);
}
        public TMP_InputField inputField;
    public TextMeshProUGUI[] displayTexts;
    private int currentTextIndex = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            SubmitInput(); 
            Debug.Log("Hit enter");
            ChangeSceneKeepData();
        }
    }

    public void SubmitInput()
    {
        if (currentTextIndex < displayTexts.Length)
        {
            string userInput = inputField.text;
            displayTexts[currentTextIndex].text = userInput;
            currentTextIndex++;
            inputField.text = "";
            if (currentTextIndex == displayTexts.Length)
            {
                Debug.Log("done");
                inputField.enabled = false; 
            }
        }
    }

    public void OnButtonClick()
    {
         Debug.Log("Button Pressed");
         inputField.enabled = false;
    }

    public void ChangeSceneKeepData()
    {
        if (currentTextIndex == 4 || inputField.enabled == false)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Selection");
            

        }
    }




}
