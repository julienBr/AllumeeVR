using UnityEngine;

public class RotateAround : MonoBehaviour
{
    [SerializeField] private Transform centerMass;
    [SerializeField] private Transform revealingLight;
    [SerializeField] private float rotationAroundSunDays = 1.0f;
    private float defaultEarthYear = 365.25f;
    private float planetSpeedRotation = 1.0f;
    
    private void Start ()
    {
        if(revealingLight != null)
            revealingLight.transform.LookAt(transform.position);
    }
    
    private void Update ()
    {
        transform.RotateAround(centerMass.position, Vector3.up, Time.deltaTime * (defaultEarthYear / rotationAroundSunDays) * Time.deltaTime);
        transform.Rotate(-Vector3.up * (Time.deltaTime * planetSpeedRotation));
    }
}