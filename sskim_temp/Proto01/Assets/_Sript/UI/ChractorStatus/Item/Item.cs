using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    /// 아이템 정의 hp, soul, weapon 
    GameObject player;    
    bool hpItem;
    bool soulItem;
    bool weaponItem;

    // Use this for initialization
    void Awake()
    {
        // Setting up the references.     
        
    }

    // Update is called once per frame
    void Update () {
        
    }   
        
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HPItem"))              //HPItem TAG
        {            
            other.gameObject.SetActive(false);
            hpItem = true;
        }
        if (other.gameObject.CompareTag("SOULItem"))              //SOULItem TAG
        {
            other.gameObject.SetActive(false);
            soulItem = true;
        }
        if (other.gameObject.CompareTag("WEAPONItem"))              //WEAPONItem TAG
        {
            other.gameObject.SetActive(false);
            weaponItem = true;
        }
    }
}
