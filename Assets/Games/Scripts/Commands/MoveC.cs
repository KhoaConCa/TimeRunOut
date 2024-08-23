using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class MoveC : MonoBehaviour
{
    #region Fields
    [SerializeField] private MoveH moveHandler;
    #endregion

    #region Methods
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        moveHandler.Run(xInput, yInput);

        if (Input.GetKeyDown(KeyCode.W))
        {
            moveHandler.Jump();
        }
    }
    #endregion
}
