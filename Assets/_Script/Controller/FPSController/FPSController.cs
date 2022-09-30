using UnityEngine;

namespace Homework.Mechanics.Character
{

    public class FPSController : MonoBehaviour
    {
        // refrences
        public CharacterController characterController;

        // Joystict
        private FixedJoystick joystick;

        // player setting
        public float cameraSensitivity;
        public float moveSpeed;
        public float moveInputDeadZone;

        // touch detection 
        int leftFinggerID, rightFinggerID;
        float halfScreenWidht;

        // camera control
        Vector2 lookInput;
        float cameraPitch;

        // player movement 
        Vector2 moveTouchStartPosition;
        Vector2 moveInput;

        // player jump
        [Header("Gravity & Jumping")]
        public float gravity;
        Vector3 velocity;
        public float jumpForce;

        // ground check
        [Header("Ground Check")]
        public Transform groundCheck;
        public LayerMask groundLayers;
        public float groundCheckRadius;
        [SerializeField] private bool isGrounded;

        private void Awake()
        {
            joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<FixedJoystick>();
        }

        private void Start()
        {
            leftFinggerID = -1;
            rightFinggerID = -1;

            halfScreenWidht = Screen.width / 2;

            // calcualte the movement input dead zone
            moveInputDeadZone = Mathf.Pow(Screen.width / moveInputDeadZone, 2);
        }

        private void Update()
        {

            // handles input
            GetTouchInput();

            // check righ fingger touch
            if (rightFinggerID != -1)
            {
                lookAround();
            }

            // joystict controller
            JoystickMove();

            // get down character with gravity
            velocity.y += gravity * Time.deltaTime;
            characterController.Move(velocity * Time.deltaTime);

        }

        private void FixedUpdate()
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayers);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }
        }

        void GetTouchInput()
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch t = Input.GetTouch(i);

                switch (t.phase)
                {
                    case TouchPhase.Began:
                        if (t.position.x < halfScreenWidht && leftFinggerID == -1)
                        {
                            leftFinggerID = t.fingerId;
                            // Debug.Log("tracking left fingger");
                            moveTouchStartPosition = t.position;
                        }
                        else if (t.position.x > halfScreenWidht && rightFinggerID == -1)
                        {
                            rightFinggerID = t.fingerId;
                            // Debug.Log("tracking right fingger");
                        }
                        break;
                    case TouchPhase.Ended:
                    case TouchPhase.Canceled:
                        if (t.fingerId == leftFinggerID)
                        {
                            leftFinggerID = -1;
                            // Debug.Log("stop tracking left fingger");
                        }
                        if (t.fingerId == rightFinggerID)
                        {
                            rightFinggerID = -1;
                            // Debug.Log("stop tracking right fingger");
                        }
                        break;
                    case TouchPhase.Moved:
                        // get input for looking around
                        if (t.fingerId == rightFinggerID)
                        {
                            lookInput = t.deltaPosition * cameraSensitivity * Time.deltaTime;
                        }
                        else if (t.fingerId == leftFinggerID)
                        {
                            moveInput = t.position - moveTouchStartPosition;
                        }
                        break;
                    case TouchPhase.Stationary:
                        // set the look input to zero if the fingger is still
                        if (t.fingerId == rightFinggerID)
                        {
                            lookInput = Vector2.zero;
                        }
                        break;
                }
            }
        }

        void lookAround()
        {
            // vertical (pitch) rotation
            cameraPitch = Mathf.Clamp(cameraPitch - lookInput.y, -90f, 90f);

            // horizontal (yaw) rotation
            transform.Rotate(transform.up, lookInput.x);
        }

        public void Move()
        {
            // don't move if the touch delta is shooter than the designeted ded zone
            if (moveInput.sqrMagnitude <= moveInputDeadZone) return;

            // multiply the normalized direction by the speed
            Vector2 movementDirection = moveInput.normalized * moveSpeed * Time.deltaTime;

            // move relatively to the local transform direction 
            characterController.Move(transform.right * movementDirection.x + transform.forward * movementDirection.y);
        }

        public void JoystickMove()
        {

            Vector2 move = joystick.Direction * moveSpeed * Time.deltaTime;
            characterController.Move(transform.right * move.x + transform.forward * move.y);
        }

        public void Jump()
        {
            if (isGrounded)
            {
                Debug.Log("player jump");
                velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            }
        }


    }
}
