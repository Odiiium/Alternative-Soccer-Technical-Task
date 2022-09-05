using UnityEngine;

public class MoneyUIController : MonoBehaviour
{
    internal MoneyUIModel Model { get => moneyUIModel ??= new MoneyUIModel(); }
    MoneyUIModel moneyUIModel;
    internal MoneyUIView View { get => moneyUIView ??= GetComponentInChildren<MoneyUIView>(); }
    MoneyUIView moneyUIView;

    private void Awake() => View.InitializeMoneyCount(Model.Money, Model.OperationMoney);

    private void FixedUpdate()
    {
        if (Model.Money < Model.OperationMoney)
            View.ChangeMoneyAmountOnUI(ref Model.Money);
        else SetStandartSettingsToUI();
    }

    void SetStandartSettingsToUI()
    {
        Model.Money = Model.OperationMoney;
        View.Text.fontSize = View.basicTextSize;
    }
    internal void AddMoney(int value) => Model.OperationMoney += value;

}