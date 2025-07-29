using UnityEngine;

public class MCSLManager : MonoBehaviour
{
    [Header("Screens")]
    [SerializeField] GameObject[] SSScreens;

    [Header("Universal")]
    [SerializeField] MCManager MCManager;

    void Start()
    {
        
    }

    private void OnEnable()
    {
        MCManager.CurrentScreen = MCManager.Screen.SLfrontPage;

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
}
