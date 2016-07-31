using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(Animation2D))]
public class Animation2DInspector : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        Animation2D anim = target as Animation2D;
        SerializedProperty sp = serializedObject.FindProperty("m_animator");
        Animator animator = sp.objectReferenceValue as Animator;

        for(int i = 0 ; i < (int)GameType.AnimationState.Max ; i++)
        {
            Animation2D.AnimStateInfo stateInfo = anim.m_animStateInfo.Find(arg => arg.state == (GameType.AnimationState)i);

            if(stateInfo == null)
            {
                stateInfo = new Animation2D.AnimStateInfo();
                anim.m_animStateInfo.Add(stateInfo);
            }

            stateInfo.state = (GameType.AnimationState)i;
            stateInfo.name = ((GameType.AnimationState)i).ToString();
            stateInfo.nameHash = Animator.StringToHash(stateInfo.name);
            stateInfo.clip = EditorGUILayout.ObjectField(stateInfo.name, stateInfo.clip, typeof(AnimationClip), false) as AnimationClip;

            EditorUtility.SetDirty(anim);
            serializedObject.ApplyModifiedProperties();
        }

        base.OnInspectorGUI();
    }
}
