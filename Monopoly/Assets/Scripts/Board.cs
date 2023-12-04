using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Board : MonoBehaviour
{
    private List<PlayerAvatarPeice> playerAvatars;
    public GameObject avatarPrefab;
    public GameObject avatarPrefabParent;
    public GameObject spacesParent;

    public UnityEvent OnAvatarMoveStart;
    public UnityEvent OnAvatarMoveEnd;

    private BoardMove cuedMove;

    public void Awake()
    {
        playerAvatars = new List<PlayerAvatarPeice>();
        cuedMove = new BoardMove();
    }

    public void SetUpAvatar(PlayerStartData startData)
    {
        GameObject avatar = Instantiate(avatarPrefab, avatarPrefabParent.transform);
        PlayerAvatarPeice playerAvatarPeice = avatar.GetComponent<PlayerAvatarPeice>();

        playerAvatarPeice.Setup(startData.number, startData.avatar);

        playerAvatars.Add(playerAvatarPeice);

        TeleportAvatar(playerAvatarPeice.owningPlayerID, playerAvatarPeice.boardLocation);
    }

    public void CueAvatarMove(int owningPlayerID, int spacesToMove)
    {
        Debug.Log("Board cued to move player " + (owningPlayerID + 1) + "'s avatar " + spacesToMove + " spaces");
    
        cuedMove.playerID = owningPlayerID;
        cuedMove.startingBoardLocation = playerAvatars[owningPlayerID].boardLocation;
        cuedMove.endingBoardLocation = cuedMove.startingBoardLocation + spacesToMove;

        if(cuedMove.endingBoardLocation >= spacesParent.transform.childCount)
        {
            cuedMove.endingBoardLocation-= (spacesParent.transform.childCount);
        }
    
    }

    public void MoveAvatar()
    {
        Debug.Log("Board now moving player " + (cuedMove.playerID + 1) + "'s avatar from space " + cuedMove.startingBoardLocation + " to space " + cuedMove.endingBoardLocation);
    
        TeleportAvatar(cuedMove.playerID, cuedMove.endingBoardLocation);

        StartCoroutine(MovingPawn());

        cuedMove = new BoardMove();
    }

    public void TeleportAvatar(int owningPlayerID, int _boardLocation)
    {
        playerAvatars[owningPlayerID].boardLocation = _boardLocation;

        GameObject avatar = playerAvatars[owningPlayerID].gameObject;
        GameObject space = spacesParent.transform.GetChild(_boardLocation).gameObject;

        avatar.transform.localPosition = space.transform.localPosition;

    }

    private IEnumerator MovingPawn()
    {
        OnAvatarMoveStart.Invoke();

        // animate peice moveing, wait for it to stop
        yield return new WaitForSeconds(0.2f);

        OnAvatarMoveEnd.Invoke();

        yield return null;
    }

    public Tile GetAvatarsCurrentTile(int owningPlayerID)
    {
        int boardLocation = playerAvatars[owningPlayerID].boardLocation;
        GameObject tileGameObject = spacesParent.transform.GetChild(boardLocation).gameObject;
        Tile tile = tileGameObject.GetComponent<Tile>();
        return tile;
    }
}