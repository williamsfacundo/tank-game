using System;

using UnityEngine;

using TankGame.Interfaces;

public class SphereHealth : MonoBehaviour, IDamaged
{
    public static event Action OnSphereDestroyed;

    public static event Action OnActiveSphereInstancesChanged;

    public static event Action OnAllSpheresDisabled;

    private static int activeSphereInstances = 0;
    
    public static int ActiveSphereInstances
    {
        get 
        {
            return activeSphereInstances;
        }
    }

    private void Start()
    {
        gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        activeSphereInstances++;

        OnActiveSphereInstancesChanged?.Invoke();
    }

    private void OnDisable()
    {
        activeSphereInstances--;

        OnActiveSphereInstancesChanged?.Invoke();

        if (activeSphereInstances <= 0) 
        {
            OnAllSpheresDisabled?.Invoke();
        }
    }

    public void DamageReceived()
    {
        OnSphereDestroyed?.Invoke();

        gameObject.SetActive(false);
    }
}