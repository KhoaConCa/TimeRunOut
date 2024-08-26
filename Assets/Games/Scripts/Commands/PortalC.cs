using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalC : MonoBehaviour
{
    #region Fields
    [SerializeField] public Transform destination;
    [SerializeField] private GameObject player;
    #endregion

    #region Methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleport"))
        {
            player.transform.position = destination.transform.position;
        }
    }
    #endregion
}
