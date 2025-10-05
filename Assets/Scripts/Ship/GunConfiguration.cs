using System;
using UnityEngine;

[CreateAssetMenu(fileName = "GunConfiguration", menuName = "Gun Configuration")]
public class GunConfiguration : ScriptableObject
{
    [Tooltip("The number of bullets the guns can fire per second")]
    public float fireRate;   
    public GunInfo[] guns;
}

[Serializable]
public struct GunInfo
{
    public Vector2 position;
    public float angle;
    public Vector2 direction {
        get {
            float rad = angle * Mathf.Deg2Rad;
            return new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
        }
    }
}