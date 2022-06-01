using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class LevelManager : MonoBehaviour
{
    // This might not work as i intend but want to test
    [Tooltip("String needs to match level name in editor")]
    [SerializeField] const string MAIN_MENU_NAME = "MainMenu";
    [SerializeField] const string LEVEL_ONE_NAME = "LevelOne";

    [Tooltip("This is the Pause Menu Canvas")]
    [SerializeField] GameObject pauseMenu;

    bool isPaused = false;

    KibblesInSpace _controls;

    
    private void Awake()
    {
        _controls = new KibblesInSpace();
    }

    private void OnEnable()
    {
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

    private void Start()
    {
        //Event binding to function. '_' means we arent passing any parameters to function
        _controls.UI.PauseMenu.performed += _ => DetermineIfPaused();
    }

    #region Menu Buttons
    public void MainMenu()
    {
        SceneManager.LoadScene(MAIN_MENU_NAME);
    }

    void DetermineIfPaused()
    {
        if (isPaused) 
            Resume();
        else
            Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0;
        isPaused = true;
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        isPaused = false;
        pauseMenu.SetActive(false);
    }

    public void Quit()
    {
        //if in editor will close out of play mode else will quit
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    #endregion Menu Buttons

    #region Levels
    public void LoadLevelOne()
    {
        SceneManager.LoadScene(LEVEL_ONE_NAME);
    }

    #endregion Levels

}
