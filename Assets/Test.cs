using UnityEngine;
using UnityEngine.UIElements;

public class Test : MonoBehaviour
{
    public UIDocument document;
    public Transform head;
    
    private VisualElement visualElement;
    
    private void Start()
    {
        visualElement = document.rootVisualElement.Q<VisualElement>("hp");
    }

    private void Update()
    {
        visualElement.transform.position =
            RuntimePanelUtils.CameraTransformWorldToPanel(visualElement.panel, head.position, Camera.main);
    }
}
