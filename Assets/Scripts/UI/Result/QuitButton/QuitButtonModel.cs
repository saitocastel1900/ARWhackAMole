using UniRx;

namespace UI.Result.QuitButton
{
    public class QuitButtonModel : IQuitButtonModel
    {
        /// <summary>
        /// 
        /// </summary>
        public IReactiveProperty<bool> IsShowProp => _isShowProp;
        private BoolReactiveProperty _isShowProp;

        /// <summary>
        /// 
        /// </summary>
        public QuitButtonModel()
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
