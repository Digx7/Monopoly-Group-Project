using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAvatarPeice : MonoBehaviour
{
    public int owningPlayerID;
    public int avatarID;
    public int boardLocation;

    public AvatarDatabase avatarDatabase;

    private GameObject avatar;

    public void Setup(int playerID = 0, int _avatarID = 0, int _boardLocation = 0)
    {
        owningPlayerID = playerID;
        avatarID = _avatarID;
        boardLocation = _boardLocation;

        //make any connections to owning player

        //render correct avatar
        RenderAvatar();

        //place in correct board spot
    }

    private void RenderAvatar()
    {
        if(avatar != null) Destroy(avatar);

        GameObject prefab = avatarDatabase.avatars[avatarID].prefab;

        avatar = Instantiate(prefab, gameObject.transform);
    }
}
