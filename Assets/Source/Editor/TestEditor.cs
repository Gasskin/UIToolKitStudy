using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(Test))]
public class TestEditor : Editor
{
    private SerializedProperty go;
    
    private void OnEnable()
    {
        go = serializedObject.FindProperty("c");
    }

    public override VisualElement CreateInspectorGUI()
    {
        var inspector = new VisualElement();
        var tree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/UXML.uxml");

        tree.CloneTree(inspector);

        inspector.Q<Button>().clicked += () =>
        {
            Debug.Log(go.objectReferenceValue.name);
        };

        return inspector;
    }
}

