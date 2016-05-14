using UnityEngine;
using System.Collections;

public class Health : Item {

    public int StartHealth = 100;
    public int CurrentHealth;
    public int attackDamage = 10;

    Item hpItem;
   
    bool damaged;



    // Use this for initialization
    void Awake()
    {
        CurrentHealth = StartHealth;
    }

    // Update is called once per frame
    void Update () {

        if(hpItem == true)
        {
            TakeDamage(attackDamage);
        }
	
	}

    public void TakeDamage(int amount)
    {
        //damaged = true;
        CurrentHealth -= amount;
        if(CurrentHealth <= 0)
        {

        }       

        /*if(CurrentHealth <=0 && !isDead){
			Death ();
		}*/
    }


      
}
