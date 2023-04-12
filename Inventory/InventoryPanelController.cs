using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 背包模块总控制器
/// </summary>
public class InventoryPanelController : MonoBehaviour
{
    //持有V和M对象
    private InventoryPanelModel m_InventoryPanelModel;
    private InventoryPanelView m_InventoryPanelView;
    private int slotNum = 24;

    private List<GameObject> slotList = new List<GameObject>(); //集合存储生成的slot对象

    void Start()
    {
        m_InventoryPanelModel = gameObject.GetComponent<InventoryPanelModel>();
        m_InventoryPanelView = gameObject.GetComponent<InventoryPanelView>();
        CreateAllSlot();
        CreateAllItem();
    }

    /// <summary>
    /// 生成全部物品槽(InventorySlot
    /// </summary>
    private void CreateAllSlot()
    {
        for (int i = 0; i < slotNum; i++)
        {
            GameObject tempSlot = Instantiate(m_InventoryPanelView.GetPrefabSlot(),
                m_InventoryPanelView.GetGridTransform());
            slotList.Add(tempSlot);
        }
    }
    
    /// <summary>
    /// 生成全部物品(InventoryItem
    /// </summary>
    private void CreateAllItem()
    {
        //先用测试数据
        List<InventoryItem> tempList = new List<InventoryItem>();
        tempList.Add(new InventoryItem("Axe",10)); 
        tempList.Add(new InventoryItem("Torch",30)); 
        tempList.Add(new InventoryItem("Arrow",50));
        for (int i = 0; i < tempList.Count; i++)
        {
            GameObject temp = Instantiate(m_InventoryPanelView.GetPrefabItem(), slotList[i].GetComponent<Transform>());
            temp.GetComponent<InventoryItemController>().InitItem(tempList[i].ItemName,tempList[i].ItemNum);
        }
    }
}