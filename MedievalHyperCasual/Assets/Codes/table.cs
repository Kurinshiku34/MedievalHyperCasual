using System.Collections;
using UnityEngine;
public class table : MonoBehaviour
{
    public Transform startpoint;
    public bool foodTaken;
    public bool tablefull; 
    void Start()
    {
        gameObject.tag = "emptychair";
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        gameObject.tag = "chair";
        if (foodTaken == false)
        {
            yield return new WaitForSeconds(5);
            gameObject.tag = "emptychair";
        }

        if (foodTaken == true)
        {  
            yield return new WaitForSeconds(5);
            gameObject.tag = "emptychair";
        }

    }


    void update()
    {

        if (tablefull == true)
        {
            gameObject.tag = "chair";
        }

    }


    void OnTriggerEnter(Collider other)
    {
        if (GameObject.FindWithTag("AI"))
        { 
            StartCoroutine("wait");

    
        }

    }


    void OnTriggerStay(Collider other)
    {

        if (GameObject.FindWithTag("chair"))
        {
            tablefull = true;

        }


        if (GameObject.FindWithTag("AI"))
        {
            tablefull = true;

        }


    }

    void OnTriggerExit(Collider other)
    {
        if (GameObject.FindWithTag("AI"))
        {
            tablefull = false;
        }

    }

}
