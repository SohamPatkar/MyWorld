using TMPro;
using UnityEngine;

public class UIView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI woodAmount;
    [SerializeField] private TextMeshProUGUI stoneAmount;

    void OnEnable()
    {
        EventService.Instance.WoodAmountChanged.AddListener(ShowWoodAmount);
        EventService.Instance.StoneAmountChanged.AddListener(ShowStoneAmount);
    }

    void OnDisable()
    {
        EventService.Instance.WoodAmountChanged.RemoveListener(ShowWoodAmount);
        EventService.Instance.StoneAmountChanged.RemoveListener(ShowStoneAmount);
    }

    public void ShowStoneAmount(int amount)
    {
        stoneAmount.text = "" + amount;
    }

    public void ShowWoodAmount(int amount)
    {
        woodAmount.text = "" + amount;
    }
}
