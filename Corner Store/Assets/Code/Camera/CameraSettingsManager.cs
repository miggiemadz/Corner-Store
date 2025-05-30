using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CameraSettingsManager : MonoBehaviour
{
    [SerializeField] private CameraSettings cameraSettings;
    [SerializeField] private Toggle shoulderCameraToggle;

    [Header("FOV Slider")]
    [SerializeField] private Slider FOVSlider;
    [SerializeField] private TextMeshProUGUI FOVValueText;

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
            cameraSettings.ShoulderSide = 1;
        }
        else
        {
            cameraSettings.ShoulderSide = 0;
        }

        // FOV Slider
        cameraSettings.FOV = FOVSlider.value;
        FOVValueText.text = cameraSettings.FOV.ToString();
    }
}
