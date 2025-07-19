using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Runtime.CompilerServices;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("Universal")]
    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private MenuManager menuManager;
    [SerializeField] private InputActionReference UINavigateInput;
    [SerializeField] private InputActionReference UISelectInput;

    [Header("Buttons")]
    [SerializeField] private Button[] buttonList;
    private int buttonPointer;
    private bool navButtonPressed;

    private void Start()
    {
        buttonPointer = -1;
        navButtonPressed = false;
    }

    private void Update()
    {
        UpdateSelectedButtonColor();

        HighlightButtons();
        ControllerNavigation();

        if (gameSettings.LastInputDeviceType == GameSettings.InputDeviceTypes.MnK)
        {
            buttonPointer = -1;
        }
    }

    private void UpdateSelectedButtonColor()
    {
        foreach (Button button in buttonList)
        {
            ColorBlock colors = button.colors;
            colors.selectedColor = menuManager.SelectedButtonColor;
            button.colors = colors;
        }
    }

    private void ControllerNavigation()
    {
        Vector2 dPadValue = UINavigateInput.action.ReadValue<Vector2>();

        if (dPadValue == Vector2.zero && navButtonPressed)
        {
            navButtonPressed = false;
        }

        if (gameSettings.LastInputDeviceType == GameSettings.InputDeviceTypes.Controller && !navButtonPressed)
        {
            if ((dPadValue.y > 0.5f || dPadValue.y < -0.5f) && buttonPointer == -1)
            {
                buttonPointer = 0;
                navButtonPressed = true;
            }

            else if (dPadValue.y < -0.5f)
            {
                switch (buttonPointer)
                {
                    case 0:
                        buttonPointer = 1;
                        break;
                    case 1:
                        buttonPointer = 2;
                        break;
                    case 2:
                        buttonPointer = 0;
                        break;
                }

                navButtonPressed = true;
            }

            else if (dPadValue.y > 0.5f)
            {
                switch (buttonPointer)
                {
                    case 0:
                        buttonPointer = 2;
                        break;
                    case 1:
                        buttonPointer = 0;
                        break;
                    case 2:
                        buttonPointer = 1;
                        break;
                }

                navButtonPressed = true;
            }
        }
    }

    private void HighlightButtons()
    {
        switch (buttonPointer)
        {
            case -1:
                EventSystem.current.SetSelectedGameObject(null);
                break;

            case 0:
                EventSystem.current.SetSelectedGameObject(null);

                EventSystem.current.SetSelectedGameObject(buttonList[0].gameObject);
                break;

            case 1:
                EventSystem.current.SetSelectedGameObject(null);

                EventSystem.current.SetSelectedGameObject(buttonList[1].gameObject);
                break;

            case 2:
                EventSystem.current.SetSelectedGameObject(null);

                EventSystem.current.SetSelectedGameObject(buttonList[2].gameObject);
                break;
        }
    }

    public void ResumeGame()
    {
        gameObject.SetActive(false);
    }

    public void OpenSettings()
    {
        menuManager.MenuList[1].SetActive(true);
        gameObject.SetActive(false);
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
