using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Data
{

}

public class SaveManager : MonoBehaviour
{
    public Data data;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void SaveData()
    {
        string json = JsonUtility.ToJson(data);

        string filepath = Path.Combine(Application.persistentDataPath, "savedata.json");
        File.WriteAllText(filepath, json);
    }
}
