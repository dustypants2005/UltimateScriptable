using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateScriptable.Variables;
using UltimateScriptable.Pools;

namespace UltimateScriptable.Weapons {
  [CreateAssetMenu(fileName = "WeaponManager", menuName = "UltimateScriptable/WeaponManager", order = 0)]
  public class WeaponManager : ScriptableObject {
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif
    public List<Weapon> WeaponsList = new List<Weapon>();
    public WeaponManager Default;
    public int CurrentWeaponIndex = 0;
    public GameObjectReference WeaponMount;
    public void Init(GameObject mount) {
      WeaponMount.SetValue(mount);
      WeaponsList.Clear();
      foreach (var weapon in Default.WeaponsList) {
        AddWeapon(weapon);
      }
    }

    public void AddWeapon(Weapon weapon) {
      WeaponsList.Add(weapon); // add to list
      weapon.ObjectInScene = Instantiate(weapon.Reference.Value, WeaponMount.Value.transform); // add in scene
      var controller = weapon.ObjectInScene.GetComponent<WeaponController>();
      if (controller != null) {
        controller.SetWeapon(weapon);
      }
      SetWeaponIndex(WeaponsList.Count - 1);
    }

    public void RemoveWeapon(Weapon weapon) {
      if (WeaponsList.Contains(weapon)) { // remove from list
        WeaponsList.Remove(weapon);
      }
      if (CurrentWeaponIndex >= WeaponsList.Count) { // make sure index is within range
        CurrentWeaponIndex = WeaponsList.Count - 1;
      }
    }

    public void SetWeaponIndex(int index) {
      CurrentWeaponIndex = index;
      int i = 0;
      foreach (var weapon in WeaponsList) {
        weapon.ObjectInScene.SetActive(index == i);
        i++;
      }
    }

    public void NextWeapon() {
      SetWeaponIndex(++CurrentWeaponIndex % WeaponsList.Count);
    }

    public void PreviousWeapon() {
      if (CurrentWeaponIndex <= 0) CurrentWeaponIndex = WeaponsList.Count;
      SetWeaponIndex(--CurrentWeaponIndex);
    }
  }
}