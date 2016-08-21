using UnityEngine;
using System.Collections;

// TODO: Replace to Skill
public class Magic : MonoBehaviour
{
    public GameObject magicPrefabs = null;

    private GameObject magic = null;
    private ParticleSystem particleSystem = null;

    void Update()
    {
        if (magic == null && Input.GetMouseButtonDown(0))
        {
            magic = Instantiate(magicPrefabs, Vector3.zero, magicPrefabs.transform.rotation) as GameObject;
            magic.transform.parent = Camera.main.transform;

            magic.transform.position = Camera.main.transform.position + new Vector3(0.0f, 2.5f, 15.0f);

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
