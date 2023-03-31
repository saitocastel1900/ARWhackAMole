using UnityEngine;

public class TouchInputProvider : IInputEventProvider
{
    public bool InputTap()
    {
        return Input.touchCount > 0;
    }
}
