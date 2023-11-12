using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LevelSelect(int level)
    {
        switch(level)
        {
            case 1:
                SceneManager.LoadScene("Level01");
                break;
            case 2:
                SceneManager.LoadScene("Level02");
                break;
            case 3:
                SceneManager.LoadScene("Level03");
                break;
            default:
                Debug.Log("Invalid level number");
                break;
        }
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void ExitButton()
    {
        Debug.Log("Exited");
        Application.Quit();
    }
}
