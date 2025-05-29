using UnityEngine;

[CreateAssetMenu(fileName = "CameraSettingsManager", menuName = "Scriptable Objects/CameraSettingsManager")]
public class CameraSettings : ScriptableObject
{
    [Header("Universal Settings")]
    private int shoulderSide = 1; // Component: Camera Side. Values: 1 (right), 0 (Left)
    private float fOV = 60f; // Component: Lens(Vertical FOV), Values: 60 - 90

    [Header("MnK Settings")]
    private float cameraSensitivityXMNK;
    private float cameraSensitivityYMNK;

    [Header("Controller Settings")]
    private float cameraSensitivityXController;
    private float cameraSensitivityYController;
    private float controllerDeadZoneX;
    private float controllerDeadZoneY;

    // Universal
    public int ShoulderSide { get => shoulderSide; set => shoulderSide = value; }
    public float FOV { get => fOV; set => fOV = value; }

    // MnK
    public float CameraSensitivityXMNK { get => cameraSensitivityXMNK; set => cameraSensitivityXMNK = value; }
    public float CameraSensitivityYMNK { get => cameraSensitivityYMNK; set => cameraSensitivityYMNK = value; }

    // Controller
    public float CameraSensitivityXController { get => cameraSensitivityXController; set => cameraSensitivityXController = value; }
    public float CameraSensitivityYController { get => cameraSensitivityYController; set => cameraSensitivityYController = value; }
    public float ControllerDeadZoneX { get => controllerDeadZoneX; set => controllerDeadZoneX = value; }
    public float ControllerDeadZoneY { get => controllerDeadZoneY; set => controllerDeadZoneY = value; }
}
