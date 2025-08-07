using UnityEngine;

public class MCSSManager : MonoBehaviour
{
    [Header("Screens")]
    [SerializeField] GameObject[] SSScreens;

    [Header("Universal")]
    [SerializeField] MCManager MCManager;
    [SerializeField] GameObject taskbar;

    void Start()
    {
        
    }

    private void OnEnable()
    {
        MCManager.CurrentScreen = MCManager.Screen.SSfrontPage;

        foreach (var s in SSScreens)
        {
            if (SSScreens[0].Equals(s))
            {
                s.SetActive(true);
            }

            else
            {
                s.SetActive(false);
            }
        }
    }

    void Update()
    {
        
    }
    public void XButton()
    {
        gameObject.SetActive(false);
    }

    public void WindowedButton()
    {

    }

    public void FullscreenButton()
    {

    }

    public void MinimizeButton()
    {

    }
}
