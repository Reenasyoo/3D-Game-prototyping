using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{

    private GameData _data = new GameData();
    void Start()
    {
        _data._playerData.coins = 10;
        _data._playerData.playerPosition = transform.position;
    }

    void Update()
    {
        // Save
        if (Input.GetKeyDown(KeyCode.I))
        {
            Save();
        }

        // Load
        if (Input.GetKeyDown(KeyCode.O))
        {
            Load3();
        }
    }

    private void Save1()
    {
        PlayerPrefs.SetFloat("PlayerX", transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", transform.position.y);
        PlayerPrefs.SetFloat("PlayerZ", transform.position.z);
    }

    private void Load1()
    {
        if (PlayerPrefs.HasKey("PlayerX"))
        {
            var x = PlayerPrefs.GetFloat("PlayerX");
            print("Loaded");
        }
        else
        {
            print("NO key");
        }
    }

    private void Save2()
    {
        print("Saved");
        var pos = transform.position;
        var json = JsonUtility.ToJson(pos);
        PlayerPrefs.SetString("PlayerPos", json);
    }

    private void Load2()
    {
        var json = PlayerPrefs.GetString("PlayerPos");
        var pos = JsonUtility.FromJson<Vector3>(json);
        print(pos);
        transform.position = pos;
    }

    private void Save3()
    {
        var coins = 10;
        var data = new GameData();

        data._playerData.coins = coins;
        data._playerData.playerPosition = transform.position;

        var json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("Data", json);
    }

    private void Load3()
    {
        if (PlayerPrefs.HasKey("Data"))
        {
            var json = PlayerPrefs.GetString("Data");
            print(json);
            var data = JsonUtility.FromJson<GameData>(json);

            transform.position = data._playerData.playerPosition;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            var pos = other.transform.position;
            SetData(pos);
            Save();
            print("EnteredCheckpoint");
        }
    }

    private void SetData(Vector3 position)
    {
        _data._playerData.playerPosition = position;
    }

    private void Save()
    {
        var json = JsonUtility.ToJson(_data);
        PlayerPrefs.SetString("Data", json);
    }
}

[Serializable]
public class GameData
{
    public PlayerData _playerData = new PlayerData();
}

[Serializable]
public class PlayerData
{
    public Vector3 playerPosition;
    public int coins = 0;
}