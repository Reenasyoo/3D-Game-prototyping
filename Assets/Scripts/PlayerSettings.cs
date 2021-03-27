using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettings", menuName =  "Settings/PlayerSettings" )]
public class PlayerSettings : ScriptableObject
{
    public float moveSpeed = 5f;
    public float jumpHeight = 10f;
    public float rotationSpeed = 10f;
}
