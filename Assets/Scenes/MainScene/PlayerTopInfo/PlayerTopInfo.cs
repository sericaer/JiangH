using JiangH.Interfaces;
using System;
using UnityEngine;

class PlayerTopInfo : MonoBehaviour
{
    public PlayerPanel playerPanel;
    public PlayerSectData playerSectData;

    private ISession session;


    public void FixedUpdate()
    {
        playerPanel.player = session.player;
        playerSectData.sect = session.player.sect;
        playerSectData.office = session.player.office;
    }

    internal void SetSession(ISession session)
    {
        this.session = session;

        FixedUpdate();
    }
}