using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Tabs侧栏单个Item控制器
/// </summary>
public class CraftingTabItemController : MonoBehaviour
{
    private Transform m_Transform;
    private Button m_Button;
    private GameObject m_ButtonBG;//按下隐藏背景
    private Image m_Icon;

    private int index = -1;//当前Item索引值

    private void Awake()
    {
        m_Transform = gameObject.GetComponent<Transform>();
        m_Button = gameObject.GetComponent<Button>();
        m_ButtonBG = m_Transform.Find("Center_BG").gameObject;
        m_Icon = m_Transform.Find("Icon").GetComponent<Image>();
        m_Button.onClick.AddListener(ButtonOnClickUpSendIndex);
    }

    /// <summary>
    /// 初始化选项卡
    /// </summary>
    public void InitTabs(int index)
    {
        this.index = index;
        gameObject.name = "Tab" + index;
    }

    /// <summary>
    /// 选项卡默认状态
    /// </summary>
    public void NormalTab()
    {
        if (m_ButtonBG.activeSelf == false)
        {
            m_ButtonBG.SetActive(true);
        }
    }

    /// <summary>
    /// 选项卡激活状态
    /// </summary>
    public void ActiveTab()
    {
        m_ButtonBG.SetActive(false);
    }

    private void ButtonOnClickUpSendIndex()
    {
        SendMessageUpwards("ResetTabsAndContents",index);
    }
}
