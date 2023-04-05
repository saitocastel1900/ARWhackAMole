using System;
using Const;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace UI.Main.ScoreText
{
    public class ScoreTextModel : IScoreTextModel
    {
        /// <summary>
        /// スコアが一定値をオーバーした時に呼ばれる
        /// </summary>
        public IObservable<Unit> OnScoreOverCallBack=>_createdObjectSubject;
        private readonly Subject<Unit> _createdObjectSubject = new Subject<Unit>();
        
        /// <summary>
        /// 表示するスコア
        /// </summary>
        public IReactiveProperty<int> ScoreProp => _scoreProp;
        private IntReactiveProperty _scoreProp;
        
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ScoreTextModel()
        {
            _scoreProp = new IntReactiveProperty(0);
        }
        
        /// <summary>
        /// スコアを加算する
        /// </summary>
        public void AddScore()
        {
            _scoreProp.Value++;

            Assert.IsFalse(_scoreProp.Value > InGameConst.ScoreLimit , "スコアが一定量超えています");
           
            //スコアの上限を超えたら、コールバックを実行
            if (_scoreProp.Value >= InGameConst.ScoreLimit)
            {
                _createdObjectSubject?.OnNext(Unit.Default);
            }
        }

        /// <summary>
        /// リセット
        /// </summary>
        public void Reset()
        {
            _scoreProp.Value = 0;
        }
    }
}