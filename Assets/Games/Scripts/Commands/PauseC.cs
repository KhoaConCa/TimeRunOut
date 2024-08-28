using UnityEngine;

public class PauseC : MonoBehaviour
{
    #region Fields
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private PauseH pauseHandler;
    [SerializeField] private ShootH shootHandler;

    #region iOS
    [SerializeField] private GameObject moveJoystick;
    [SerializeField] private GameObject shootJoystick;
    #endregion

    #endregion

    #region Methods
    public void OnPauseButtonClick()
    {
        shootHandler.StopShoot();
        pauseHandler.PauseGame();
    }

    public void OnResumeButtonClick()
    {
        shootHandler.StopShoot();
        pauseHandler.ResumeGame();
    }

    public void OnHomeButtonClick()
    {
        shootHandler.StopShoot();
        pauseHandler.GoToHome();
    }

    public void OnRestartButtonClick()
    {
        shootHandler.StopShoot();
        pauseHandler.RestartGame();
    }

    public void ShowPauseMenu()
    {
        pauseMenuUI.SetActive(true);
        moveJoystick.SetActive(false);
        shootJoystick.SetActive(false);

    }

    public void HidePauseMenu()
    {
        pauseMenuUI.SetActive(false);
        moveJoystick.SetActive(true);
        shootJoystick.SetActive(true);
    }
    #endregion
}
