using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceManager : SingleTon<ResourceManager>
{
    /// <summary>
    /// 리소스 로드된것들.
    /// </summary>
    private Dictionary<string, object> m_loadedResourceList = new Dictionary<string, object>();


    //public T LoadResource<T>(string szName, string szFullPath) where T : object
    //{
    //    //T obj = Resources.Load(szFullPath, typeof(T)) as T;

    //    if(obj != null)
    //    {
    //        m_loadedResourceList.Add(szName, obj);
    //    }

    //    return obj;
    //}

}
