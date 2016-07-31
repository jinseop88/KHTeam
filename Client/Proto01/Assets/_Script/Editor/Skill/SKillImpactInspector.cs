using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(SkillImpactInfo))]
public class SKillImpactInspector : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        SkillImpactInfo info = target as SkillImpactInfo;

        List<string> names = new List<string>();
        for (int i = 0; i < 32; i++)
            names.Add(LayerMask.LayerToName(i));

        info.m_targetLayer = EditorGUILayout.MaskField(new GUIContent("Layers", "충돌체크할 레이어들"), info.m_targetLayer, names.ToArray());

        serializedObject.ApplyModifiedProperties();
        base.OnInspectorGUI();
    }
}
