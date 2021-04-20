using UnityEngine;

namespace UltimateScriptable.Variables {

  [CreateAssetMenu(fileName = "GameObjectVariable", menuName = "UltimateScriptable/GameObjectVariable", order = 0)]
  public class GameObjectVariable : ScriptableObject {
    public GameObject Value;

    public void SetValue(GameObject value) {
      Value = value;
    }

    public void SetValue(GameObjectVariable value) {
      Value = value.Value;
    }
  }
}
