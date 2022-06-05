public delegate void ButtonAction();
public class ButtonData
{

    private string _buttonText;
    private ButtonAction _action;

    public ButtonData(string text)
    {
        _buttonText = text;
    }
    public ButtonData(string text, ButtonAction action)
    {
        _buttonText = text;
        _action = action;
    }

    public string ButtonText { get => _buttonText; set => _buttonText = value; }
    public ButtonAction Action { get => _action; set => _action = value; }
}
