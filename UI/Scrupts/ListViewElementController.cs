using UnityEngine.UIElements;


public class ListViewElementController
{
    Button button;

    public void SetVisualElement(VisualElement visualElement)
    {
        button = visualElement.Q<Button>("MyButton");
    }

    public void SetElementLabel(string label)
    {
        button.text = label;
    }
}
