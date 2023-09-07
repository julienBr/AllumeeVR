using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private GameObject _fader;
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private Slider _slider;
    private string _currentScene;
    private bool _oneTime;
    
    private void Awake()
    {
        _currentScene = gameObject.scene.name;
    }
    
    private void Update()
    {
        if(_currentScene == "Start" && Input.anyKeyDown) StartCoroutine(ThrowGame());
    }
       
    private IEnumerator ThrowGame()
    {
        if(!_oneTime) _source.Play();
        _oneTime = true;
        yield return new WaitForSeconds(1f);
        _fader.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadSceneAsync("HUB");
    }

    public void LoadLevel(string levelToLoad)
    {
        
    }

    private IEnumerator LoadAsync(string levelToLoad)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToLoad);
        while (!loadOperation.isDone)
        {
            float progressValue = Mathf.Clamp01(loadOperation.progress / .9f);
            _slider.value = progressValue;
            yield return null;
        }
    }
}