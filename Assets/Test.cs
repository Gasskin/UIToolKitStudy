using UnityEngine;
using UnityEngine.UIElements;

public class Test : MonoBehaviour
{
    public UIDocument document;

    private void Start ()
    {
        var root = document.rootVisualElement;
        var btn  = root.Q<Button> ("button1");

        btn.clicked += (() =>
        {
            Debug.Log ("点击");
        });
    }
}
