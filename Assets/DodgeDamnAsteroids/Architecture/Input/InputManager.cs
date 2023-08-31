using Unity.VisualScripting;
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

    private IInputHandler inputHandler;
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
                inputHandler = this.AddComponent<PCInputHandler>();
                break;
            case InputType.Android:
                inputHandler = this.AddComponent<AndroidInputHandler>();
                break;
        }
    }
    private void Update()
    {
        horizontalSpeed = inputHandler.HorizontalSpeed();
        verticalSpeed = inputHandler.VerticalSpeed();
    }
}
