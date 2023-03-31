using UniRx;

public interface IRotationSliderModel
{
    /// <summary>
    /// オブジェクトを生成したかのフラグ
    /// </summary>
    public IReactiveProperty<bool> IsCreatedProp { get; }

    /// <summary>
    /// オブジェクトを生成したかのフラグの値を設定する
    /// </summary>
    /// <param name="IsCreated">設定したい真偽値</param>
    public void SetIsCreated(bool IsCreated);
}
