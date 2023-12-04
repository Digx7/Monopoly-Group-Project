using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAvatarDatabaseEntry", menuName = "ScriptableObjects/AvatarDatabase/Entries", order = 1)]
public class AvatarDatabaseEntry : ScriptableObject
{
    public int ID;
    public GameObject prefab;
}
