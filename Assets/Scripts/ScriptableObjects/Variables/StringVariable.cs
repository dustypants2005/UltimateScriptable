﻿// ----------------------------------------------------------------------------
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------

using UnityEngine;

namespace RoboRyanTron.Unite2017.Variables {
  [CreateAssetMenu(fileName = "StringVariable", menuName = "UltimateScriptable/StringVariable", order = 0)]
  public class StringVariable : ScriptableObject {
    [SerializeField]
    private string value = "";

    public string Value {
      get { return value; }
      set { this.value = value; }
    }
  }
}