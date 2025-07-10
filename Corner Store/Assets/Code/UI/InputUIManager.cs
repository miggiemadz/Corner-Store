using UnityEngine;

public class InputUIManager : MonoBehaviour
{
    [SerializeField] GameObject[] ControlTypes;

    [SerializeField] CameraSettings cameraSettings;
    [SerializeField] GameSettings gameSettings;

    void Start()
    {
        
    }

    void Update()
    {
        switch (gameSettings.LastInputDeviceType)
        {
            case GameSettings.InputDeviceTypes.MnK:
                foreach (GameObject control in ControlTypes)
                {
                    GameObject MnKInput = control.transform.GetChild(0).gameObject;
                    GameObject controllerInput = control.transform.GetChild(1).gameObject;

                    MnKInput.SetActive(true);
                    controllerInput.SetActive(false);
                }
                break;

            case GameSettings.InputDeviceTypes.Controller:
                foreach (GameObject control in ControlTypes)
                {
                    GameObject MnKInput = control.transform.GetChild(0).gameObject;
                    GameObject controllerInput = control.transform.GetChild(1).gameObject;

                    MnKInput.SetActive(false);
                    controllerInput.SetActive(true);

                    GameObject[] controllerTypes = { controllerInput.transform.GetChild(0).gameObject, controllerInput.transform.GetChild(1).gameObject, controllerInput.transform.GetChild(2).gameObject, controllerInput.transform.GetChild(3).gameObject };

                    for (int i = 0; i < controllerTypes.Length; i++)
                    {
                        if (i == (int) gameSettings.CurrentControllerType)
                        {
                            controllerTypes[i].SetActive(true);
                        }
                        else
                        {
                            controllerTypes[i].SetActive(false);
                        }
                    }
                }
                break;
        }
    }
}
