using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "Show")]

public class Show : ScriptableObject
{
    public string nameShow;
    public AudioClip audioClip;
    public List<VideoClip> listVideo;
}