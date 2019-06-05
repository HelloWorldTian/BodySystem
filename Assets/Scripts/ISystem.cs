using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ISystem : MonoBehaviour {

    private string systemName;
    private string systemDes;
    private string vedioPath;
    private SystemType systemType;
    private string englishName;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetSystemInfo(string _name,SystemType _type,string _des,string _vedioPath,string _englishName)
    {
        systemName = _name;
        systemDes = _des;
        vedioPath = _vedioPath;
        systemType = _type;
        englishName = _englishName;
    }
    public string GetSystemName()
    {
        return systemName;
    }
    public string GetSystemDes()
    {
        return systemDes;
    }

    public SystemType GetSystemType()
    {
        return systemType;
    }
    public string GetEnglishName()
    {
        return englishName;
    }
    public string GetVedioPath()
    {
        return vedioPath;
    }
}
