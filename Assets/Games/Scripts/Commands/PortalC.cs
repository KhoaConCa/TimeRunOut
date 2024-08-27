using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalC : MonoBehaviour
{
    #region Fields
    [SerializeField] public Transform destination;
    [SerializeField] private GameObject player;
    [SerializeField] private string bossSceneName = "BossScene";
    #endregion

    #region Methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleport"))
        {
            player.transform.position = destination.transform.position;
        }

        if (collision.CompareTag("BossGate"))
        {
            SceneManager.LoadScene(bossSceneName);
        }
    }
    #endregion
}
