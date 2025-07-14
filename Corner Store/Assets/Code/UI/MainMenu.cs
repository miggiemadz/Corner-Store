using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static System.Net.WebRequestMethods;

public class MainMenu : MonoBehaviour
{
    [Header("Universal")]
    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private MenuManager menuManager;
    [SerializeField] private InputActionReference UINavigateInput;
    [SerializeField] private InputActionReference UISelectInput;

    [Header("Buttons")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button quitButton;
    private int buttonPointer;
    private bool navButtonPressed;

    private string discordURL = "https://discord.gg/hYzz9EUrPc";
    private string instagramURL = "https://www.instagram.com/studioinfiniteloom/";
    private string tikTokURL = "https://www.tiktok.com/@studio_infinite_loom";
    private string xURL = "https://x.com/StudioInf_Loom";
    private string youTubeURL = "https://www.youtube.com/@StudioInfiniteLoom-yt";

    private void Start()
    {
        buttonPointer = -1;
        navButtonPressed = false;
    }

    private void Update()
    {
        ControllerNavigation();
        HighlightButtons();
        SelectButtons();
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
            case 0:
                EventSystem.current.SetSelectedGameObject(null);

                EventSystem.current.SetSelectedGameObject(playButton.gameObject);
                break;

            case 1:
                EventSystem.current.SetSelectedGameObject(null);

                EventSystem.current.SetSelectedGameObject(settingsButton.gameObject);
                break;

            case 2:
                EventSystem.current.SetSelectedGameObject(null);

                EventSystem.current.SetSelectedGameObject(quitButton.gameObject);
                break;
        }
    }

    public void PlayGame()
    {
        Debug.Log("Playing game.");
    }

    public void OpenSettings()
    {
        menuManager.SettingsMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

    private void SelectButtons()
    {
        if (UISelectInput)
        {
            switch (buttonPointer)
            {
                case 0:
                    PlayGame();
                    break;

                case 1:
                    OpenSettings();
                    break;

                case 2:
                    QuitGame();
                    break;
            }
        }
    }

    public void OpenURL(string url)
    {
        Application.OpenURL(url);
    }

    public void OpenDiscord()
    {
        OpenURL(discordURL);
    }

    public void OpenInstagram()
    {
        OpenURL(instagramURL);
    }

    public void OpenTikTok()
    {
        OpenURL(tikTokURL);
    }

    public void OpenX()
    {
        OpenURL(xURL);
    }

    public void OpenYouTube()
    {
        OpenURL(youTubeURL);
    }
}
