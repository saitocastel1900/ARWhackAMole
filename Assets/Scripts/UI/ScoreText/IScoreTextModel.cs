using System;
using UniRx;

namespace UI.Main.ScoreText
{
    public interface IScoreTextModel
    {
        /// <summary>
        /// スコアが一定値をオーバーした時に呼ばれる
        /// </summary>
        public IObservable<Unit> OnScoreOverCallBack { get; }

        /// <summary>
        /// 表示するスコア
        /// </summary>
        public IReactiveProperty<int> ScoreProp { get; }

        /// <summary>
        /// スコアを加算する
        /// </summary>
        public void AddScore();

        /// <summary>
        /// リセット
        /// </summary>
        public void Reset();
    }
}