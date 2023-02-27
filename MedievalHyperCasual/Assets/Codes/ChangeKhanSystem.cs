using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeKhanSystem : MonoBehaviour
{
    Ray ray;
    float playerMoney;

    void Update()
    {
        ray = FindObjectOfType<Camera>().ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            if(hitInfo.collider.tag == "Khan")
            {
                Khan khan = hitInfo.collider.GetComponent<Khan>();
                if(Input.GetMouseButtonDown(0))
                {
                    if(khan.canBuy && playerMoney >= khan.requiredMoney)
                    {
                        khan.canGoInside = true;
                        khan.canBuy = false;
                    } else if(khan.canGoInside)
                    {
                        SceneManager.LoadScene(khan.sceneName);
                    }
                }
            } else if(hitInfo.collider.tag == "Table")
            {
                //MAÐAZA KODUYLA BÝRLEÞTÝRÝLECEK
            }
        }
    }
}
