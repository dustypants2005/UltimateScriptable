using UnityEngine;
namespace UltimateScriptable.Variables {
  [CreateAssetMenu(fileName = "BoolVariable", menuName = "UltimateScriptable/BoolVariable", order = 0)]
  public class BoolVariable : ScriptableObject {
    public bool Value;
    public void SetValue(bool value) {
      Value = value;
    }

    public void SetValue(BoolVariable value) {
      Value = value.Value;
    }
  }
}