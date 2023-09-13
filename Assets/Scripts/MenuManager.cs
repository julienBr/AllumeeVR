using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MenuManager : MonoBehaviour
{
    [Header("Controllers")]
    [SerializeField] private XRNode inputSource;
    [SerializeField] private InputHelpers.Button inputButton;
    [SerializeField] private float InputThreshold = 0.1f;
    
    [Header("Menu")]
    [SerializeField] private GameObject _backMenu;

    private bool _isDisplay;
    
    private void Update()
    {
        InputDevices.GetDeviceAtXRNode(inputSource).IsPressed(inputButton, out bool isPressed, InputThreshold);
        if (isPressed)
        {
            if (_isDisplay) DisplayBackMenu();
            else HideBackMenu();
        }
    }

    private void DisplayBackMenu()
    {
        _backMenu.SetActive(true);
        _isDisplay = true;
    }

    private void HideBackMenu()
    {
        _backMenu.SetActive(false);
        _isDisplay = false;
    }
}