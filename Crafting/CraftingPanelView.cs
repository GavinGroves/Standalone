using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 合成模块V，资源加载
/// </summary>
public class CraftingPanelView : MonoBehaviour
{
    private Transform m_Transform;
    private Transform tabs_Transform;
    private Transform contents_Transform;
    private Transform center_Transform;

    private GameObject prefab_CraftingTabsItem;
    private GameObject prefab_CraftingContent;
    private GameObject prefab_CraftingContentItem;
    private GameObject prefab_CraftingSlot;

    private Dictionary<string, Sprite> tabIconDic;

    #region 公开属性

    public Transform M_Transform => m_Transform;
    public Transform Tabs_Transform => tabs_Transform;
    public Transform Contents_Transform => contents_Transform;
    public Transform Center_Transform => center_Transform;
    
    public GameObject Prefab_CraftingTabsItem => prefab_CraftingTabsItem;
    public GameObject PrefabCraftingContent => prefab_CraftingContent;
    public GameObject PrefabCraftingContentItem => prefab_CraftingContentItem;

    public GameObject Prefab_CraftingSlot => prefab_CraftingSlot;

    #endregion


    private void Awake()
    {
        m_Transform = gameObject.GetComponent<Transform>();
        tabs_Transform = m_Transform.Find("Left/Tabs").GetComponent<Transform>();
        contents_Transform = m_Transform.Find("Left/Contents").GetComponent<Transform>();
        center_Transform = m_Transform.Find("Center").GetComponent<Transform>();
        
        prefab_CraftingTabsItem = Resources.Load<GameObject>("CraftingTabsItem");
        prefab_CraftingContent = Resources.Load<GameObject>("CraftingContent");
        prefab_CraftingContentItem = Resources.Load<GameObject>("CraftingContentItem");
        prefab_CraftingSlot = Resources.Load<GameObject>("CraftingSlot");
        
        tabIconDic = new Dictionary<string, Sprite>();
        TabsIconLoad();
    }

    /// <summary>
    /// 加载所有选项卡图标.
    /// </summary>
    private void TabsIconLoad()
    {
        Sprite[] tempSprites = Resources.LoadAll<Sprite>("TabIcon");
        for (int i = 0; i < tempSprites.Length; i++)
        {
            tabIconDic.Add(tempSprites[i].name, tempSprites[i]);
        }
    }

    /// <summary>
    /// 通过名称查找字典中的一个图片对象
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public Sprite ByNameGetSprite(string name)
    {
        Sprite temp = null;
        tabIconDic.TryGetValue(name, out temp);
        return temp;
    }
}