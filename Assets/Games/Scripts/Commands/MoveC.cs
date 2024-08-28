using UnityEngine;

public class MoveC : MonoBehaviour
{
    #region Fields

    #region PC
    //[SerializeField] private MoveH moveHandler;
    #endregion

    #region iOS
    [SerializeField] private MoveH moveHandler;
    #endregion

    #endregion

    #region Methods

    #region iOS
    void Update()
    {
        moveHandler.Run();
    }
    void FixedUpdate()
    {
        moveHandler.CheckGround();

        if (moveHandler.grounded && Mathf.Abs(moveHandler.body.velocity.x) < 0.1f)
        {
            moveHandler.body.velocity *= moveHandler.moveData.drag;
        }

        moveHandler.Run();
    }
    #endregion

    #region PC
    /*void Update()
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
        moveHandler.CheckGround();

        if (moveHandler.grounded && Mathf.Abs(moveHandler.body.velocity.x) < 0.1)
        {
            moveHandler.body.velocity *= moveHandler.moveData.drag;
        }
    }*/
    #endregion

    #endregion
}
