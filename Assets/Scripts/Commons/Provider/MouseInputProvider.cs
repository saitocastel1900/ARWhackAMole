using UnityEngine;

public class MouseInputProvider : IInputEventProvider
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool InputTapRelease()
    {
        return Input.GetMouseButtonUp(0);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool InputTapPush()
    {
        return Input.GetMouseButtonDown(0);
    }
}
