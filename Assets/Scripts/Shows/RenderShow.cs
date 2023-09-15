using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class RenderShow : MonoBehaviour
{
    [SerializeField] private AppData _data;
    private VideoPlayer _videoPlayer;
    private AudioSource _audioSource;
    private int _index;

    private void Awake()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _videoPlayer.clip = _data.actualShow.listVideo[_index];
        _audioSource.clip = _data.actualShow.audioClip;
        _videoPlayer.loopPointReached += EndReached;
        _audioSource.Play();
        StartCoroutine(PlayShow());
    }

    private IEnumerator PlayShow()
    {
        if (_data.actualShow.nameShow == "Ciel de Fête") yield return new WaitForSeconds(27.5f);
        else yield return new WaitForSeconds(10f);
        _videoPlayer.Play();
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    private void EndReached(VideoPlayer vp)
    {
        if (_index < _data.actualShow.listVideo.Count - 1)
        {
            _index++;
            vp.clip = _data.actualShow.listVideo[_index];
            vp.Play();
        }
        else
        {
            vp.Stop();
            InvokeRepeating("DecreaseVolume", 0f, .1f);
            if(_audioSource.volume == 0f) _audioSource.Stop();
        }
    }

    private void DecreaseVolume()
    {
        _audioSource.volume -= .025f;
    }
}