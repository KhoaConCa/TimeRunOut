using System.Collections;
using System.Xml.Linq;
using System.Xml.Serialization;
using UnityEngine;

public class MoveH : MonoBehaviour
{
    #region Fields
    [SerializeField] public MoveD moveData;
    [SerializeField] public Rigidbody2D body;
    [SerializeField] private CapsuleCollider2D groundCheck;
    [SerializeField] public LayerMask groundMask;
    [SerializeField] private Animator animator;
    [SerializeField] private ShootH shootHandler;
    //[SerializeField] private CameraH cameraHandler;

/*    public CameraV cameraView;
    public ParticleV particleView;*/
    public bool grounded;
/*    private Vector2 checkPoint;*/
    #endregion

    #region Methods
/*    void Start()
    {
        checkPoint = transform.position;
    }*/

/*    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Die();
        }
    }*/
/*    void FixedUpdate()
    {
        CheckGround(); ;

        if (grounded && Mathf.Abs(body.velocity.x) < 0.1)
        {
            body.velocity *= moveData.drag;
        }
    }*/
    #region Constraints
    public void CheckGround()
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

    public void FlipCharacter(float x)
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

 /*   #region Die, Respawn, Check Point
    private void Die()
    {
*//*        cameraView.PlayRespawnAnimation();
        particleView.PlayParticle(ParticleV.Particles.die, transform.position);*//*
        StartCoroutine(Respawn(0.5f));
    }

    public void UpdateCheckPoint(Vector2 position)
    {
        checkPoint = position;
    }

    IEnumerator Respawn(float duration)
    {
        body.simulated = false;
        body.velocity = new Vector2(0, 0);
        transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(duration);
        transform.position = checkPoint;
        shootHandler.StopShoot();
        transform.localScale = new Vector3(1, 1, 1);
        body.simulated = true;
    }
    #endregion*/

    #endregion
}
