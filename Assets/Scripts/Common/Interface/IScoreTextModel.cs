using System;
using UniRx;

public interface IScoreTextModel
{
    public event Action OnScoreOverCallBack;
    
    /// <summary>
    /// 表示するスコア
    /// </summary>
    public IReactiveProperty<int> ScoreProp { get; }

    /// <summary>
    /// スコアを加算する
    /// </summary>
    public void AddScore();

    public void Reset();
}
