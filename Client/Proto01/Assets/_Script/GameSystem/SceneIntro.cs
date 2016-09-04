using UnityEngine;
using System.Collections;

public class SceneIntro : MonoBehaviour {

	void Start ()
    {
        UIManager.Instance.Initialize();

        StartCoroutine(GoNext());
	}

    IEnumerator GoNext()
    {
        yield return new WaitForSeconds(2f);
        
        SceneManager.Instance.ChangeScene(SceneType.Game);
    }

	
}
