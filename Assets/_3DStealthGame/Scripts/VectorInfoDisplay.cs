using UnityEngine;
using UnityEngine.InputSystem.Utilities;

public class VectorInfoDisplay : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Vector3 vec;
    public float magnitude;
    public Vector3 normalized;
    public Vector3 reconstructed;

    // Update is called once per frame
    void Update()
    {
        magnitude = vec.magnitude;
        normalized = vec.normalized;
        reconstructed = magnitude * normalized;
    }
}
