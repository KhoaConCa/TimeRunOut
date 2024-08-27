using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameC : MonoBehaviour
{
    [SerializeField] private GameObject endGamePanel;

    public void ShowEndGamePanel()
    {
        if (endGamePanel != null)
        {
            Time.timeScale = 0f;
            endGamePanel.SetActive(true);
        }
    }
}
