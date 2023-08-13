using UnityEngine;

public enum InputType
{
    PC,
    Android
}

public class InputManager : MonoBehaviour
{
    [SerializeField] private Camera _cam;
    public static Camera cam { get; private set; }

    [SerializeField] private InputType _inputType;
    public static InputType inputType { get; private set; }

    private InputHandlerBase inputHandler;
    public static float horizontalSpeed { get; private set; }
    public static float verticalSpeed { get; private set; }

    private void Awake()
    {
        cam = _cam;
        inputType = _inputType;
        SetInputType();
    }

    private void SetInputType()
    {
        switch (inputType)
        {
            case InputType.PC:
                inputHandler = new PCInputHandler();
                break;
            case InputType.Android:
                //inputHandler = new AndroidInputHandler();
                break;
        }
    }
    private void Update()
    {
        horizontalSpeed = inputHandler.HorizontalSpeed();
        verticalSpeed = inputHandler.VerticalSpeed();
    }
}
