using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] const string MAIN_MENU_NAME = "MainMenu";
    [SerializeField] const string LEVEL_ONE_NAME = "LevelOne";


    public void MainMenu()
    {
        SceneManager.LoadScene(MAIN_MENU_NAME);
    }

    public void LoadLevelOne()
    {
        SceneManager.LoadScene(LEVEL_ONE_NAME);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
