using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CharacterController))] //requires charController 2 run script (automatically adds one if not present)

public class testController : MonoBehaviour
{
    [Header("Movement Variables")]
    private Vector3 moveDirection; // the movement vector that gets it's values based on user input
    public float maxSpeed = 3.5f;
    public float jumpSpeed = 5f;
    //private RaycastHit groundCheck; // the raycast hit reference that checks for floor collisions (or use a float?)/ (using charController.isGrounded instead)
    public float gravity = -9.8f; //default gravity in unity

    [Header("Cam Movement Variables")]
    //private float lookDirection;
    //cam sensitivity
    public float lookSensX = 1f;
    public float lookSensY = 1f;
    //to limit player's looking angle
    public float minAngleY = -90f;
    public float maxAngleY = 90f;

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
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal"); //WASD controls (edit>projSettings>InputManager)
        float verticalMovement = Input.GetAxis("Vertical");
        moveDirection = (transform.forward * verticalMovement + transform.right * horizontalMovement).normalized; //move across the vector3 accoring to user input
        charController.Move(maxSpeed * Time.deltaTime * moveDirection);

        //or use...
        //Vector3 inputDirection = transform.forward * moveDirection.y + transform.right * moveDirection.x;
        //inputDirection.y = 0;
        //inputDirection.Normalize();
        //charController.Move(inputDirection * maxSpeed * Time.deltaTime);


        //Camera movement (not working yet)
        if (Camera != null) //make sure player cam exists
        {
            float mouseX = Input.GetAxis("Mouse X"); //mouse X-axis movement (edit>projSettings>MouseX)
            float mouseY = Input.GetAxis("Mouse Y");
            //Vector3 lookDirection = new Vector3(mouseX * lookSensX, mouseY * lookSensY, ???);
            Vector2 lookDirection = new Vector2(mouseX * lookSensX, mouseY * lookSensY); //creates a vector2 with X&Y's that correspond to user's mouse movement&sens
            //Camera.Rotate(lookDirection); //rotate player's cam according to ^
            //should I normalize???(ln 59) -> Vector2 lookDirection = new Vector2(mouseX * lookSensX, mouseY * lookSensY).normalized;
            //or...
            //transform.rotation *= Quaternion.AngleAxis(lookDirection, Vector3.up);
            transform.localEulerAngles = lookDirection; //(using either this method or one on ln 60)
            Camera.Rotate(lookDirection, Space.World); //use space.self or space.world?
        }

        //Jumping (not working yet)
        if (Input.GetButton("Jump") && charController.isGrounded) //if player is grounded & pressing spacebar/X/A, etc.
        {
            moveDirection.y += jumpSpeed; //apply jump force
        }else{
            moveDirection.y += gravity; //apply gravity force whenever player isn't grounded or actively jumping (+= since gravity is negative)
        }

        //TO-DO: obj pickup


        //miguel's code used 4 reference (line 10, 43)
        //inputDirection = new Vector3(playerMovement.action.ReadValue<Vector2>().x, 0, playerMovement.action.ReadValue<Vector2>().y).normalized;
    }
}
