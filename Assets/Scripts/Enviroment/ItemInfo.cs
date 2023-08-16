using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    [TextArea]
    [SerializeField] private string itemInfo;
    [SerializeField] private float time2Show;

    public string GetItemInfo => itemInfo;
    public float GetTime2Show => time2Show;
}
