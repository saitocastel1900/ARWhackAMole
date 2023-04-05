using Const;
using DG.Tweening;
using UniRx;
using UnityEngine;
using Utility;

namespace WhackAMole.Mole
{
    public class MoleMover : BaseMole
    {
        /// <summary>
        /// モグラの位置が地表上にいるか
        /// </summary>
        private ReactiveProperty<bool> _isGrounded = new BoolReactiveProperty(true);

        /// <summary>
        /// モグラを動かすのTweenのキャッシュ
        /// </summary>
        private Tween _tween;

        protected override void OnInitialize()
        {
            //ダメージを受けたら潜る
            _moleCore
                .OnDamagedCallBack
                .Subscribe(_ =>
                {
                    _isGrounded.Value = true;
                })
                .AddTo(this);

            //モグラの位置によって、動きを決める
            _isGrounded
                .DistinctUntilChanged()
                .Subscribe(value =>
            {
                if (value)
                {
                    Down();
                }
                else
                {
                    Up();
                }
            }).AddTo(this);
            
            Down();
        }

        /// <summary>
        /// 上昇
        /// </summary>
        private void Up()
        {
            _tween = InGameAnimationUtility.MoleUpTween(transform)
                .SetEase(Ease.Linear)
                .SetLink(this.gameObject).OnComplete(()=>_isGrounded.Value = true);
        }

        /// <summary>
        /// 下降
        /// </summary>
        private void Down()
        {
            _tween= InGameAnimationUtility.MoleDownTween(transform)
                .SetEase(Ease.Linear)
                .SetLink(this.gameObject).OnComplete(()=>_isGrounded.Value = false);
        }

        /// <summary>
        /// リセット
        /// </summary>
        public void Reset()
        {
            _tween.Kill(true);
            transform.position = new Vector3(0,InGameConst.MoleInitialLocalPosition.y,0);
        }
    }
}