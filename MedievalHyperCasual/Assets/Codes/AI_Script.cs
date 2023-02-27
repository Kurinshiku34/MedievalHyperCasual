using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AI_Script : MonoBehaviour
{
    public NavMeshAgent AII;
    public Transform startPoint;
    public table table;
    public Rigidbody rigidbody;
    public Player player;
    public Food food;
    public bool foodchoosing;
    public bool coroutinePlaying;
    public bool WalkingToTable;
    int customerChoice;
    string[] menu = { "chicken", "beer", "drumstick", "wine", "Beef" };
    void Start()
    {
        WalkingToTable = true;
        coroutinePlaying = true;
        foodchoosing = false;
        customerChoice = Random.Range(0, menu.Length);
        Debug.Log(customerChoice);
        StartCoroutine("walk");
        startPoint = GameObject.Find("StartPoint").transform;
        rigidbody = GameObject.FindWithTag("AI").GetComponent<Rigidbody>();
        AII = GameObject.FindWithTag("AI").GetComponent<NavMeshAgent>();
        table = GameObject.Find("table").GetComponent<table>();
        player = GameObject.Find("player").GetComponent<Player>();
        food = GameObject.Find("food").GetComponent<Food>();
    }

    void Update()
    {
        if (WalkingToTable == false)
        {
            StopCoroutine("walk");
        }
    }



    IEnumerator walk()
    {
        if (GameObject.FindWithTag("emptychair") && WalkingToTable == true)
        {
            Debug.Log("yürüme devrede");
            yield return new WaitForSeconds(0);
            AII.SetDestination(GameObject.FindWithTag("emptychair").transform.position);
            StopCoroutine("walk");
        }
    }

        IEnumerator wait()
        {
            Debug.Log("wait devreye girdi");
            AII.SetDestination(Vector3.zero);
            rigidbody.constraints = RigidbodyConstraints.FreezePosition;
            yield return new WaitForSeconds(5);
            rigidbody.constraints = RigidbodyConstraints.None;
            AII.SetDestination(startPoint.position);
            yield return new WaitForSeconds(4);
            Debug.Log("Where Are my foods");
            Destroy(this.gameObject);
            StopCoroutine("wait");

        }

    IEnumerator eat()
    {
        Debug.Log("eat devreye girdi");
        table.foodTaken = true;   
        yield return new WaitForSeconds(5);
        Debug.Log("5 sn geçti hareket ediliyor");
        AII.SetDestination(startPoint.position);
        yield return new WaitForSeconds(4);
        Destroy(this.gameObject);
        Debug.Log("thanks");
        StopCoroutine("eat");
    }

    IEnumerator wrong()
    {
        Debug.Log("wrong devreye girdi");
        table.foodTaken = true;
        AII.SetDestination(startPoint.position);
        yield return new WaitForSeconds(4);
        Destroy(this.gameObject);
        Debug.Log("its wrong!");
        StopCoroutine("eat");
    }



    void OnTriggerEnter(Collider col)
        {

        if (col.gameObject.tag == "emptychair")
        {
            WalkingToTable = false;
            foodchoosing = true;
            Debug.Log("wait col devreye girdi");
            StopCoroutine("walk");
            StartCoroutine("wait");
         
        }


        if ((col.gameObject.tag == "PLAYER") && (player.foodGiven == customerChoice) && (foodchoosing == true))
            { 
            Debug.Log("eat col devreye girdi");
            StopCoroutine("wait");
            Debug.Log("wait durdu");
            StartCoroutine("eat");
            foodchoosing = false;         
            }


        if ((col.gameObject.tag == "PLAYER") && (player.foodGiven != customerChoice) && (foodchoosing == true))
        {
            Debug.Log("wrong col devreye girdi");
            StopCoroutine("wait");
            Debug.Log("wait durdu");
            StartCoroutine("wrong");
            foodchoosing = false;
        }

   
    
    
    
    
    
    
    }

  


}

