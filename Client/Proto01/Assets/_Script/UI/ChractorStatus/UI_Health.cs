using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public int StartHealth = 100;
    public int CurrentHealth;
    public int attackDamage = 10;

    public Object hp__Item;
   
    bool damaged;



    // Use this for initialization
    void Awake()
    {
        CurrentHealth = StartHealth;
    }

    // Update is called once per frame
    void Update () {

        TakeDamage(attackDamage);
       
	
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

    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Soul_Item"))              //HPItem TAG
        {
           
        }

    }



}
