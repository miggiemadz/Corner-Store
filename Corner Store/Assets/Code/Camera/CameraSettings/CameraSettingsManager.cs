using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CameraSettingsManager : MonoBehaviour
{
    [Header("Universal")]
    [SerializeField] private Slider FOVSlider;
    [SerializeField] private TextMeshProUGUI FOVValueText;
    [SerializeField] private CameraSettings cameraSettings;
    [SerializeField] private Toggle shoulderCameraToggle;
    [SerializeField] private Toggle universalDeadZoneToggle;

    [Header("Mouse & Keyboard")]
    [SerializeField] private Slider MNKSensitivityXSlider;
    [SerializeField] private TextMeshProUGUI MNKSensitivityXValueText;
    [SerializeField] private Slider MNKSensitivityYSlider;
    [SerializeField] private TextMeshProUGUI MNKSensitivityYValueText;

    [Header("Controller")]
    [SerializeField] private Slider controllerSensitivityXSlider;
    [SerializeField] private TextMeshProUGUI controllerSensitivityXValueText;
    [SerializeField] private Slider controllerSensitivityYSlider;
    [SerializeField] private TextMeshProUGUI controllerSensitivityYValueText;
    [SerializeField] private Slider controllerDeadZoneXSlider;
    [SerializeField] private TextMeshProUGUI controllerDeadZoneXValueText;
    [SerializeField] private Slider controllerDeadZoneYSlider;
    [SerializeField] private TextMeshProUGUI controllerDeadZoneYValueText;
    [SerializeField] private Slider controllerDeadZoneUniversalSlider;
    [SerializeField] private TextMeshProUGUI controllerDeadZoneUniversalValueText;

    void Start()
    {
        shoulderCameraToggle = GameObject.Find("CameraShoulderToggle").GetComponent<Toggle>();
        FOVSlider = GameObject.Find("FOVSlider").GetComponent<Slider>();
        FOVValueText = GameObject.Find("FOVValueText").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        // Camera Shoulder Toggle
        if (shoulderCameraToggle.isOn)
        {
            cameraSettings.ShoulderSide = .75f;
        }
        else
        {
            cameraSettings.ShoulderSide = -.75f;
        }

        // Universal
        cameraSettings.FOV = FOVSlider.value;
        FOVValueText.text = cameraSettings.FOV.ToString();

        // Mouse & Keyboard
        cameraSettings.CameraSensitivityXMNK = MNKSensitivityXSlider.value;
        MNKSensitivityXValueText.text = cameraSettings.CameraSensitivityXMNK.ToString();
        cameraSettings.CameraSensitivityYMNK = MNKSensitivityYSlider.value;
        MNKSensitivityYValueText.text = cameraSettings.CameraSensitivityYMNK.ToString();

        // Controller
        cameraSettings.CameraSensitivityXController = controllerSensitivityXSlider.value;
        controllerSensitivityXValueText.text = cameraSettings.CameraSensitivityXController.ToString();
        cameraSettings.CameraSensitivityYController = controllerSensitivityYSlider.value;
        controllerSensitivityYValueText.text = cameraSettings.CameraSensitivityYController.ToString();

        if (universalDeadZoneToggle.isOn)
        {
            cameraSettings.ControllerDeadZoneX = controllerDeadZoneUniversalSlider.value;
            controllerDeadZoneUniversalValueText.text = cameraSettings.ControllerDeadZoneX.ToString();
            cameraSettings.ControllerDeadZoneY = controllerDeadZoneUniversalSlider.value;
            controllerDeadZoneUniversalValueText.text = cameraSettings.ControllerDeadZoneY.ToString();
        }
        else
        {
            controllerDeadZoneUniversalSlider.gameObject.SetActive(false);
            cameraSettings.ControllerDeadZoneX = controllerDeadZoneXSlider.value;
            controllerDeadZoneXValueText.text = cameraSettings.ControllerDeadZoneX.ToString();
            cameraSettings.ControllerDeadZoneY = controllerDeadZoneYSlider.value;
            controllerDeadZoneYValueText.text = cameraSettings.ControllerDeadZoneY.ToString();
        }
    }
}
