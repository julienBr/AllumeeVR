using UnityEngine;

public class PortalLookAt : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    
    private void Update()
    {
        Vector3 targetPostition = new Vector3(_camera.position.x, transform.position.y, _camera.position.z);
        transform.LookAt(targetPostition);
    }
}