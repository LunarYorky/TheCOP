using UnityEngine.UIElements;


public class ListViewElementController
{
    Label Label;

    public void SetVisualElement(VisualElement visualElement)
    {
        Label = visualElement.Q<Label>("MyButton");
    }

    public void SetElementLabel(string label)
    {
        Label.text = label;
    }
}
