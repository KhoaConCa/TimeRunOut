using UnityEngine;

public class CameraH : MonoBehaviour
{
    #region Fields
    public Transform player;
    public float followSpeed = 5f;
/*    public float autoMoveSpeed = 5f;
    public float speedRunMultiplier = 2f;
    public float slowMotionMultiplier = 0.5f;*/

    private enum CameraState { FollowPlayer, StopForBoss } //AutoMove, SpeedRun, SlowMotion, StopForBoss }
    private CameraState currentState;
/*
    public float[] triggerPoints = new float[] { 0f, 10f, 30f, 50f, 70f, 90f, 120f, 150f, 180f, 210f, 240f };
    private int currentTriggerIndex = 0;*/
    #endregion

    #region Methods
    private void Update()
    {
/*        CheckForTriggerPoints();*/

        switch (currentState)
        {
            case CameraState.FollowPlayer:
                FollowPlayer();
                break;
            case CameraState.StopForBoss:
                break;
/*          case CameraState.AutoMove:
                AutoMove();
                break;
            case CameraState.SpeedRun:
                AutoMove(speedRunMultiplier);
                break;
            case CameraState.SlowMotion:
                AutoMove(slowMotionMultiplier);
                break;*/
        }
    }

/*    private void CheckForTriggerPoints()
    {
        if (currentTriggerIndex < triggerPoints.Length && player.position.x >= triggerPoints[currentTriggerIndex])
        {
            switch (currentTriggerIndex)
            {
                case 0:
                    TriggerFollowPlayer();
                    break;
                case 1:
                    TriggerAutoMove();
                    break;
                case 2:
                    TriggerSpeedRun();
                    break;
                case 3:
                    TriggerAutoMove();
                    break;
                case 4:
                    TriggerSlowMotion();
                    break;
                case 5:
                    TriggerAutoMove();
                    break;
                case 6:
                    TriggerSpeedRun();
                    break;
                case 7:
                    TriggerAutoMove();
                    break;
                case 8:
                    TriggerSpeedRun();
                    break;
                case 9:
                    TriggerAutoMove();
                    break;
                case 10:
                    TriggerStopForBoss();
                    break;
            }
            currentTriggerIndex++;
        }
    }*/

    private void FollowPlayer()
    {
        Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }

    /*    private void AutoMove(float speedMultiplier = 1f)
        {
            transform.Translate(Vector3.right * autoMoveSpeed * speedMultiplier * Time.deltaTime);
        }*/
    public void TriggerFollowPlayer() => currentState = CameraState.FollowPlayer;
    public void TriggerStopForBoss() => currentState = CameraState.StopForBoss;
    /*    public void TriggerAutoMove() => currentState = CameraState.AutoMove;
        public void TriggerSpeedRun() => currentState = CameraState.SpeedRun;
        public void TriggerSlowMotion() => currentState = CameraState.SlowMotion;*/
    #endregion
}
