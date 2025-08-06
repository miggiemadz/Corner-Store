using UnityEngine;

public class MCDesktopScreen : MonoBehaviour
{
    [SerializeField] private MCManager manager;

    [SerializeField] private GameObject SleazySamScreens;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OpenSleazySams()
    {
        manager.CurrentScreen = MCManager.Screen.SSfrontPage;

        SleazySamScreens.SetActive(true);
    }

    public void OpenStoreLogistics()
    {

    }
}
