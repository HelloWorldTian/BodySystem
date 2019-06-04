using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ISystem : MonoBehaviour {

    private string systemName;
    private string systemDes;
    private string vedioPath;
    private SystemType systemType;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetSystemInfo(string _name,SystemType _type,string _des,string _vedioPath)
    {
        systemName = _name;
        systemDes = _des;
        vedioPath = _vedioPath;
        systemType = _type;
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
}
