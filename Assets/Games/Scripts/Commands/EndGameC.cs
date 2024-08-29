using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameC : MonoBehaviour
{
    #region Fields
    [SerializeField] private GameObject endGamePanel;
    [SerializeField] private GameObject pausePanel;
    #endregion

    #region Methods
    public void ShowEndGamePanel()
    {
        if (endGamePanel != null)
        {
            Time.timeScale = 0f;
            endGamePanel.SetActive(true);
            pausePanel.SetActive(false);
        }
    }
    #endregion
}
