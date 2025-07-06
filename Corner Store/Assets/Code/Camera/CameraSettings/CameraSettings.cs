using UnityEngine;

[CreateAssetMenu(fileName = "CameraSettingsManager", menuName = "Scriptable Objects/CameraSettingsManager")]
public class CameraSettings : ScriptableObject
{
    public enum CameraPOVs
    {
        FirstPerson,
        ThirdPersonBehind,
        ThirdPersonFront
    }

    public enum InputDeviceTypes
    {
        MnK,
        Controller
    }

    public enum ControllerType
    {
        PS4,
        PS5,
        XBox,
        Switch
    }

    [Header("Universal Settings")]
    private float shoulderSide = .75f; 
    private float fOV = 60f;
    private bool isSettingsActive;
    private CameraPOVs currentPOV;
    private InputDeviceTypes lastInputDeviceType;
    private ControllerType currentControllerType;

    [Header("MnK Settings")]
    private float tPCameraSensitivityXMNK = 1f;
    private float tPCameraSensitivityYMNK = 1f;
    private float fPCameraSensitivityXMNK = 1f;
    private float fPCameraSensitivityYMNK = 1f;


    [Header("Controller Settings")]
    private float tPCameraSensitivityXController = 1f;
    private float tPCameraSensitivityYController = 1f;
    private float fPCameraSensitivityXController = 1f;
    private float fPCameraSensitivityYController = 1f;
    private float controllerDeadZoneLeft = 1f;
    private float controllerDeadZoneRight = 1f;

    // Universal
    public float ShoulderSide { get => shoulderSide; set => shoulderSide = value; }
    public float FOV { get => fOV; set => fOV = value; }
    public CameraPOVs CurrentPOV { get => currentPOV; set => currentPOV = value; }
    public InputDeviceTypes LastInputDeviceType { get => lastInputDeviceType; set => lastInputDeviceType = value; }
    public ControllerType CurrentControllerType { get => currentControllerType; set => currentControllerType = value; }
    public bool IsSettingsActive { get => isSettingsActive; set => isSettingsActive = value; }

    // MnK
    public float TPCameraSensitivityXMNK { get => tPCameraSensitivityXMNK; set => tPCameraSensitivityXMNK = value; }
    public float TPCameraSensitivityYMNK { get => tPCameraSensitivityYMNK; set => tPCameraSensitivityYMNK = value; }
    public float FPCameraSensitivityXMNK { get => fPCameraSensitivityXMNK; set => fPCameraSensitivityXMNK = value; }
    public float FPCameraSensitivityYMNK { get => fPCameraSensitivityYMNK; set => fPCameraSensitivityYMNK = value; }

    // Controller
    public float TPCameraSensitivityXController { get => tPCameraSensitivityXController; set => tPCameraSensitivityXController = value; }
    public float TPCameraSensitivityYController { get => tPCameraSensitivityYController; set => tPCameraSensitivityYController = value; }
    public float ControllerDeadZoneLeft { get => controllerDeadZoneLeft; set => controllerDeadZoneLeft = value; }
    public float ControllerDeadZoneRight { get => controllerDeadZoneRight; set => controllerDeadZoneRight = value; }
    public float FPCameraSensitivityXController { get => fPCameraSensitivityXController; set => fPCameraSensitivityXController = value; }
    public float FPCameraSensitivityYController { get => fPCameraSensitivityYController; set => fPCameraSensitivityYController = value; }
}
