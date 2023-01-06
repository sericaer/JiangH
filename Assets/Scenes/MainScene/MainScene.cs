using JiangH.Interfaces;
using JiangH.Messages;
using JiangH.Sessions;
using UnityEngine;

class MainScene : MonoBehaviour
{
    public static Transform UIRoot;

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
        var sectTable = Instantiate(prefabAllSects, UIRoot);
        sectTable.gmData = session.sects;
    }

    public void OnShowRegions()
    {
        var table = Instantiate(prefabAllRegions, UIRoot);
        table.gmData = session.regions;
        table.showRegionDetail.AddListener((region) => 
        {
            var detail = Instantiate(pefabRegionDetail, UIRoot);
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

            detail.removePatroler.AddListener((person) =>
            {
                var msg = new MESSAGE_REMOVE_PATROLER_FROM_REGION()
                {
                    patroler = person
                };

                session.messageBus.SendMessage(msg);
            });
        });
    }

    public void OnShowAllPerson()
    {
        var table = Instantiate(pefabTablePerson, UIRoot);
        table.gmData = session.persons;
    }

    private void Awake()
    {
        UIRoot = uiCanvas.transform;

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
