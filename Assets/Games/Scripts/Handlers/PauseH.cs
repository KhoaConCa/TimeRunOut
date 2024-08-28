using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseH : MonoBehaviour
{
    #region Fields
    [SerializeField] private PauseC pauseCommand;
    #endregion

    #region Methods
    public void PauseGame()
    {
        pauseCommand.ShowPauseMenu();
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        pauseCommand.HidePauseMenu();
        Time.timeScale = 1f;
    }

    public void GoToHome()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("HomeScene");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Chapter1");
    }
    #endregion
}
