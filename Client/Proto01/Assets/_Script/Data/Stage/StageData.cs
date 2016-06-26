using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StageData
{
    public int index;
    public string name;

    public int chapterIndex;

}

public class StageInfo : SingleTon<StageInfo>
{
    private List<StageData> m_dataList = new List<StageData>();

    public static List<StageData> GetStageListByChapterIndex(int chapterIndex)
    {
        return Instance.m_dataList.FindAll(arg => arg.chapterIndex == chapterIndex);
    }
}

