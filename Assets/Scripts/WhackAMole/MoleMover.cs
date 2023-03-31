using DG.Tweening;
using UniRx;
using Utility;

namespace WhackAMole
{
    public class MoleMover : BaseMole
    {
        /// <summary>
        /// 
        /// </summary>
        private ReactiveProperty<bool> _isGrounded = new BoolReactiveProperty(true);

        protected override void OnInitialize()
        {
            //
            _moleCore
                .OnDamagedCallBack
                .Subscribe(_ =>
                {
                    _isGrounded.Value = true;
                })
                .AddTo(this);

            //
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
        /// 
        /// </summary>
        private void Up()
        {
            InGameAnimationUtility.MoleUpTween(transform)
                .SetEase(Ease.Linear)
                .SetLink(this.gameObject).onComplete+=()=>_isGrounded.Value = true;
        }

        /// <summary>
        /// 
        /// </summary>
        private void Down()
        {
            InGameAnimationUtility.MoleDownTween(transform)
                .SetEase(Ease.Linear)
                .SetLink(this.gameObject).onComplete+=()=>_isGrounded.Value = false;
        }
    }
}