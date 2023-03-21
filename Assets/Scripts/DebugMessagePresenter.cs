using UnityEngine.UI;
using UnityEngine;

public class DebugMessagePresenter : MonoBehaviour
{
   [SerializeField] private Text _messageText;
   
   public void ShowMessage(string text)
   {
      _messageText.text = $"{text}\r\n";
   }
  
   public void AddMessage(string text)
   {
      _messageText.text += $"{text}\r\n";
   }
   
   public string SetTextForUI<T>(string label,T? data) where T : struct
   {
      var result = data.HasValue ? "〇" : "×";
      return $"{label}:{result}";
   }
}
