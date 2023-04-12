using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 背包内单个Item物品控制器
/// </summary>
public class InventoryItemController : MonoBehaviour
{
    private Transform m_Transform;
    private Image m_Image;
    private Text m_Text;
    private void Awake()
    {
        m_Transform = gameObject.GetComponent<Transform>();
        m_Image = gameObject.GetComponent<Image>();
        m_Text = m_Transform.Find("Num").GetComponent<Text>();
    }

    /// <summary>
    /// 传递数据初始化Item
    /// </summary>
    /// <param name="name"></param>
    /// <param name="num"></param>
    public void InitItem(string name,int num)
    {
        m_Image.sprite = Resources.Load<Sprite>("Item/" + name);
        m_Text.text = num.ToString();
    }
}
