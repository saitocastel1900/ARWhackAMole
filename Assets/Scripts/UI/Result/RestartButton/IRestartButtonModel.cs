using UniRx;

namespace UI.Result.RestartButton
{
    public interface IRestartButtonModel
    {
        /// <summary>
        /// 表示をするかのフラグ
        /// </summary>
        public IReactiveProperty<bool> IsShowProp { get; }

        /// <summary>
        /// オブジェクトを生成したかのフラグの値を設定する
        /// </summary>
        /// <param name="IsShow">設定したい真偽値</param>
        public void SetIsShow(bool IsShow);
    }
}