using UnityEngine;
using System.Collections;

public class UI_Health : MonoBehaviour {

    //public Text weaponCount;
    public int weaponItemCount = 0;
    Item weaponItem;    

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (weaponItem == true)
        {
            weaponItemCount++;
            //weaponCount.text = weaponItemCount;
        }

    }
}
