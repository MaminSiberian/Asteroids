using UnityEngine;

public class PCInputHandler : InputHandlerBase
{
    public override float HorizontalSpeed()
    {
        return Input.GetAxis("Horizontal");
    }

    public override float VerticalSpeed()
    {
        return Input.GetAxis("Vertical");
    }
}
