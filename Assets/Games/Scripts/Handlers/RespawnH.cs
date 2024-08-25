using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnH : MonoBehaviour
{
    #region Fields
    [SerializeField] private ShootH shootHandler;
    [SerializeField] private MoveH moveHandler;
    [SerializeField] private Rigidbody2D body;
    //[SerializeField] private CameraH cameraHandler;

/*    public CameraV cameraView;
    public ParticleV particleView;*/
    private Vector2 checkPoint;
    #endregion

    #region Methods

    #region Die, Respawn, Check Point
    void Start()
    {
        checkPoint = transform.position;
    }

    public void Die()
    {
/*        cameraView.PlayRespawnAnimation();
        particleView.PlayParticle(ParticleV.Particles.die, transform.position);*/
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
    #endregion

    #endregion
}
