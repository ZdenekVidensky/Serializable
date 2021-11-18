using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Data", order = 1)]
public class Data : ScriptableObject, IUploadable
{
    public int Version = 1;
    public MySubData SubData;

    void IUploadable.Deserialize(string json)
    {
        JsonUtility.FromJsonOverwrite(json, this);
    }
}

[System.Serializable]
public struct MySubData
{
    public string Name;
    [JsonIgnore]
    public int Age;
}
