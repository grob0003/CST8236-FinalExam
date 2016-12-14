using UnityEngine;
using System.Collections.Generic;

public class CatBat : MonoBehaviour
{

    public AudioSource catBatAud;


    void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.gameObject.name + " entered the trigger!");
    }

    void OnTriggerStay(Collider collider)
    {
        Debug.Log(collider.gameObject.name + " stayed in the trigger!");
    }

    void OnTriggerExit(Collider collider)
    {
        Debug.Log(collider.gameObject.name + " exited the trigger!");

        Destroy(collider.gameObject);

        if (catBatAud != null)
        {
            catBatAud.Play();
        }
    }
}
