using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 合成模块C
/// </summary>
public class CraftingPanelController : MonoBehaviour
{
    private CraftingPanelModel m_CraftingPanelModel;
    private CraftingPanelView m_CraftingPanelView;
    private int tabNums = 4; //侧栏数量
    private List<GameObject> tabsList;
    private List<GameObject> contentsList;

    void Start()
    {
        Init();
        CreateTabsItem();
        CreateContents();
        ResetTabsAndContents(0);
    }

    /// <summary>
    /// 初始化
    /// </summary>
    private void Init()
    {
        m_CraftingPanelModel = gameObject.GetComponent<CraftingPanelModel>();
        m_CraftingPanelView = gameObject.GetComponent<CraftingPanelView>();
        tabsList = new List<GameObject>();
        contentsList = new List<GameObject>();
    }

    /// <summary>
    /// 生成Tabs侧栏Item
    /// </summary>
    private void CreateTabsItem()
    {
        for (int i = 0; i < tabNums; i++)
        {
            GameObject item = Instantiate(m_CraftingPanelView.Prefab_CraftingTabsItem,
                m_CraftingPanelView.Tabs_Transform);
            item.GetComponent<CraftingTabItemController>().InitTabs(i);
            tabsList.Add(item);
        }
    }

    /// <summary>
    /// 生成Content
    /// </summary>
    private void CreateContents()
    {
        for (int i = 0; i < tabNums; i++)
        {
            GameObject content = Instantiate(m_CraftingPanelView.PrefabCraftingContent,
                m_CraftingPanelView.Contents_Transform);
            content.GetComponent<CraftingContentController>().InitContents(i,m_CraftingPanelView.PrefabCraftingContentItem);
            contentsList.Add(content);
        }
    }

    /// <summary>
    /// 重置选项卡和正文区域
    /// </summary>
    private void ResetTabsAndContents(int index)
    {
        for (int i = 0; i < tabsList.Count; i++)
        {
            tabsList[i].GetComponent<CraftingTabItemController>().NormalTab();
            contentsList[i].SetActive(false);
        }
        tabsList[index].GetComponent<CraftingTabItemController>().ActiveTab();
        contentsList[index].SetActive(true);
    }
}