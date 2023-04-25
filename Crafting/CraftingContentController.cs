using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Content内容栏
/// </summary>
public class CraftingContentController : MonoBehaviour
{
    private Transform m_Transform;
    private int index = -1;

    private CraftingContentItemController current = null;

    private void Awake()
    {
        m_Transform = gameObject.GetComponent<Transform>();
    }

    /// <summary>
    /// 初始化Contetn
    /// </summary>
    public void InitContents(int index, GameObject prefab, List<CraftingContentItem> strList)
    {
        this.index = index;
        gameObject.name = "Content" + index;
        CreateAllItems(prefab, strList);
    }

    /// <summary>
    /// 创建全部ContentItem
    /// </summary>
    private void CreateAllItems(GameObject item, List<CraftingContentItem> strList)
    {
        for (int i = 0; i < strList.Count; i++)
        {
            GameObject go = Instantiate(item, m_Transform);
            go.GetComponent<CraftingContentItemController>().Init(strList[i]);
        }
    }

    /// <summary>
    /// 接收子物体传送过来的对象
    /// </summary>
    /// <param name="item"></param>
    private void ResetItemState(CraftingContentItemController item)
    {
        if (item == current) return;
        Debug.Log(item.name);
        //如果当前item不为空，即有点击操作
        if (current != null)
        {
            //先默认全部为false
            current.NormalItem();
        }

        //激活点击的item
        item.ActiveItem();
        //赋值
        current = item;
    }
}