using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAvatarDatabase", menuName = "ScriptableObjects/AvatarDatabase/Database", order = 1)]
public class AvatarDatabase : ScriptableObject
{
    public List<AvatarDatabaseEntry> avatars;
}
