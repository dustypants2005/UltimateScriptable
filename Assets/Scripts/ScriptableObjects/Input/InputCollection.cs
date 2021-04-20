using System.Collections.Generic;
using UnityEngine;

namespace UltimateScriptable.Input {
  [CreateAssetMenu(fileName = "InputCollection", menuName = "UltimateScriptable/InputCollection", order = 0)]
  public class InputCollection : ScriptableObject {
    public List<InputVariable> Collection;
  }
}