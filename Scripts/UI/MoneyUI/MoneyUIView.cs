using UnityEngine;
using UnityEngine.UI;
public class MoneyUIView : MonoBehaviour
{
    internal int basicTextSize = 25;
    int biggerTextSize = 34;
    internal Text Text { get => text ??= GetComponentInChildren<Text>(); }
    Text text;

    internal void InitializeMoneyCount(int money, int operationMoney)
    {
        operationMoney = 0;
        money = 0;
        Text.text = money.ToString();
    }

    internal void ChangeMoneyAmountOnUI(ref int currentMoney)
    {
        currentMoney += 1;
        Text.text = currentMoney.ToString();
        ChangeTextSize(currentMoney);
    }

    void ChangeTextSize(int currentMoney) => Text.fontSize =
        currentMoney % 2 == 0 ? basicTextSize : biggerTextSize;

}
