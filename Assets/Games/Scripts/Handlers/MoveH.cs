using System.Xml.Linq;
using UnityEngine;

public class MoveH : MonoBehaviour
{
    #region Fields
    [SerializeField] private MoveD moveData;
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private CapsuleCollider2D groundCheck;
    [SerializeField] public LayerMask groundMask;
    [SerializeField] private Animator animator;

    public bool grounded;
    #endregion

    #region Methods
    void FixedUpdate()
    {
        CheckGround(); ;

        if (grounded && Mathf.Abs(body.velocity.x) < 0.1)
        {
            body.velocity *= moveData.drag;
        }
    }
    #region Constraints
    private void CheckGround()
    {
        Collider2D collider = Physics2D.OverlapBox(groundCheck.bounds.center, groundCheck.bounds.size, 0, groundMask);
        grounded = collider != null;
    }
    #endregion

    #region Movements
    public void Run(float x, float y)
    {
        FlipCharacter(x);

        if (Mathf.Abs(x) > 0)
        {
            body.velocity = new Vector2(x * moveData.speed, body.velocity.y);
        }

        if (Mathf.Abs(y) > 0 && grounded)
        {
            body.velocity = new Vector2(body.velocity.x, y * moveData.speed);
        }
    }

    public void Jump()
    {
        if (grounded)
        {
            body.velocity = new Vector2(body.velocity.x, moveData.jumpForce);
            grounded = false;
        }
    }

    private void FlipCharacter(float x)
    {
        if (x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    #endregion

    #endregion
}
