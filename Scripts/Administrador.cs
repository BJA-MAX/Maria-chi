using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System;

public static class Administrador
{
    public static string Holi;
    private static string Almacenamiento;
    public static void SaveToJSON<T>(List<T> toSave, string filename, int Lugar)
    {
        if (filename is null)
        {
            throw new ArgumentNullException(nameof(filename));
        }
        Holi = Application.streamingAssetsPath + "/Partituras/";
        
        //Debug.Log(GetPath(filename,1));
        string content = JsonHelper.ToJson(toSave.ToArray());
        //Debug.Log("Notas en el documento: " + toSave.Count);
        WriteFile(GetPath(filename,Lugar), content);
    }

    public static List<T> ReadFromJSON<T>(string filename, int Lugar)
    {
        string content = ReadFile(GetPath(filename,Lugar));
        if (string.IsNullOrEmpty(content) || content == "{}")
        {
            return new List<T>();

        }
        List<T> res = JsonHelper.FromJson<T>(content).ToList();
        return res;
    }
    private static string GetPath(string filename,int Lugar)
    {
        //return Application.persistentDataPath + "/Partituras/" + filename;
        //return Application.streamingAssetsPath + "/Partituras/" + filename;
        //return getDatabasePath(filenam);
        //return Application.persistentDataPath + "/Partituras/" + filename;
        if (Lugar == 1)
        {
            Almacenamiento = Application.streamingAssetsPath + "/Partituras/" + filename;
            //Leer
        }
        else if (Lugar == 2)
        {
            Almacenamiento = Application.persistentDataPath + "/" + filename;
            //Leer.Escribir Cuando Compliado
        }
        else
        {
            Almacenamiento = Application.dataPath + "/" + filename;
            //Leer Escribir no Compilado
        }
        return Almacenamiento;
        // Aqui podemos cambiar el nombre del archivo para el guardado de las canciones

    }
    private static void WriteFile(string path, string content)
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            File.WriteAllText(path, content);
        }
        else
        {
            FileStream fileStream = new FileStream(path, FileMode.Create);
            using StreamWriter writer = new(fileStream);
            writer.Write(content);
            //using( StreamWriter writer = new(fileStream)) {
            //writer.Write(content)}
        };
        //FileStream fileStream = new FileStream(path, FileMode.Create);
        //using StreamWriter writer = new(fileStream);
        //writer.Write(content);
        //using( StreamWriter writer = new(fileStream)) {
        //writer.Write(content)}

    }
    private static string ReadFile(string path)
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            UnityEngine.Networking.UnityWebRequest www = UnityEngine.Networking.UnityWebRequest.Get(path);
            www.SendWebRequest();
            while (!www.isDone) ;
            string content = www.downloadHandler.text;
            return content;
        }
        else {
            string content = File.ReadAllText(path);
                return content;
        };


      
       /* if (File.Exists(path))
        {
            
            using StreamReader reader = new(path);
            string content = reader.ReadToEnd();
            
            return content;
        }

        return "";*/
    }

    public static void DeleteFile(string filename, int Lugar)
    {
        string Borrar = (GetPath(filename, Lugar));
        if (File.Exists(Borrar))
        {
            Debug.Log(Borrar);
            File.Delete(Borrar);
           // UnityEditor.AssetDatabase.Refresh();
        }
    }
}
public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>
        {
            Items = array
        };
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>
        {
            Items = array
        };
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}