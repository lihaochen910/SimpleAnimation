using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(SimpleAnimationGroup))]
public class SimpleAnimationGroupInspector : Editor
{
    ReorderableList reorderableList;

    void OnEnable()
    {
        var prop = serializedObject.FindProperty("_animationStates");

        reorderableList = new ReorderableList(serializedObject, prop);
        reorderableList.elementHeight = 30/* + 80*/;

        reorderableList.drawHeaderCallback = (rect) =>
            EditorGUI.LabelField(rect, "SimpleAnimation预设动画");

        reorderableList.drawElementCallback =
            (rect, index, isActive, isFocused) =>
            {
                var element = prop.GetArrayElementAtIndex(index);
                //rect.height -= 4;
                //rect.y += 2;
                rect.height = 15;
                rect.y += 2;
                EditorGUI.PropertyField(rect, element);
            };

        //reorderableList.onSelectCallback = (list) =>
        //{
        //    var element = prop.GetArrayElementAtIndex(list.index);
        //    selectedClip = element.FindPropertyRelative("clip").objectReferenceValue as AudioClip;
        //};

        var defaultColor = GUI.backgroundColor;
        reorderableList.drawElementBackgroundCallback = (rect, index, isActive, isFocused) =>
        {
            GUI.backgroundColor = Color.green;
        };

    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        reorderableList.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
    }
}
