using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class JsonController : MonoBehaviour
{
    public Chapter1Stats player = new Chapter1Stats();
    public string json;
    public string read;
    // Start is called before the first frame update
    void Start()
    {
      //SaveJson(); //Bu her seferinde save'i tekrar aldýðý için sýfýrdan baþlýyor bu yüzden yorum satýrý yaptým.
        LoadJson();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SaveJson()
    {
        json = JsonUtility.ToJson(player,true);
        File.WriteAllText(Application.dataPath+"/Scripts/PlayerData/chapter1.json",json);
        LoadJson();
    }
    public void LoadJson()
    {
        string path = Application.dataPath + "/Scripts/PlayerData/chapter1.json";
        if (File.Exists(path))
        {
            read = File.ReadAllText(path);
            player = JsonUtility.FromJson<Chapter1Stats>(read);
        }
        else
        {
            Debug.Log("No data found!");
        }
    }
}
