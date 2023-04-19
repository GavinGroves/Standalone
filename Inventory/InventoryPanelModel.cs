using System;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 背包数据控制
/// </summary>
public class InventoryPanelModel : MonoBehaviour
{
    private void Awake()
    {
       
    }

    /// <summary>
    /// 获取json数据并且传递给Controller层
    /// </summary>
    /// <param name="fileName">json文件名字</param>
    /// <returns>获取的json存储到实体类返回</returns>
    public List<InventoryItem> GetJsonList(string fileName)
    {
        List<InventoryItem> temp = new List<InventoryItem>();
        //1.读出JSON文件数据
        String tempJsonStr = Resources.Load<TextAsset>("JsonData/" + fileName).text;
        //开始解析JSON
        //2.转换成jsonData (使用JsonMapper将读出的字符串toObject,转换成jsonData集合
        JsonData jsonData = JsonMapper.ToObject(tempJsonStr);
        //3.循环，将jsonData转换成toJosn, 装到实体类ToObject中
        for (int i = 0; i < jsonData.Count; i++)
        {
            InventoryItem itemObject = JsonMapper.ToObject<InventoryItem>(jsonData[i].ToJson());
            temp.Add(itemObject);
        }
        return temp;
    }
}
