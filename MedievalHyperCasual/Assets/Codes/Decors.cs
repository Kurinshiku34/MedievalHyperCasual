using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decors : MonoBehaviour
{
    public GameObject AI;
    public GameObject Spawner;
    public GameObject flower;
    public GameObject carpet;
    public GameObject picture;
    public GameObject window;
    public GameObject furnace;
    public GameObject touch;

    void Start()
    {
        InvokeRepeating(nameof(Spawn), 1f, 10f);

        if (flower.scene.IsValid())
        {
            CancelInvoke();
            InvokeRepeating(nameof(Spawn), 2f, 5f);

        }
        else if (carpet.scene.IsValid())
        {
            CancelInvoke();
            InvokeRepeating(nameof(Spawn), 2f, 5f);
        }
        else if (picture.scene.IsValid())
        {
            CancelInvoke();
            InvokeRepeating(nameof(Spawn), 2f, 5f);
        }
        else if (window.scene.IsValid())
        {
            CancelInvoke();
            InvokeRepeating(nameof(Spawn), 2f, 5f);
        }
        else if (furnace.scene.IsValid())
        {
            CancelInvoke();
            InvokeRepeating(nameof(Spawn), 2f, 5f);
        }
        else if (touch.scene.IsValid())
        {
            CancelInvoke();
            InvokeRepeating(nameof(Spawn), 2f, 5f);
        }
    }
    void Spawn()
    {

        Instantiate(AI, transform.position, Quaternion.identity);
    }
}
