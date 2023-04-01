using UnityEngine;

public class TouchInputProvider : IInputEventProvider
{
    public bool InputTapRelease()
    {
        return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended;
    }

    public bool InputTapPush()
    {
        return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
    }
}
