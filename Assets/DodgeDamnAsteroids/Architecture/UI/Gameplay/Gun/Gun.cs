using Gameplay;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private List<Image> bombs= new List<Image>();

        private int maxAmmo;
        private int ammo;

        private void Start()
        {
            if (bombs.Count != Gameplay.Gun.maxAmmo)
            {
                Debug.Log("Check bombs amount in UI!");
            }

            maxAmmo = Gameplay.Gun.maxAmmo;
            bombs.ForEach(b => b.enabled = false);

            ShowAmmo();
        }
        private void Update()
        {
            if (ammo != Gameplay.Gun.ammo)
                ShowAmmo();

            if (ammo != maxAmmo)
                ShowReloading();
        }
        private void ShowAmmo()
        {
            ammo = Gameplay.Gun.ammo;

            for (int i = 0; i < bombs.Count; i++)
            {
                bombs[i].enabled = i < ammo;
                bombs.ForEach(b => b.fillAmount = 1);
            }
        }
        private void ShowReloading()
        {
            bombs[maxAmmo - 1].fillAmount = Gameplay.Gun.reloadProgress;
        }
    }
}
