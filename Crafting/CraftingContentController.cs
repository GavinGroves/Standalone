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

    private void Awake()
    {
        m_Transform = gameObject.GetComponent<Transform>();
    }

    /// <summary>
    /// 初始化Contetn
    /// </summary>
    public void InitContents(int index, GameObject prefab)
    {
        this.index = index;
        gameObject.name = "Content" + index;
        CreateAllItems(index, prefab);
    }

    /// <summary>
    /// 创建全部ContentItem
    /// </summary>
    private void CreateAllItems(int count, GameObject item)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(item, m_Transform);
        }
    }
}