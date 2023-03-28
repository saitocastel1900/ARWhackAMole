using UniRx;

public interface IScoreTextModel
{
    /// <summary>
    /// 表示するスコア
    /// </summary>
    public IReactiveProperty<int> ScoreProp { get; }

    /// <summary>
    /// スコアを加算する
    /// </summary>
    public void AddScore();
}
