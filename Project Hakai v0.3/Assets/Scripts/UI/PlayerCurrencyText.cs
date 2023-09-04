using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCurrencyText : MonoBehaviour, IDataPersistence
{
    private int playerCurrency = 0;

    private TextMeshProUGUI playerCurrencyText;

    private void Awake()
    {
        playerCurrencyText = this.GetComponent<TextMeshProUGUI>();
    }

    public void LoadData(GameData data)
    {
        this.playerCurrency = data.playerCurrency;
    }

    public void SaveData(ref GameData data)
    {
        data.playerCurrency = this.playerCurrency;
    }

    private void Start()
    {
        // subscribe to events
    }

    private void OnDestroy()
    {
        // unsubscribe from events
    }

    private void OnCoinGain()
    {
        // gain coin
    }

    private void Update()
    {
        playerCurrencyText.text = "" + playerCurrency;
    }
}
