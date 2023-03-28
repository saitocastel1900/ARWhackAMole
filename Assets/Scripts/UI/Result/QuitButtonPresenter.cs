using UnityEngine.UI;
using UnityEngine;

public class QuitButtonPresenter : MonoBehaviour
{
    [SerializeField] private Button _button;

    public void Initialize()
    {
        _button.interactable = false;
    }
}
