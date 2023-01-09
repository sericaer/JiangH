using JiangH.Interfaces;
using System;
using UnityEngine;

class PlayerTopInfo : MonoBehaviour
{
    public PlayerPanel playerPanel;
    public PlayerSectOfficePanel PlayerSectOfficePanel;

    private ISession session;


    public void FixedUpdate()
    {
        playerPanel.player = session.player;
        PlayerSectOfficePanel.sect = session.player.sect;
    }

    internal void SetSession(ISession session)
    {
        this.session = session;

        FixedUpdate();
    }
}