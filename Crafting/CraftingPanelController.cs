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

    private int tabNums = 2; //侧栏数量
    private int slotNums = 25; //图谱槽数量
    private int currentIndex = -1;

    private List<GameObject> tabsList;
    private List<GameObject> contentsList;
    private List<GameObject> slotsLists;

    void Start()
    {
        Init();
        CreateTabsItem();
        CreateContents();
        ResetTabsAndContents(0);
        CreateAllSlots();
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
        slotsLists = new List<GameObject>();
    }

    /// <summary>
    /// 生成全部选项卡，Tabs侧栏Item
    /// </summary>
    private void CreateTabsItem()
    {
        for (int i = 0; i < tabNums; i++)
        {
            GameObject item = Instantiate(m_CraftingPanelView.Prefab_CraftingTabsItem,
                m_CraftingPanelView.Tabs_Transform);
            Sprite temp = m_CraftingPanelView.ByNameGetSprite(m_CraftingPanelModel.GetTabsIconName()[i]);
            item.GetComponent<CraftingTabItemController>().InitTabs(i, temp);
            tabsList.Add(item);
        }
    }

    /// <summary>
    /// 生成全部内容区域，Content
    /// </summary>
    private void CreateContents()
    {
        List<List<CraftingContentItem>> tempList = m_CraftingPanelModel.ByNameGetJsonData("CraftingContentsJsonData");
        for (int i = 0; i < tabNums; i++)
        {
            GameObject content = Instantiate(m_CraftingPanelView.PrefabCraftingContent,
                m_CraftingPanelView.Contents_Transform);
            content.GetComponent<CraftingContentController>()
                .InitContents(i, m_CraftingPanelView.PrefabCraftingContentItem, tempList[i]);
            contentsList.Add(content);
        }
    }

    /// <summary>
    /// 重置选项卡和正文区域
    /// </summary>
    private void ResetTabsAndContents(int index)
    {
        if (currentIndex == index) return;
        for (int i = 0; i < tabsList.Count; i++)
        {
            tabsList[i].GetComponent<CraftingTabItemController>().NormalTab();
            contentsList[i].SetActive(false);
        }

        tabsList[index].GetComponent<CraftingTabItemController>().ActiveTab();
        contentsList[index].SetActive(true);
        currentIndex = index;
    }

    /// <summary>
    /// 生成所有的合成图谱槽
    /// </summary>
    private void CreateAllSlots()
    {
        for (int i = 0; i < slotNums; i++)
        {
            GameObject go = Instantiate(m_CraftingPanelView.Prefab_CraftingSlot, m_CraftingPanelView.Center_Transform);
            go.name = "slot" + i;
            slotsLists.Add(go);
        }
    }
}