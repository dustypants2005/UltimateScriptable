using UnityEngine;
using System;

namespace UltimateScriptable.Variables {
  [Serializable]
  public class GameObjectReference {
    public GameObject ConstantValue;
    public GameObjectVariable Variable;
    public GameObjectReference() { }
    public GameObjectReference(GameObject value) {
      ConstantValue = value;
    }

    public GameObject Value {
      get { return ConstantValue ?? Variable?.Value; }
    }

    public void SetValue(GameObject value) {
      ConstantValue = value;
      Variable?.SetValue(value);
    }
    public void SetValue(GameObjectVariable value) {
      Variable = value;
    }

    public static implicit operator GameObject(GameObjectReference reference) {
      return reference.Value;
    }
  }
}