using UnityEngine;

public class MoveV : MonoBehaviour
{
    #region Fields
    [SerializeField] private Animator animator;
    [SerializeField] private MoveD moveData;
    [SerializeField] private MoveH moveHandler;
    #endregion

    #region Methods
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float runSpeed = Mathf.Abs(xInput) * moveData.speed;

        if (moveHandler.grounded)
        {
            animator.SetFloat("RunSpeed", runSpeed);
        }
    }
    #endregion
}
