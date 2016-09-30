using UnityEngine;											
using System.Collections;											

public class FadeScreen : SingleTon<FadeScreen>											
{											
	public bool m_bStartOnEnable = false;										
	public AnimationCurve m_fadeCurve;										
	public Color m_fadeColour;				

	private Texture2D m_texture = null;										
	private float m_fTime;										
	private GameObject m_thisObject;																		

	public void StartFadeScreen(float startTime, float startValue, float endTime, float endValue, Color color)										
	{										
		m_fadeCurve = new AnimationCurve(new Keyframe(startTime, startValue), new Keyframe(endTime, endValue));									
		m_fadeColour = color;									

		m_thisObject.SetActive(true);									

		StopCoroutine("StartFade");											

		Undo();											

		StartCoroutine("StartFade");											
	}										

	IEnumerator StartFade()										
	{										
		m_fTime = m_fadeCurve.keys[m_fadeCurve.length - 1].time;									

		float elapsedTime = 0.0f;									
		while (elapsedTime < m_fTime)									
		{									
			elapsedTime += Time.deltaTime;								

			Process(elapsedTime);								

			yield return null;								
		}									

		Undo();									

		m_thisObject.SetActive(false);											
	}										

	public void Process(float deltaTime)										
	{										
		if (m_texture == null)											
		{											
			m_texture = new Texture2D(1, 1, TextureFormat.ARGB32, false);											
		}											

		float alpha = m_fadeCurve.Evaluate(deltaTime);									

		alpha = Mathf.Min(Mathf.Max(0.0f, alpha), 1.0f);									

		m_texture.SetPixel(0, 0, new Color(m_fadeColour.r, m_fadeColour.g, m_fadeColour.b, alpha));										
		m_texture.Apply();									
	}										

	public void End()										
	{										
		if (m_texture == null)											
		{											
			m_texture = new Texture2D(1, 1, TextureFormat.ARGB32, false);											
		}											

		float alpha = m_fadeCurve.Evaluate(m_fadeCurve.keys[m_fadeCurve.length - 1].time);									

		alpha = Mathf.Min(Mathf.Max(0.0f, alpha), 1.0f);									

		m_texture.SetPixel(0, 0, new Color(m_fadeColour.r, m_fadeColour.g, m_fadeColour.b, alpha));										
		m_texture.Apply();									
	}										

	public void Stop()										
	{										
		StopCoroutine("StartFade");											
		Undo();									

		m_thisObject.SetActive(false);											
	}										

	public void Undo()										
	{										
		if (m_texture == null)											
		{											
			m_texture = new Texture2D(1, 1, TextureFormat.ARGB32, false);											
		}											

		m_texture.SetPixel(0, 0, new Color(m_fadeColour.r, m_fadeColour.g, m_fadeColour.b, 0.0f));										
		m_texture.Apply();									
	}										

	void OnGUI()										
	{										
		if(!m_texture)									
			return;								

		int previousDepth = GUI.depth;									

		GUI.depth = 0;									
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), m_texture);									

		GUI.depth = previousDepth;									
	}										

	void OnEnable()										
	{										
		if(m_texture == null)									
			m_texture = new Texture2D(1, 1, TextureFormat.ARGB32, false);								

		m_texture.SetPixel(0, 0, new Color(m_fadeColour.r, m_fadeColour.g, m_fadeColour.b, 0.0f));										
		m_texture.Apply();									

		if (m_bStartOnEnable)											
		{											
			StartCoroutine(StartFade());											
		}											
		else											
		{											
			//m_thisObject.SetActive(false);											
		}											
	}										

	void Awake()										
	{										
		m_thisObject = gameObject;											

		DontDestroyOnLoad(gameObject);											
	}										
}											
