using JiangH.Interfaces;
using JiangH.Messages;
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
    public PersonTable pefabTablePerson;
    public RegionDetail pefabRegionDetail;

    public void OnShowSects()
    {
        var sectTable = Instantiate(prefabAllSects, uiCanvas.transform);
        sectTable.gmData = session.sects;
    }

    public void OnShowRegions()
    {
        var table = Instantiate(prefabAllRegions, uiCanvas.transform);
        table.gmData = session.regions;
        table.showRegionDetail.AddListener((region) => 
        {
            var detail = Instantiate(pefabRegionDetail, uiCanvas.transform);
            detail.gmData = region;

            detail.addPatroler.AddListener((person) =>
            {
                var msg = new MESSAGE_ADD_PATROLER_TO_REGION()
                {
                    patroler = person,
                    region = region
                };

                session.messageBus.SendMessage(msg);
            });

            detail.addPatroler.RemoveListener((person) =>
            {

            });
        });
    }

    public void OnShowAllPerson()
    {
        var table = Instantiate(pefabTablePerson, uiCanvas.transform);
        table.gmData = session.persons;
    }

    private void Awake()
    {
        var gmInit = new GMInit()
        {
            mapHeight = 21,
            mapWidth = 31,
            regionCount = 30,
            sectCount = 10,
            personCount = 200
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
