using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int playerCurrency;
    public Vector3 playerPosition;
    public Vector3 playerRotation;
    //public SerializableDictionary<string, bool> coinsCollected;

    // the values defined in this constructor will be the default values
    // the game starts with when there's no data to load
    public GameData()
    {
        this.playerCurrency = 0;
        playerPosition = Vector3.zero;
        playerRotation = Vector3.zero;
        //coinsCollected = new SerializableDictionary<string, bool>();
    }
}
