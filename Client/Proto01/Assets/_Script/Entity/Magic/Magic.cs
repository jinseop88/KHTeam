using UnityEngine;
using System.Collections;

// TODO: Replace to Skill
public class Magic : MonoBehaviour
{
    public GameObject magicPrefabs = null;
    public Transform magicPosition = null;

    private GameObject magic = null;
    private ParticleSystem particleSystem = null;

    void Update()
    {
        if (magic == null && Input.GetMouseButtonDown(0))
        {
            magic = Instantiate(magicPrefabs, magicPosition.position, magicPosition.rotation) as GameObject;
            particleSystem = magic.GetComponentInChildren<ParticleSystem>();

            foreach(GameObject monster in GameObject.FindGameObjectsWithTag("monster"))
            {
                monster.GetComponent<Actor>().onDamage(null, null);
            }

            StartCoroutine(DestroyMagic());
        }
    }

    IEnumerator DestroyMagic()
    {
        yield return new WaitUntil(() => !particleSystem.isPlaying);

        Destroy(magic);
        magic = null;
        particleSystem = null;
    }
}
