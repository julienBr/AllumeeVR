using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Appdata")]
public class AppData : ScriptableObject
{
    public Show actualShow;
    public List<Show> listShow;
}