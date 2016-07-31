using UnityEngine;
using System.Collections;

public class CharacterManager : SingleTon<CharacterManager>
{
    public Character CreateCharacter()
    {
        GameObject objCharacter = Resources.Load("Prefabs/Character/Character") as GameObject;

        GameObject clone = GameObject.Instantiate(objCharacter) as GameObject;
        Character character = clone.GetComponent<Character>();

        return character;
    }

}
