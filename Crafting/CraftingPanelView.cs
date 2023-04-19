using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 合成模块V
/// </summary>
public class CraftingPanelView : MonoBehaviour
{
    private Transform m_Transform;
    private Transform tabs_Transform;
    private Transform contents_Transform;

    private GameObject prefab_CraftingTabsItem;
    private GameObject prefab_CraftingContent;
    private GameObject prefab_CraftingContentItem;

    #region 公开属性

    public Transform M_Transform => m_Transform;
    public Transform Tabs_Transform => tabs_Transform;
    public Transform Contents_Transform => contents_Transform;
    public GameObject Prefab_CraftingTabsItem => prefab_CraftingTabsItem;
    public GameObject PrefabCraftingContent => prefab_CraftingContent;
    public GameObject PrefabCraftingContentItem => prefab_CraftingContentItem;

    #endregion


    private void Awake()
    {
        m_Transform = gameObject.GetComponent<Transform>();
        tabs_Transform = m_Transform.Find("Left/Tabs").GetComponent<Transform>();
        contents_Transform = m_Transform.Find("Left/Contents").GetComponent<Transform>();
        prefab_CraftingTabsItem = Resources.Load<GameObject>("CraftingTabsItem");
        prefab_CraftingContent = Resources.Load<GameObject>("CraftingContent");
        prefab_CraftingContentItem = Resources.Load<GameObject>("CraftingContentItem");
    }
}