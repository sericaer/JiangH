using JiangH.Interfaces;
using JiangH.Sessions;
using UnityEngine;

class MainScene : MonoBehaviour
{
    public MapRender mapRender;
    public DateControl dateControl;
    public SectTable sectTable;

    private ISession session;

    private void Awake()
    {
        var gmInit = new GMInit()
        {
            mapHeight = 21,
            mapWidth = 31,
            regionCount = 30,
            sectCount = 10
        };

        session = Session.Builder.Build(gmInit);
    }

    private void Start()
    {
        sectTable.gmData = session.sects;

        mapRender.SetSession(session);
        dateControl.SetSession(session);
    }
}
