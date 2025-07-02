using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CharacterController))] //requires charController 2 run script (automatically adds one if not present)

public class testController : MonoBehaviour
{
    [Header("Player Movement Variables")]
    private Vector3 moveDirection; // the movement vector that gets it's values based on user input
    public float maxSpeed = 3.5f;
    public float jumpSpeed = 5f;
    //private RaycastHit groundCheck; // the raycast hit reference that checks for floor collisions (or use a float?)/ (using charController.isGrounded instead)
    public float gravity = -9.8f; //default gravity in unity

    [Header("Cam Movement Variables")]
    //cam sensitivity
    public float lookSensX = 1f;
    public float lookSensY = 1f;
    //limit player's looking angle (prevents player frm looking up & over their back)
    public float minAngleY = -90f;
    public float maxAngleY = 90f;
    private float verticalLookRotation = 0f; //to rotate player cam between clamped y-values(added: 6/18)

    [Header("Other Variables")]
    [SerializeField] Transform Camera; //reference player/main camera (or use cinemachine?)
    [SerializeField] CharacterController charController; //reference controller


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        charController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; //to lock the cursor while in game
        Cursor.visible = false; //hides cursor while in game
    }

    // Update is called once per frame
    //[System.Obsolete]
    void Update()
    {
        //player movement
        float horizontalMovement = Input.GetAxis("Horizontal"); //WASD controls (edit>projSettings>InputManager)
        float verticalMovement = Input.GetAxis("Vertical");
        moveDirection = (transform.forward * verticalMovement + transform.right * horizontalMovement).normalized; //move across the vector3 accoring to user input
        charController.Move(maxSpeed * Time.deltaTime * moveDirection); //move char w consideration of playerSpeed&time

        //or use...
        //Vector3 inputDirection = transform.forward * moveDirection.y + transform.right * moveDirection.x;
        //inputDirection.y = 0;
        //inputDirection.Normalize();
        //charController.Move(inputDirection * maxSpeed * Time.deltaTime);


        //Camera movement (6/19: slightly working now :))
        if (Camera != null) //make sure player cam exists
        {
            //define/get player input and apply look sensitivity
            float mouseX = Input.GetAxis("Mouse X") * lookSensX; //mouse X-axis movement (edit>projSettings>MouseX)
            float mouseY = Input.GetAxis("Mouse Y") * lookSensY; //mouse Y-axis movements

            //rotate player left and right (no need to rotate camera this way since cam is within player/capsule)
            transform.Rotate(Vector3.up * mouseX); //multiply Vector3 w/ x-value of 1 by user's x-axis input (Vector3.up = (0,1,0))

            //rotate camera up and down (rotates cam w/o rotating actual player model)
            verticalLookRotation -= mouseY; //subtract vert cam rotation by user y-axis input
            verticalLookRotation = Mathf.Clamp(verticalLookRotation, minAngleY, maxAngleY); //clamp vert cam rotation between min and max values
            Camera.localEulerAngles = new Vector3(verticalLookRotation, 0f, 0f); //rotate camera relative to parent & plug in vertRotation value
        }

        //Jumping (6/19: not working yet)
        if (Input.GetButton("Jump") && charController.isGrounded) //if player is grounded & pressing spacebar/X/A, etc.
        {
            moveDirection.y += jumpSpeed * Time.deltaTime; //apply jump force
        }else{
            moveDirection.y += gravity * Time.deltaTime; //apply gravity force whenever player isn't grounded or actively jumping (+= since gravity is negative)
        }
    }
}
