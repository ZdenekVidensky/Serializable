using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

public class Uploader
{
    [MenuItem("Lucky Potion/Upload")]
    static void Upload()
    {
        Object[] assets = Resources.LoadAll("");
        string result = string.Empty;

        for (int idx = 0; idx < assets.Length; ++idx)
        {
            IUploadable uploadable = assets[idx] as IUploadable;

            if (uploadable == null)
                continue;

            result += JsonConvert.SerializeObject(uploadable);

            Debug.LogError(result);
        }
    }

    [MenuItem("Lucky Potion/Download")]
    static void Download()
    {
        string data = "{\"Version\":42,\"SubData\":{\"Name\":\"Michal\"},\"name\":\"Data\",\"hideFlags\":0}";

        Object[] assets = Resources.LoadAll("");

        for (int idx = 0; idx < assets.Length; ++idx)
        {
            IUploadable uploadable = assets[idx] as IUploadable;

            if (uploadable == null)
                continue;

            uploadable.Deserialize(data);
        }
    }
}
