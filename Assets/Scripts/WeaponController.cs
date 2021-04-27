using System.Collections;
using System.Collections.Generic;
using UltimateScriptable.Pools;
using UltimateScriptable.Weapons;
using UnityEngine;

namespace UltimateScriptable {
  public class WeaponController : MonoBehaviour {
    public Transform Mount;
    Weapon weapon;

    public void SetWeapon(Weapon _weapon) {
      weapon = _weapon;
    }
    public void Fire() {
      var spread = Vector3.zero;
      for (var i = 0; i < weapon.ProjectileCount; i++) {
        var rot = Vector3.zero;
        if (i % 2 == 1) {
          spread += weapon.Spread;
        }
        rot = i % 2 == 0 ? -spread : spread;
        var projectile = weapon.SpawnProjectile(Mount.position, Mount.rotation * Quaternion.Euler(rot));
        var rb = projectile.GetComponent<Rigidbody>();
        var parentCC = GetComponentInParent<CharacterController>();
        if (rb != null && parentCC != null) { //  player
          var playerVelocity = parentCC.velocity;
          playerVelocity.y = 0;
          rb.velocity += playerVelocity;
        } else {
          var parentrb = GetComponentInParent<Rigidbody>();
          if (parentrb != null && rb != null) { // bot
            rb.velocity += parentrb.velocity;
          }
        }
      }
    }
  }
}