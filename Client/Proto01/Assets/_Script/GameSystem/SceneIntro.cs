using UnityEngine;
using System.Collections;

public class SceneIntro : MonoBehaviour {

	void Start () 
    {
        StartCoroutine(GoNext());
	}

    IEnumerator GoNext()
    {
        yield return new WaitForSeconds(2f);

        SceneManager.Instance.ChangeScene(SceneType.Title);
    }

	
}
