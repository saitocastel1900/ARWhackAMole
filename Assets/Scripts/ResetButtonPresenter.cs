using UniRx;
using UnityEngine;
using UnityEngine.Events;

namespace UI.ResetButton
{
    public class ResetButtonPresenter : MonoBehaviour
    {
        /// <summary>
        /// ボタンをクリックしたときに呼ばれる
        /// </summary>
        public event UnityAction OnClickCallBack;

        /// <summary>
        /// View
        /// </summary>
        [SerializeField] private ResetButtonView _view;
        
        /// <summary>
        /// Model
        /// </summary>
        private ResetButtonModel _model;

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialize()
        {
            _model = new ResetButtonModel();

            Bind();
        }

        /// <summary>
        /// Bind
        /// </summary>
        private void Bind()
        {
            _model.IsCreatedProp
                .DistinctUntilChanged()
                .Subscribe(_view.SetShowView)
                .AddTo(this);
        }

        /// <summary>
        /// ボタンをクリックした時のイベント
        /// </summary>
        public void OnButtonClick()
        {
            OnClickCallBack?.Invoke();
            _model.SetIsCreated(false);
        }

        /// <summary>
        /// オブジェクトを生成したかのフラグの値を設定する
        /// </summary>
        /// <param name="IsCreated">設定したい真偽値</param>
        public void SetIsCreated(bool IsCreated)
        {
            _model.SetIsCreated(IsCreated);
        }
    }
}