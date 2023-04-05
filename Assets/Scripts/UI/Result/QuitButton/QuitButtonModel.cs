using UniRx;

namespace UI.Result.QuitButton
{
    public class QuitButtonModel : IQuitButtonModel
    {
        /// <summary>
        /// 表示をするかのフラグ
        /// </summary>
        public IReactiveProperty<bool> IsShowProp => _isShowProp;
        private BoolReactiveProperty _isShowProp;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public QuitButtonModel()
        {
            _isShowProp = new BoolReactiveProperty(false);
        }
        
        /// <summary>
        /// 表示を更新
        /// </summary>
        /// <param name="IsShow"></param>
        public void SetIsShow(bool IsShow)
        {
            _isShowProp.Value = IsShow;
        }
    }
}
