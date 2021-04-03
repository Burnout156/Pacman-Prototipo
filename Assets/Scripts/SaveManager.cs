using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public struct SaveStructure
{
    public int maximunScore;
}


public class SaveManager : MonoBehaviour
{
    public static SaveStructure MainSave;
    public static string filePath;
    public static string folderPath;
    public static string data;

    private void Awake()
    {
        filePath = Application.dataPath + "/LocalSave" + "/" + "Save" + ".json";
        folderPath = Application.dataPath + "/LocalSave";
    }

    void Start()
    {
        filePath = Application.dataPath + "/LocalSave" + "/" + "Save" + ".json";
        folderPath = Application.dataPath + "/LocalSave";

        if (!Directory.Exists(folderPath)) //se a pasta não existir, será criada uma nova pasta
        {
            Directory.CreateDirectory(folderPath);
        }

        if (!File.Exists(filePath)) //se o arquivo de save não existir, será criado
        {
            MainSave.maximunScore = 0;
            Save();
        }

        else
        {
            MainSave = JsonUtility.FromJson<SaveStructure>(Load());
        }
    }

    public static void Save()
    {
        string json = JsonUtility.ToJson(MainSave); //passar uma estrutura com variáveis para uma string
        File.WriteAllText(filePath, json);
    }

    public static string Load()
    {
        if (File.Exists(filePath))
        {
            data = File.ReadAllText(filePath);
            MainSave = JsonUtility.FromJson<SaveStructure>(data);
            print("File Read Successfully: " + data);
        }

        else
        {
            print("File Not Exist " + data);
        }

        return data;
    }

}
