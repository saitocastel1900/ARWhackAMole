using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ResetButtonView : MonoBehaviour
{
    [SerializeField] private Button _button;

    public void SetShowView(bool isView)
    {
        _button.interactable=isView;
    }
}
