using UnityEngine;

public class MCSSFrontPage : MonoBehaviour
{
    [SerializeField] GameObject[] samsPages;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OpenGeneralGoods()
    {
        samsPages[0].SetActive(true);
        gameObject.SetActive(false);
    }

    public void OpenColdCuisine()
    {
        samsPages[1].SetActive(true);
        gameObject.SetActive(false);
    }

    public void OpenFreshFrozen()
    {
        samsPages[2].SetActive(true);
        gameObject.SetActive(false);
    }

    public void OpenMembership()
    {
        samsPages[3].SetActive(true);
        gameObject.SetActive(false);
    }

    public void OpenOrderHistory()
    {
        samsPages[4].SetActive(true);
        gameObject.SetActive(false);
    }

    public void OpenHelp()
    {

    }

    public void OpenCart()
    {

    }
}
