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
    private float lookDirection;
    //cam sensitivity
    public float lookSensX = 1f;
    public float lookSensY = 1f;
    //limit player's looking angle
    public float minAngleY = -90f;
    public float maxAngleY = 90f;

    [Header("Other Variables")]
    [SerializeField] Transform Camera; //reference player/main camera (or use cinemachine?)
    [SerializeField] CharacterController charController; //reference controller

    //TO-DO:
    // vars for sensitivity?
    // add y-axis limit/look angle?


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        charController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; //to lock the cursor while in game
        Cursor.visible = false;
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


        //cam movement
        if(Camera != null)
        {
            float mouseX = Input.GetAxis("Mouse X"); //mouse X-axis movement (edit>projSettings>MouseX)
            float mouseY = Input.GetAxis("Mouse Y"); //float mouseX = Input.GetAxis("Mouse X"); //mouse X-axis movement (edit>projSettings>MouseX) 
            //lookDirection = ().normalized;
        }

        //jumping
        if (Input.GetButton("Jump") && charController.isGrounded) //if player is grounded & pressing spacebar/X/A, etc.
        {
            moveDirection.y = jumpSpeed; //apply jumo force
        }else{
            moveDirection.y += gravity; //apply gravity force whenever player isn't grounded or actively jumping 
        }

        //TO-DO: obj pickup


        //miguel's code used 4 reference
        //inputDirection = new Vector3(playerMovement.action.ReadValue<Vector2>().x, 0, playerMovement.action.ReadValue<Vector2>().y).normalized;

    }
}
