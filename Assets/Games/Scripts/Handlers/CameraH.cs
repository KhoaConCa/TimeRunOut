// Handler/CameraHandler.cs
using UnityEngine;

public class CameraH : MonoBehaviour
{
    public Transform player;
    public float followSpeed = 5f;
    public float autoMoveSpeed = 5f;
    public float speedRunMultiplier = 2f;
    public float slowMotionMultiplier = 0.5f;

    private enum CameraState { FollowPlayer, AutoMove, SpeedRun, SlowMotion, StopForBoss }
    private CameraState currentState = CameraState.FollowPlayer;

    private void Update()
    {
        switch (currentState)
        {
            case CameraState.FollowPlayer:
                FollowPlayer();
                break;
            case CameraState.AutoMove:
                AutoMove();
                break;
            case CameraState.SpeedRun:
                AutoMove(speedRunMultiplier);
                break;
            case CameraState.SlowMotion:
                AutoMove(slowMotionMultiplier);
                break;
            case CameraState.StopForBoss:
                break;
        }
    }

    private void FollowPlayer()
    {
        Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }

    private void AutoMove(float speedMultiplier = 1f)
    {
        transform.Translate(Vector3.right * autoMoveSpeed * speedMultiplier * Time.deltaTime);
    }

    public void TriggerAutoMove() => currentState = CameraState.AutoMove;
    public void TriggerSpeedRun() => currentState = CameraState.SpeedRun;
    public void TriggerSlowMotion() => currentState = CameraState.SlowMotion;
    public void TriggerStopForBoss() => currentState = CameraState.StopForBoss;
}
