using UnityEngine;
[RequireComponent(typeof(PlayerMovementView))]
public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private Transform camera;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private LayerMask groundMask;
    [SerializeField]
    private PlayerMovementData movementData;

    private PlayerMovementView view;
    private Vector3 velocity;
    private Animator animator;
    private bool isGrounded;

    void Awake() => view = GetComponent<PlayerMovementView>();

    void Update()
    {
        if (GameManager.Instance.IsGameRunning())
        {
            // Check if player is standing on the floor
            isGrounded = Physics.CheckSphere(groundCheck.position, movementData.groundDistance, groundMask);
            if (isGrounded)
            {
                view.StopJump();
            }

            // Basic player movement
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(x, 0, z);

            if (direction.magnitude >= 0.01f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref movementData.turnSmootVelocity, movementData.turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                view.Move(moveDirection * movementData.speed * Time.deltaTime);
                
                if (isGrounded)
                {
                    view.Walk();
                }
                else
                {
                    view.StopWalk();
                }
            }
            else
            {
                view.StopWalk();
            }

            // Jumping
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                velocity.y = Mathf.Sqrt(movementData.jumpHeight * -2f * movementData.gravity);
                view.Jump();
            }

            velocity.y += movementData.gravity * Time.deltaTime;
            view.Move(velocity * Time.deltaTime);
        }
        else {
            view.StopJump();
            view.StopWalk();
        }
    }
}
