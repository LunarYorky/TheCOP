using UnityEngine.UIElements;


public class ListViewElementController
{
    Label elemetName;

    public void SetVisualElemet(VisualElement visualElement)
    {
        elemetName = visualElement.Q<Label>();
    }

    public void SetElemetData(ButtonData data)
    {
        elemetName.text = data.ButtonText;
    }
}
