using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Button[] buttons;
    //Make sure button 0 is start button
    private void Start()
    {
        buttons[0].Select();
    }
    
    public void ChangeScene(string SceneName)
    {
        //Play animation?
        SceneManager.LoadScene(SceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
