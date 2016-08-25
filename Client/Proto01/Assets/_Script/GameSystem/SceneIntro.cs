using UnityEngine;
using System.Collections;

public class SceneIntro : MonoBehaviour {

	void Start ()
    {
        UIManager.Instance.Initialize();
        UIManager.Instance.OpenUI<UI_Title>(eUIType.Title);

        Time.timeScale = 3f;
        PlayerPrefs.DeleteAll();
        StartCoroutine(GoNext());
	}

    IEnumerator GoNext()
    {
        yield return new WaitForSeconds(0.5f);
        
        SceneManager.Instance.ChangeScene(SceneType.Game);
    }

	
}
