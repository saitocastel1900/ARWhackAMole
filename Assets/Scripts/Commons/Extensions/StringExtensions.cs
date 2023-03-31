namespace Extensions
{
    public class StringExtensions
    {
        /// <summary>
        /// 真偽値に対応した○×を返す
        /// </summary>
        public string SetTextForUI<T>(string label, T? data) where T : struct
        {
            var result = data.HasValue ? "〇" : "×";
            return $"{label}:{result}";
        }
    }
}