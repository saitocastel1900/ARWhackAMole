using UniRx;

namespace UI.ScoreText
{
    public class ScoreTextModel : IScoreTextModel
    {
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
        }
    }
}