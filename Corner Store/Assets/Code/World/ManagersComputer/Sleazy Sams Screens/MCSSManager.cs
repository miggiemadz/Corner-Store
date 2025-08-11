using UnityEngine;
using UnityEngine.UI;

public class MCSSManager : MonoBehaviour
{
    [Header("Screens")]
    [SerializeField] GameObject[] SSScreens;

    [Header("Universal")]
    [SerializeField] MCManager MCManager;
    [SerializeField] MCTaskbar taskbar;

    private bool firstTimeOpen = true;

    void Start()
    {
        
    }

    private void OnEnable()
    {
        if (firstTimeOpen)
        {
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

            MCManager.CurrentScreen = MCManager.Screen.SSfrontPage;
            firstTimeOpen = false;
        }

    }

    void Update()
    {
        
    }
    public void XButton()
    {
        firstTimeOpen = true;
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
        foreach (GameObject tab in taskbar.MinimizedTabs)
        {
            if (!tab.activeSelf)
            {
                RawImage tabIcon = tab.GetComponent<RawImage>();
                tabIcon.texture = taskbar.Samslogo;
                tab.SetActive(true);
                break;
            }
        }

        gameObject.SetActive(false);
    }
}
