using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 背包界面控制
/// </summary>
public class InventoryPanelView : MonoBehaviour
{
    private Transform m_Transform;
    private Transform grid_Transform; //父物体
    private GameObject prefab_Item;
    private GameObject prefab_Slot;

    #region 公开Get属性

    public Transform Transform => m_Transform;

    public Transform GridTransform => grid_Transform;

    public GameObject PrefabItem => prefab_Item;

    public GameObject PrefabSlot => prefab_Slot;

    #endregion
    
    private void Awake()
    {
        m_Transform = gameObject.GetComponent<Transform>();
        grid_Transform = m_Transform.Find("BackGround/Grid").GetComponent<Transform>();
        prefab_Item = Resources.Load<GameObject>("InventoryItem");
        prefab_Slot = Resources.Load<GameObject>("InventorySlot");
    }
}