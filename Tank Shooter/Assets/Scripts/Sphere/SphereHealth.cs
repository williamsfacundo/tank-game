using System;

using UnityEngine;

using TankGame.Interfaces;

public class SphereHealth : MonoBehaviour, IDamaged
{
    public static event Action OnSphereDestroyed;

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
    }

    private void OnDisable()
    {
        activeSphereInstances--;
    }

    public void DamageReceived()
    {
        OnSphereDestroyed?.Invoke();

        gameObject.SetActive(false);
    }
}