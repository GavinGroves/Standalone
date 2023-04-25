using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

/// <summary>
/// 合合成模块M
/// </summary>
public class CraftingPanelModel : MonoBehaviour
{
    private void Awake()
    {
    }

    /// <summary>
    /// 获取选项卡图标名称
    /// </summary>
    /// <returns></returns>
    public string[] GetTabsIconName()
    {
        string[] names = new string[] { "Icon_House", "Icon_Weapon" };
        return names;
    }

    /// <summary>
    /// 通过JSON文件名实现数据的加载
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public List<List<CraftingContentItem>> ByNameGetJsonData(string name)
    {
        List<List<CraftingContentItem>> temp = new List<List<CraftingContentItem>>();
        string jsonStr = Resources.Load<TextAsset>("JsonData/" + name).text;
        JsonData jsonData = JsonMapper.ToObject(jsonStr);
        for (int i = 0; i < jsonData.Count; i++)
        {
            List<CraftingContentItem> tempList = new List<CraftingContentItem>();
            JsonData jd = jsonData[i]["Type"];
            for (int j = 0; j < jd.Count; j++)
            {
                tempList.Add(JsonMapper.ToObject<CraftingContentItem>(jd[j].ToJson()));
                // tempList.Add(jd[j]["ItemName"].ToString());
            }

            temp.Add(tempList);
        }

        return temp;
    }
}