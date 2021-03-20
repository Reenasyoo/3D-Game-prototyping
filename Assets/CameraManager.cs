using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private CinemachineBrain _brain = null;
    [SerializeField] private List<CinemachineVirtualCameraBase> _cameraList = new List<CinemachineVirtualCameraBase>();
    
    
    
    private Dictionary<string, CinemachineVirtualCameraBase> cameraBases = new Dictionary<string, CinemachineVirtualCameraBase>();

    // public List<PlayerScore> _playerScores = new List<PlayerScore>();
    // private Dictionary<string, int> scores = new Dictionary<string, int>();
    
    
    void Start()
    {
        foreach (var camera in _cameraList)
        {
            cameraBases.Add(camera.name, camera);
        }

        foreach (var cam in cameraBases)
        {
            Debug.Log($"Camera name : {cam.Key}");
        }

        // foreach (var player in _playerScores)
        // {
        //     scores.Add(player.name, player.highscore);
        // }
        //
        // foreach (var score in scores)
        // {
        //     print($"Player name : {score.Key}, hightscore : {score.Value}");
        // }
        //
        // print(scores["b"]);

        cameraBases["LOOK"].Priority = -1;
        print(cameraBases.ElementAt(0).Key);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            if (_brain.ActiveVirtualCamera.Name.Equals("Player Camera"))
            {
                SetActiveCamera("LOOK");    
            }
            else
            {
                SetActiveCamera("Player Camera");
            }
        }
        
    }

    private void DisableAllCameras()
    {
        foreach (var cameraBase in cameraBases)
        {
            cameraBase.Value.gameObject.SetActive(false);
        }
    }

    private void SetActiveCamera(string cameraName)
    {
        DisableAllCameras();
        cameraBases[cameraName].gameObject.SetActive(true);
    }
    
    
}

[System.Serializable]
public class PlayerScore
{
    public string name;
    public int highscore;
}