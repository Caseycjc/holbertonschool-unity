using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu: MonoBehaviour
{
    public static int lastScene =0;
    public bool isInverted;


    public void Apply()
    {
        // Save the isInverted setting when Apply is clicked
        PlayerPrefs.SetInt("InvertY", isInverted ? 1 : 0);

        // Go back to the previous scene
        SceneManager.LoadScene(PlayerPrefs.GetString("PreviousScene"));
    }

public void Back()
    {
        SceneManager.LoadScene(OptionsMenu.lastScene);
    }
}
