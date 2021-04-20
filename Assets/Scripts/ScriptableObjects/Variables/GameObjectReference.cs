using UnityEngine;
using System;

namespace UltimateScriptable.Variables {
  [Serializable]
  public class GameObjectReference {
    public bool UseConstant = true;
    public GameObject ConstantValue;
    public GameObjectVariable Variable;
    public GameObjectReference() { }
    public GameObjectReference(GameObject value) {
      UseConstant = true;
      ConstantValue = value;
    }

    public GameObject Value {
      get { return UseConstant ? ConstantValue : Variable.Value; }
    }

    public void SetValue(GameObject value) {
      UseConstant = true;
      ConstantValue = value;
    }
    public void SetValue(GameObjectVariable value) {
      UseConstant = false;
      Variable = value;
    }

    public static implicit operator GameObject(GameObjectReference reference) {
      return reference.Value;
    }
  }
}