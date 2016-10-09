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

                    switch (mapType)
                    {
                        // Snow
                        case MapType.Mt_ChunTae1:
                        case MapType.Mt_ChunTae2:
                            renderer.material = magicMaterials[0];
                            magicParticleSystem.startColor = Color.white;
                            break;

                        // Black petal
                        case MapType.Town_Kiwa:
                        case MapType.Town_RockTower:
                            renderer.material = magicMaterials[1];
                            break;
                        
                        // White petal
                        case MapType.Pound_Moon:
                            renderer.material = magicMaterials[1];
                            magicParticleSystem.startColor = Color.white;
                            break;

                        // Rock
                        case MapType.Cave1_Blue:
                            renderer.material = magicMaterials[2];
                            magicParticleSystem.startColor = Color.white;
                            magicParticleSystem.gravityModifier = 0.5f;
                            break;

                        case MapType.Cave2_Purple:
                            renderer.material = magicMaterials[3];
                            magicParticleSystem.startColor = Color.white;
                            magicParticleSystem.gravityModifier = 0.5f;
                            break;

                        case MapType.Cave3_Green:
                            renderer.material = magicMaterials[4];
                            magicParticleSystem.startColor = Color.white;
                            magicParticleSystem.gravityModifier = 0.5f;
                            break;

                        case MapType.Forest1_Green:
                            renderer.material = magicMaterials[5];
                            magicParticleSystem.startColor = Color.white;
                            break;

                        case MapType.Forest2_Blue:
                            renderer.material = magicMaterials[6];
                            magicParticleSystem.startColor = Color.white;
                            break;

                        case MapType.Forest3_Purple:
                        case MapType.Sea_Moon1:
                        case MapType.Sea_Moon2:
                            renderer.material = magicMaterials[7];
                            magicParticleSystem.startColor = Color.white;
                            break;

                        case MapType.Sea_Moon3:
                            renderer.material = magicMaterials[11];
                            magicParticleSystem.startColor = Color.white;
                            break;

                        default:
                            break;
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
                if (monster)
                {
                    monster.GetComponent<Actor>().onDamage(null, null);
                }
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
