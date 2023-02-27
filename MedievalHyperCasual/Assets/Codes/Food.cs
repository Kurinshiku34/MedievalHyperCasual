using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] string menu;
    public GameObject[] food; 


    void Start()
    {
        StartCoroutine(Menu());
    }
    IEnumerator Menu()
    {
        yield return new WaitForSeconds(5f);  
        InvokeRepeating("Spawn", 5f, 1f);
        Debug.Log("Yemek pisti");
    }
    void Spawn()
    {
        
        switch (menu)
        {
            case "beef":
              Instantiate(food[0],transform.position, Quaternion.identity);
             break;
            case "chicken":
                Instantiate(food[1], transform.position, Quaternion.identity);
                break;
            case "drumstick":
                Instantiate(food[2], transform.position, Quaternion.identity);
                break;
            case "wine":
                Instantiate(food[3], transform.position, Quaternion.identity);
                break;
            case "beer":
                Instantiate(food[4], transform.position, Quaternion.identity);
                break; 
                
        }
    }
    
}
