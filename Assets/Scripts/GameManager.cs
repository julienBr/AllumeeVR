using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class GameManager : MonoBehaviour
{
    [Header("Controllers")]
    [SerializeField] private XRNode inputSourceLeft;
    [SerializeField] private XRNode inputSourceRight;
    [SerializeField] private InputHelpers.Button inputButton;
    [SerializeField] private float InputThreshold = 0.1f;
    
    [Header("Start")]
    [SerializeField] private AudioSource _source;
    
    [Header("Fader")]
    [SerializeField] private GameObject _fader;
    
    [Header("Change Scene")]
    [SerializeField] private GameObject _scene;
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private Material _sky;
    [SerializeField] private Material _skyLoading;

    [Header("AppData")]
    [SerializeField] private AppData _data;
    
    [Header("Beach")]
    [SerializeField] private GameObject _beach;
    [SerializeField] private GameObject _partyBeach;
    [SerializeField] private GameObject _interstellarBeach;
    [SerializeField] private GameObject _backBeach;
    
    [Header("Forest")]
    [SerializeField] private GameObject _forest;
    [SerializeField] private GameObject _partyForest;
    [SerializeField] private GameObject _interstellarForest;
    [SerializeField] private GameObject _backForest;
    
    [Header("Stadium")]
    [SerializeField] private GameObject _stadium;
    [SerializeField] private GameObject _partyStadium;
    [SerializeField] private GameObject _interstellarStadium;
    [SerializeField] private GameObject _backStadium;
    
    private string _currentScene;
    private bool _oneTime;
    private string _environment;
    
    private void Awake()
    {
        _currentScene = gameObject.scene.name;
        RenderSettings.skybox = _sky;
    }
    
    private void Update()
    {
        InputDevices.GetDeviceAtXRNode(inputSourceLeft).IsPressed(inputButton, out bool isPressedLeft, InputThreshold);
        InputDevices.GetDeviceAtXRNode(inputSourceRight).IsPressed(inputButton, out bool isPressedRight, InputThreshold);
        if (_currentScene == "Start" && (isPressedLeft || isPressedRight) && !_oneTime)
        {
            _oneTime = true;
            StartCoroutine(ThrowGame());
        }
    }
       
    private IEnumerator ThrowGame()
    {
        if(_oneTime) _source.Play();
        yield return new WaitForSeconds(1f);
        _fader.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync("HUB");
        while (!loadOperation.isDone)
        {
            yield return null;
        }
    }
    
    public void ChooseEnvironment(string environment)
    {
        if (environment == "Beach")
        {
            _beach.SetActive(false);
            _partyBeach.SetActive(true);
            _interstellarBeach.SetActive(true);
            _backBeach.SetActive(true);
            _environment = "Beach";
        }
        if (environment == "Forest")
        {
            _forest.SetActive(false);
            _partyForest.SetActive(true);
            _interstellarForest.SetActive(true);
            _backForest.SetActive(true);
            _environment = "Forest";
        }
        if (environment == "Stadium")
        {
            _stadium.SetActive(false);
            _partyStadium.SetActive(true);
            _interstellarStadium.SetActive(true);
            _backStadium.SetActive(true);
            _environment = "Stadium";
        }
    }

    public void BackEnvironment(string environment)
    {
        if (environment == "Beach")
        {
            _beach.SetActive(true);
            _partyBeach.SetActive(false);
            _interstellarBeach.SetActive(false);
            _backBeach.SetActive(false);
        }
        if (environment == "Forest")
        {
            _forest.SetActive(true);
            _partyForest.SetActive(false);
            _interstellarForest.SetActive(false);
            _backForest.SetActive(false);
        }
        if (environment == "Stadium")
        {
            _stadium.SetActive(true);
            _partyStadium.SetActive(false);
            _interstellarStadium.SetActive(false);
            _backStadium.SetActive(false);
        }
    }
    
    public void ChooseShow(int show)
    {
        _data.actualShow = _data.listShow[show];
        LoadLevel(_environment);
    }
    
    public void BackToHUB()
    {
        LoadLevel("HUB");
    }
    
    private void LoadLevel(string levelToLoad)
    {
        _scene.SetActive(false);
        StartCoroutine(LoadAsync(levelToLoad));
    }

    private IEnumerator LoadAsync(string levelToLoad)
    {
        RenderSettings.skybox = _skyLoading;
        DynamicGI.UpdateEnvironment();
        _loadingScreen.SetActive(true);
        yield return new WaitForSeconds(10f);
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToLoad);
        while (!loadOperation.isDone)
        {
            yield return null;
        }
    }
}