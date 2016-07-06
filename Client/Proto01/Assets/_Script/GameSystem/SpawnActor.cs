using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnActor : MonoBehaviour
{
    public GameObject actor;
    public int maxActorCount;
    public float timeInterval;

    private List<GameObject> standbyActors = new List<GameObject>();
    private List<GameObject> actionActors = new List<GameObject>();

    void OnEnable()
    {
        // Start to create actor and to participate actor.
        StartCoroutine(CreateActor());
        StartCoroutine(ParticipateActor());
    }

    void OnDisable()
    {
        // Stop to create actor and to participate actor.
        StopAllCoroutines();
    }

    private void OnActorDied(GameObject actor)
    {
        actionActors.Remove(actor);
    }

    private IEnumerator CreateActor()
    {
        while (true)
        {
            // Clean up the deleted actors.
            actionActors.RemoveAll(performer => performer == null);

            if (standbyActors.Count + actionActors.Count < maxActorCount)
            {
                // Create the new performer and initialize.
                GameObject performer = Instantiate(actor, transform.position, transform.rotation) as GameObject;
                performer.SetActive(false);
                performer.transform.parent = transform.parent;

                // New performer standby.
                standbyActors.Add(performer);
            }

            yield return new WaitForSeconds(timeInterval);
        }
    }

    private IEnumerator ParticipateActor()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeInterval);

            // Clean up the deleted actors.
            actionActors.RemoveAll(performer => performer == null);

            if (standbyActors.Count != 0)
            {
                // Now showtime for the performer in standby.
                GameObject performer = standbyActors[0];
                performer.SetActive(true);

                // Remove the performer from the list of standby.
                standbyActors.Remove(performer);

                // Add the performer into the list of action.
                actionActors.Add(performer);
            }
        }
    }
}
