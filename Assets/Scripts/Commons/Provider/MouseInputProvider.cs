using UnityEngine;

public class MouseInputProvider : IInputEventProvider
{
    public bool InputTap()
    {
        return Input.GetMouseButtonUp(0);
    }
}
