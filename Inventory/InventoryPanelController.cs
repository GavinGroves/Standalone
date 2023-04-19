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
    private int slotNum = 27;

    //集合存储生成的slot对象(后面Item需要获取父物体Transform使用
    private List<GameObject> slotList = new List<GameObject>(); 

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
            //父物体为Grid
            GameObject tempSlot = Instantiate(m_InventoryPanelView.PrefabSlot,
                m_InventoryPanelView.GridTransform);
            //物品槽对象存入集合
            slotList.Add(tempSlot);
        }
    }

    /// <summary>
    /// 生成全部物品(Item
    /// </summary>
    private void CreateAllItem()
    {
        //从M层接收处理好的数据
        List<InventoryItem> tempList = m_InventoryPanelModel.GetJsonList("InventoryJsonData");
        for (int i = 0; i < tempList.Count; i++)
        {
            //生成Item单个物品,父物体为Slot物品槽
            GameObject temp = Instantiate(m_InventoryPanelView.PrefabItem, slotList[i].GetComponent<Transform>());
            //将接收到的json数据一一传递给单个Item物品控制器（InventoryItemController）
            temp.GetComponent<InventoryItemController>().InitItem(tempList[i].ItemName, tempList[i].ItemNum);
        }
    }
}