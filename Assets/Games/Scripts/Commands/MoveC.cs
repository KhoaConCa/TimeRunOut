using UnityEngine;

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

    void FixedUpdate()
    {
        moveHandler.CheckGround(); ;

        if (moveHandler.grounded && Mathf.Abs(moveHandler.body.velocity.x) < 0.1)
        {
            moveHandler.body.velocity *= moveHandler.moveData.drag;
        }
    }
    #endregion
}
