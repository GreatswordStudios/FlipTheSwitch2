using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;

public class PartyList : MonoBehaviour
{
    public TMP_InputField inputField;
    public TextMeshProUGUI[] displayTexts;
    private int currentTextIndex = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            SubmitInput(); 
            Debug.Log("Hit enter");
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
