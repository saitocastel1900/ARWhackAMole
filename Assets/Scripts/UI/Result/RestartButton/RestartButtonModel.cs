using UI.Result.QuitButton;
using UniRx;

namespace UI.Result.RestartButton
{
    public class RestartButtonModel : IRestartButtonModel
    {
        /// <summary>
        /// 
        /// </summary>
        public IReactiveProperty<bool> IsShowProp => _isShowProp;
        private BoolReactiveProperty _isShowProp;

        /// <summary>
        /// 
        /// </summary>
        public RestartButtonModel()
        {
            _isShowProp = new BoolReactiveProperty(false);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IsShow"></param>
        public void SetIsShow(bool IsShow)
        {
            _isShowProp.Value = IsShow;
        }
    }
}