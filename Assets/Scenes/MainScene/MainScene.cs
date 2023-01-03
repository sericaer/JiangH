using JiangH.Interfaces;
using JiangH.Sessions;
using UnityEngine;

class MainScene : MonoBehaviour
{
    public MapRender mapRender;
    public DateControl dateControl;

    private ISession session;

    public Canvas uiCanvas;
    public SectTable prefabAllSects;
    public RegionTable prefabAllRegions;

    public void OnShowSects()
    {
        var sectTable = Instantiate(prefabAllSects, uiCanvas.transform);
        sectTable.gmData = session.sects;
    }

    public void OnShowRegions()
    {
        var regionTable = Instantiate(prefabAllRegions, uiCanvas.transform);
        regionTable.gmData = session.regions;
    }

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

        TerminalCommand.session = session;
    }

    private void Start()
    {
        mapRender.SetSession(session);
        dateControl.SetSession(session);
    }

    private void Update()
    {
        
    }
}
