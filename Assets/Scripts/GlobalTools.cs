using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;
using System.Linq;
//Tangxin
public class valueInfo
{
    public Dictionary<string, string> m_infos = new Dictionary<string, string>();
    public string GetValue(string key)
    {
        string result;
        if (m_infos.TryGetValue(key, out result))
            return result;
        return "";
    }
    public bool SetValue(string key, string value)
    {
        if (m_infos.ContainsKey(key))
        {
            string oldValue = GetValue(key);
            if (oldValue == value)
                return false;
        }

        m_infos[key] = value;
        return true;
    }
}
public class valueInfoList
{
    public List<valueInfo> m_infoList = new List<valueInfo>();
}

public static class GlobalTools
{
    public static valueInfoList ReadFromCSV(string filename)
    {
        if (false == System.IO.File.Exists(filename))
        {
            return null;
        }
        Encoding encoding = Encoding.Default;
        FileStream fs = new FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite);
        StreamReader sr = new StreamReader(fs, encoding);
        string content = sr.ReadToEnd();
        sr.Close();
        fs.Close();
        if (null == content)
            return null;
        string[] arrLine = content.Split('\n');

        valueInfoList res = new valueInfoList();
        //第一行中文备注，第二行key
        string[] arrKey = arrLine[1].Remove(arrLine[1].Length - 1).Split(',');
        //第三行开始是数据
        for (int i = 2; i < arrLine.Length - 1; i++)
        {
            string strLine = arrLine[i];
            strLine = strLine.Remove(arrLine[i].Length - 1);
            string[] arrWord = strLine.Split(',');

            valueInfo tempNode = new valueInfo();
            for (int j = 0; j < arrKey.Length; j++)
            {
                tempNode.SetValue(arrKey[j], arrWord[j]);
            }
            res.m_infoList.Add(tempNode);
        }
        return res;
    }

    public static valueInfoList ReadFromResources(string context)
    {
        string[] arrLine = context.Split('\n');

        valueInfoList res = new valueInfoList();
        //第一行中文备注，第二行key
        string[] arrKey = arrLine[1].Remove(arrLine[1].Length - 1).Split(',');
        //第三行开始是数据
        for (int i = 2; i < arrLine.Length - 1; i++)
        {
            string strLine = arrLine[i];
            strLine = strLine.Remove(arrLine[i].Length - 1);
            string[] arrWord = strLine.Split(',');

            valueInfo tempNode = new valueInfo();
            for (int j = 0; j < arrKey.Length; j++)
            {
                tempNode.SetValue(arrKey[j], arrWord[j]);
            }
            res.m_infoList.Add(tempNode);
        }
        return res;
    }
    public static void WriteToCSV(string filename, string comment, valueInfoList data)
    {
        if (!File.Exists(filename))
        {
            File.Create(filename).Dispose();
        }
        string content = String.Format("{0}\n", comment);
        if (data.m_infoList.Count > 0)
        {
            List<string> keys = data.m_infoList[0].m_infos.Keys.ToList();
            foreach (string key in keys)
            {
                content = String.Format("{0}{1},", content, key);
            }
            content = String.Format("{0}\n", content);
            foreach (valueInfo infoList in data.m_infoList)
            {
                foreach (string key in keys)
                {
                    content = String.Format("{0}{1},", content, infoList.m_infos[key]);
                }
                content = String.Format("{0}\n", content);
            }
        }
        Encoding encoding = Encoding.Default;
        FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
        StreamWriter sw = new StreamWriter(fs, encoding);
        sw.Write(content);
        sw.Close();
        fs.Close();
    }

}

public static class GlobalDefine
{
    public const string Soldier1 = "沙雕士兵1";
    public const string Soldier2 = "沙雕士兵2";
    public const string Soldier3 = "沙雕士兵3";
}
