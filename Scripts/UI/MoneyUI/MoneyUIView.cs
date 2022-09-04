using UnityEngine;
using UnityEngine.UI;
public class MoneyUIView : MonoBehaviour
{
    internal int basicTextSize = 25;
    int biggerTextSize = 34;
    bool isTextBig;
    internal Text Text { get => text ??= GetComponentInChildren<Text>(); }
    Text text;

    internal void InitializeMoneyCount(float money, float operationMoney)
    {
        operationMoney = 0;
        money = 0;
        Text.text = money.ToString();
    }

    internal void ChangeMoneyAmountOnUI(ref float currentMoney, ref float newMoney, float interpolateStep, float interpolateModifier)
    {
        currentMoney = Mathf.Lerp(currentMoney, newMoney, interpolateStep) + interpolateModifier;
        Text.text = ((int)currentMoney).ToString();
        ChangeTextSize();
    }

    void ChangeTextSize()
    {
        Text.fontSize = isTextBig ? basicTextSize : biggerTextSize;
        isTextBig = !isTextBig;
    }
}
