using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MCLockScreen : MonoBehaviour
{
    private string MCPassword = "Password1234";

    [SerializeField] private TMP_InputField passwordInput;
    [SerializeField] private MCManager manager;
    [SerializeField] private GameObject desktopScreen;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PowerButton()
    {
        Debug.Log("Power Off");
    }

    public void LoginButton()
    {
        if (passwordInput.text == MCPassword)
        {
            manager.CurrentScreen = MCManager.Screen.mainDesktop;
            desktopScreen.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
