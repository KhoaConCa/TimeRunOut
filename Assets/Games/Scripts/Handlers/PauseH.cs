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
        Time.timeScale = 0f; // Dừng thời gian
    }

    public void ResumeGame()
    {
        pauseCommand.HidePauseMenu();
        Time.timeScale = 1f; // Tiếp tục thời gian
    }

    public void GoToHome()
    {
        Time.timeScale = 1f; // Đảm bảo thời gian trở lại bình thường trước khi về màn hình chính
        SceneManager.LoadScene("HomeScene"); // Thay thế "HomeSceneName" bằng tên cảnh Home của bạn
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Đảm bảo thời gian trở lại bình thường trước khi restart
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Tải lại cảnh hiện tại
    }

    public void StartGame()
    {
        Time.timeScale = 1f; // Đảm bảo thời gian trở lại bình thường trước khi restart
        SceneManager.LoadScene("Chapter1"); // Tải lại cảnh hiện tại
    }
    #endregion
}
