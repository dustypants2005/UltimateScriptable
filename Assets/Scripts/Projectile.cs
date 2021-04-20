using System.Collections;
using System.Collections.Generic;
using RoboRyanTron.Unite2017.Variables;
using UnityEngine;
using UltimateScriptable.Variables;

namespace UltimateScriptable {
  [RequireComponent(typeof(Rigidbody))]
  public class Projectile : MonoBehaviour {
    public FloatReference Speed;
    public Vector3Reference Direction;
    public Rigidbody Rigidbody {
      get {
        if (_rigidbody == null) {
          _rigidbody = GetComponent<Rigidbody>();

        }
        return _rigidbody;
      }
    }
    Rigidbody _rigidbody;

    void OnEnable() {
      Rigidbody.AddForce(transform.rotation * Direction * Speed.Value, ForceMode.VelocityChange);
    }

    void OnDisable() {
      Rigidbody.velocity = Vector3.zero;
    }
  }
}
