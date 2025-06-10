using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CharacterController))] //requires charController 2 run script (automatically adds one if not present)

public class testController : MonoBehaviour
{
    [Header("Movement Variables")]
    public float maxSpeed = 3.5f;
    public float jumpSpeed = 5f;
    private RaycastHit groundCheck; // the raycast hit reference that checks for floor collisions (or use a float?)
    private Vector3 moveDirection; // the movement vector that gets it's values based on user input

    [Header("Other Variables")]
    public Transform Camera; //reference player/main camera (or use cinemachine?)
    //[SerializeField] CinemachineCamera playerCam;
    [SerializeField] CharacterController charController; //reference controller
    //TO-DO:
    // vars for sensitivity?
    // add y-axis limit/look angle?


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        charController = GetComponent<CharacterController>();
        //Cursor.lockState = CursorLockMode.Locked; //to lock the cursor
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal"); //WASD controls (edit>projSettings>InputManager)
        float verticalMovement = Input.GetAxis("Vertical");
        moveDirection = transform.forward * verticalMovement + transform.right * horizontalMovement; //move across the vector3 accoring to user input
        moveDirection.Normalize();
        charController.Move(maxSpeed * Time.deltaTime * moveDirection);

        //or use...
        //Vector3 inputDirection = transform.forward * moveDirection.y + transform.right * moveDirection.x;
        //inputDirection.y = 0;
        //inputDirection.Normalize();
        //charController.Move(inputDirection * maxSpeed * Time.deltaTime);


        //TO-DO:
        //jumping, camera movement, obj pickup

        //miguel's code used 4 reference
        //inputDirection = new Vector3(playerMovement.action.ReadValue<Vector2>().x, 0, playerMovement.action.ReadValue<Vector2>().y).normalized;

    }
}
