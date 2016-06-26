using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_Soul : MonoBehaviour
{

    //public Text soulCount; 
    public Text SoulCountText;
    public int soulItemCount = 0;   

    // Use this for initialization
    void Start () {
	
	}
    

    // Update is called once per frame
    void Update () {

        SoulCountText.text = soulItemCount.ToString();

    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Seed1"))              //Seed1
        {
            CollectSeed();
        }

    }
    public void CollectSeed()
    {
        soulItemCount++;

    }
}
