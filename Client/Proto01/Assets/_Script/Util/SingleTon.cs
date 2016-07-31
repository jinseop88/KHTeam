using UnityEngine;
using System.Collections;

public class SingleTon<T> : MonoBehaviour where T : MonoBehaviour,new()
{
    private static T m_instance;

    public static T Instance 
    {
        get
        {
            if (m_instance == null)
            {
                GameObject tempInstance = new GameObject( );
                m_instance = tempInstance.AddComponent<T>();
                m_instance.name = typeof(T).Name + "(singleton)";
                DontDestroyOnLoad(m_instance);
            }

            return m_instance;
        }
    }
}
