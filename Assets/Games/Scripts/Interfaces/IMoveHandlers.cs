using UnityEngine;

public interface IMoveHandler
{
    void Run();

    void Jump();

    void CheckGround();

    bool IsGrounded();

    Vector2 GetVelocity();

    void ApplyDrag();
}
