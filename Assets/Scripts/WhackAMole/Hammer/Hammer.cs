using UI.DebugMessage;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace WhackAMole.Hammer
{
    public class Hammer : MonoBehaviour
    {
        /// <summary>
        /// Input
        /// </summary>
        [Inject] private IInputEventProvider _input;

        private void Start()
        {
            //入力があったら、もぐらをハンマーで叩く
            this.UpdateAsObservable()
                .Where(_ => _input.InputTapRelease())
                .Subscribe(_ =>
                {
                    if (EventSystem.current.IsPointerOverGameObject()) return;

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