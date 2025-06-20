using UnityEngine;

public class InputUIManager : MonoBehaviour
{
    [SerializeField] GameObject[] MNKInputs;
    [SerializeField] GameObject[] ControllerInputs;

    [SerializeField] CameraSettings cameraSettings;

    void Start()
    {
        
    }

    void Update()
    {
        if (cameraSettings.LastInputDeviceType == CameraSettings.InputDeviceTypes.Controller)
        {
            foreach (GameObject icons in MNKInputs)
            {
                icons.SetActive(false);
            }

            foreach (GameObject icons in ControllerInputs)
            {
                icons.SetActive(true);
            }
        }

        if (cameraSettings.LastInputDeviceType == CameraSettings.InputDeviceTypes.MnK)
        {
            foreach (GameObject icons in MNKInputs)
            {
                icons.SetActive(true);
            }

            foreach (GameObject icons in ControllerInputs)
            {
                icons.SetActive(false);
            }
        }
    }
}
