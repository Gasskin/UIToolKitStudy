using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
using Random = System.Random;

public class Test : MonoBehaviour
{
    public UIDocument document;
    public VisualTreeAsset asset;
    
    private void Start()
    {
        var root = document.rootVisualElement;
        var scroll = root.Q<ListView>();

        var items = new List<ListData>();
        for (int i = 0; i < 10000; i++)
        {
            items.Add(new ListData { name = $"新年快乐{i}", color = new Color(i/10000f,i/20000f,i/5000f, 1f) });
        }

        scroll.fixedItemHeight = 50f;
        scroll.itemsSource = items;
        scroll.makeItem = () => asset.CloneTree();
        scroll.bindItem = (element, i) =>
        {
            element.Q<Label>().text = items[i].name;
            element.Q<VisualElement>("img1").style.backgroundColor = items[i].color;
        };
        scroll.onSelectedIndicesChange += ints =>
        {
            foreach (var index in ints)
            {
                scroll.itemsSource[index] = new ListData { name = $"我被选中了{index}",color = Color.red};
            }
        };
    }

    class ListData
    {
        public string name;
        public Color color;
    }
}
