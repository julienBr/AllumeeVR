using UnityEngine;

public class LookAtCanvasVideo : MonoBehaviour
{
    //[SerializeField] private GameObject _tripod;
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _transformUI;
    //[SerializeField] private GameObject _uiObject;

    private void Update()
    {
        //Vector3 targetPostition = new Vector3(_camera.position.x, _transformUI.position.y, _camera.position.z);
        //_transformUI.LookAt(targetPostition);
        _transformUI.LookAt(_camera);
    }
}