/// <summary>
/// 背包物品的数据实体类
/// </summary>
public class InventoryItem
{
    private string itemName;
    private int itemNum;

    public string ItemName
    {
        get { return itemName; }
        set { itemName = value; }
    }

    public int ItemNum
    {
        get { return itemNum; }
        set { itemNum = value; }
    }

    public InventoryItem()
    {
    }

    public InventoryItem(string itemName, int itemNum)
    {
        this.ItemName = itemName;
        this.ItemNum = itemNum;
    }

    public override string ToString()
    {
        return string.Format("物品名称：{0}，物品数量{1}", this.itemName, this.itemNum);
    }
}