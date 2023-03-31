using UI.DebugMessage;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace Manager
{
    public class Hammer : MonoBehaviour
    {
        [Inject] private IInputEventProvider _input;

        private void Start()
        {
            this.UpdateAsObservable()
                .Where(_ => _input.InputTap())
                .Subscribe(_ =>
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit = new RaycastHit();

                    if (Physics.Raycast(ray, out hit))
                    {
                        hit.transform.GetComponent<IDamagable>()?.Damage();
                    }
                }).AddTo(this);
        }
    }
}