using UnityEngine;
using System.Collections;

public class UI_Soul : Item {

    //public Text soulCount;
    public int soulItemCount = 0;

    Item soulItem;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (soulItem == true)
        {
            soulItemCount++;
            //soulCount.text = soulItemCount;
        }

    }
}
