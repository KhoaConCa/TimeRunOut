using UnityEngine;

public class PauseV : MonoBehaviour
{
    #region Fields
    [SerializeField] private GameObject pauseMenuUI;
    #endregion

    #region Methods
    public void ShowPauseMenu()
    {
        pauseMenuUI.SetActive(true);
    }

    public void HidePauseMenu()
    {
        pauseMenuUI.SetActive(false);
    }
    #endregion
}
