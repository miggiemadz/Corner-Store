using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraToggleManager : MonoBehaviour
{
    [Header("Cameras")]
    [SerializeField] GameObject firstPersonCamera;
    [SerializeField] GameObject thirdPersonCamera;
    [SerializeField] GameObject thirdPersonCameraPivot;

    [Header("Settings/UI")]
    [SerializeField] CameraSettings cameraSettings;
    [SerializeField] InputActionReference toggleCameraInput;
    [SerializeField] MenuManager menuManager;
    private int currentPOV = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if (toggleCameraInput.action.triggered)
        {
            currentPOV++;
            if (currentPOV > 2)
            {
                currentPOV = 0;
            }

            cameraSettings.CurrentPOV = (CameraSettings.CameraPOVs)Enum.GetValues(typeof(CameraSettings.CameraPOVs)).GetValue(currentPOV);
        }

       switch (cameraSettings.CurrentPOV)
       {
           case CameraSettings.CameraPOVs.FirstPerson:
               if (menuManager.CurrentActiveMenu == null)
               {
                   Cursor.visible = false;
               }
               else
               {
                   Cursor.visible = true;
               }
               firstPersonCamera.gameObject.SetActive(true);
               thirdPersonCamera.gameObject.SetActive(false);
               break;

           case CameraSettings.CameraPOVs.ThirdPersonFront:
               Cursor.visible = true;
               firstPersonCamera.gameObject.SetActive(false);
               thirdPersonCamera.gameObject.SetActive(true);
               thirdPersonCameraPivot.transform.eulerAngles = new Vector3(0, 180, 0);
               break;

           case CameraSettings.CameraPOVs.ThirdPersonBehind:
               Cursor.visible = true;
               firstPersonCamera.gameObject.SetActive(false);
               thirdPersonCamera.gameObject.SetActive(true);
               thirdPersonCameraPivot.transform.eulerAngles = new Vector3(0, 0, 0);
               break;
            }
    }
}
