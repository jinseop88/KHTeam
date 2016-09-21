using UnityEngine;
using System.Collections;

// TODO: Replace to Skill
public class Magic : MonoBehaviour, IGameEventListener
{
    public GameObject magicPrefabs = null;
    public Material[] magicMaterials = null;

    private GameObject magic = null;
    private ParticleSystem particleSystem = null;

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

                    particleSystem = magic.GetComponentInChildren<ParticleSystem>();

                    foreach(GameObject monster in GameObject.FindGameObjectsWithTag("monster"))
                    {
                        monster.GetComponent<Actor>().onDamage(null, null);
                    }

                    StartCoroutine(DestroyMagic());
                }
                break;
            case GameEventType.MapChanged:
                {
                    MapType mapType = (MapType)args[0];

                    ParticleSystem particleSystem = magicPrefabs.GetComponentInChildren<ParticleSystem>();
                    Renderer renderer = magicPrefabs.GetComponentInChildren<Renderer>();

                    if (mapType == MapType.Mt_ChunTae1 || mapType == MapType.Mt_ChunTae2)
                    {
                        renderer.material = magicMaterials[0];
                    }
                    else if (mapType == MapType.Town_Kiwa || mapType == MapType.Town_RockTower)
                    {
                        renderer.material = magicMaterials[1];
                        particleSystem.startColor = Color.black;
                    }
                    else
                    {
                        renderer.material = magicMaterials[1];
                        particleSystem.startColor = Color.white;
                    }
                }
                break;
            default:
                break;
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
