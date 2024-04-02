using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class ToggleLight : MonoBehaviour, IDamageable
{
    [SerializeField] private Light _light;

    public bool IsAlive => true;

    public void Damage(DamageInfo damageInfo)
    {
        // flip light on/off
        _light.enabled = !_light.enabled;
    }

    private void OnValidate()
    {
        _light = GetComponent<Light>();
    }
}