using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPCameraController : MonoBehaviour
{
    [Header("Universal")]
    [SerializeField] private GameObject player;
    [SerializeField] private CameraSettings cameraSettings;
    [SerializeField] private InputActionReference lookInput;
    [SerializeField] private MenuManager menuManager;

    [Header("Cinemachine Components")]
    [SerializeField] private CinemachineCamera FPPlayerCamera;
    [SerializeField] private CinemachineHardLockToTarget FPHardLockToTarget;

    void Start()
    {
        
    }

    void Update()
    {
        CameraMovement();

        // FOV
        FPPlayerCamera.Lens.FieldOfView = cameraSettings.FOV;
    }

    private void CameraMovement()
    {
        if (menuManager.CurrentActiveMenu == null)
        {
            gameObject.transform.forward = player.gameObject.transform.forward;
        }
    }
}
