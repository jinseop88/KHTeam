using UnityEngine;
using System.Collections;

// TODO: Replace to Skill
public class Magic : MonoBehaviour, IGameEventListener
{
    public GameObject magicPrefabs = null;
    public Material[] magicMaterials = null;

    private static GameObject magic = null;
    private ParticleSystem magicParticleSystem = null;
    private MapType mapType = MapType.Mt_ChunTae1;

    void Start()
    {
        GameEventManager.Register(this);
    }

    public void OnGameEvent(GameEventType gameEventType, params object[] args)
    {
        switch (gameEventType)
        {
            case GameEventType.CastMagic:
                if (magic == null)
                {
                    magic = Instantiate(magicPrefabs, Vector3.zero, magicPrefabs.transform.rotation) as GameObject;
                    magic.transform.parent = Camera.main.transform;

                    magic.transform.position = Camera.main.transform.position + new Vector3(0.0f, 2.5f, 15.0f);

                    magicParticleSystem = magic.GetComponentInChildren<ParticleSystem>();

                    Renderer renderer = magicParticleSystem.GetComponentInChildren<Renderer>();

                    if (mapType == MapType.Mt_ChunTae1 || mapType == MapType.Mt_ChunTae2)
                    {
                        renderer.material = magicMaterials[0];
                        magicParticleSystem.startColor = Color.white;
                    }
                    else if (mapType == MapType.Town_Kiwa || mapType == MapType.Town_RockTower)
                    {
                        renderer.material = magicMaterials[1];
                        magicParticleSystem.startColor = Color.black;
                    }
                    else
                    {
                        renderer.material = magicMaterials[1];
                        magicParticleSystem.startColor = Color.white;
                    }

                    magicParticleSystem.Play();

                    StartCoroutine(AttackMonster());
                    StartCoroutine(DestroyMagic());
                }
                break;
            case GameEventType.MapChanged:
                {
                    mapType = (MapType)args[0];
                }
                break;
            default:
                break;
        }
    }

    IEnumerator AttackMonster()
    {
        while (true)
        {
            foreach(GameObject monster in GameObject.FindGameObjectsWithTag("monster"))
            {
                // TODO : Give damage to monster
                monster.GetComponent<Actor>().onDamage(null, null);
            }

            yield return new WaitForSeconds(1.0f);
        }
    }

    IEnumerator DestroyMagic()
    {
        yield return new WaitUntil(() => !magicParticleSystem.isPlaying);

        StopCoroutine("AttackMonster");

        Destroy(magic);
        magic = null;
        magicParticleSystem = null;
    }
}
