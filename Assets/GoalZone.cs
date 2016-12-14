using UnityEngine;
using System.Collections.Generic;

public class GoalZone : MonoBehaviour
{

    public AudioSource goalAudio;

    // Reference to all the particle systems we want to fire when a goal is scored.
    public List<ParticleSystem> goalParticleSystems;

    /* If you're working with a triggered collision (intersection),
   * this is called when the triggered collision starts. */
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.gameObject.name + " entered the trigger!");
    }

    /* If you're working with a triggered collision (intersection),
     * this is called as the triggered collision continues to occur. */
    void OnTriggerStay(Collider collider)
    {
        Debug.Log(collider.gameObject.name + " stayed in the trigger!");
    }

    /* If you're working with a triggered collision (intersection),
     * this is called when the triggered collision ends. */
    void OnTriggerExit(Collider collider)
    {
        Debug.Log(collider.gameObject.name + " exited the trigger!");
        Destroy(collider.gameObject);

        // Start the particle systems.
        foreach (ParticleSystem system in goalParticleSystems)
        {
            system.Play();
        }

        if (goalAudio != null)
        {
            goalAudio.Play();
        }
    }
}
