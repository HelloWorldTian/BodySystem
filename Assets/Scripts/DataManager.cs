using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;


public enum SystemType
{
    MotorSystem,
    NervousSystem,
    EndocrineSystem,
    CirculationSystem,
    RespiratorySystem,
    DigestiveSystem,
    UrinarySystem,
    ReproductiveSystem
}
public class DataManager{

    private const string DataPath = "SystemData";
    private const string PrefabPath = "SystemPrefab/";
    private GameObject container;

    public Dictionary<int, ISystem> m_SystemList = new Dictionary<int, ISystem>();

    private static DataManager _instance;
    public static DataManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new DataManager();
            }
            return _instance;
        }
    }
    public void InitInfo()
    {
        TextAsset asset = Resources.Load(DataPath,typeof(TextAsset))as TextAsset;
        Encoding encoding = Encoding.UTF8;

        string info = encoding.GetString(asset.bytes);
        if (string.IsNullOrEmpty(info))
        {
            Debug.LogError("数据载入失败");
            return;
        }
        if (container == null)
        {
            container = GameObject.Find("SystemContainer");
            container.transform.position = new Vector3(0,190,0);
        }
        valueInfoList tempList = GlobalTools.ReadFromResources(info);
        foreach (valueInfo vi in tempList.m_infoList)
        {
            SystemType _type = (SystemType)Enum.Parse(typeof(SystemType),vi.GetValue("ID"));
            string _name = vi.GetValue("Name");
            string _path = vi.GetValue("VedioPath");
            string _des = vi.GetValue("Des");
            string _prefabPath = PrefabPath+vi.GetValue("PrefabPath");
            string _englishName= vi.GetValue("EnglishName");

            GameObject tempPre = Resources.Load(_prefabPath)as GameObject;
            ISystem tempSystem = GameObject.Instantiate(tempPre).AddComponent<ISystem>();
            tempSystem.gameObject.name = _name;
            tempSystem.SetSystemInfo(_name, _type, _des, _path, _englishName);
            tempSystem.transform.SetParent(container.transform);
            tempSystem.transform.localPosition = Vector3.zero;//相对于父物体位置
            if (!m_SystemList.ContainsKey((int)_type))
            {
                m_SystemList.Add((int)_type,tempSystem);
                Debug.Log("SyetemName"+ tempSystem.GetSystemName());
            }
        }
        container.AddComponent<RotateController>();
        container.SetActive(false);
    }
}
