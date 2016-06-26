using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ChapterData 
{
    public int index;
    public string name;
}
public class ChapterInfo : SingleTon<ChapterInfo>
{
    private List<ChapterData> m_dataList = new List<ChapterData>();


}
