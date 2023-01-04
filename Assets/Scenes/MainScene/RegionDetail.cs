using JiangH.Interfaces;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

class RegionDetail : MonoBehaviour
{
    public IRegion gmData { get; set; }

    public Text regionName;
    public Text treausryPdt;

    public PatrolerPanel defaultPatroler;

    public UnityEvent<IPerson> addPatroler;
    public UnityEvent<IPerson> removePatroler;

    public Button addPatrolerButton;
    public Button removePatrolerButton;

    void Start()
    {
        defaultPatroler.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        regionName.text = gmData.name;
        treausryPdt.text = gmData.productor.value.ToString();

        foreach (var patrolerPanel in defaultPatroler.GetComponentsInParent<PatrolerPanel>())
        {
            if(gmData.patrolers.All(x=> x != patrolerPanel.gmData))
            {
                Destroy(patrolerPanel.gameObject);
            }
        }

        var container = defaultPatroler.transform.parent;
        foreach (var patroler in gmData.patrolers)
        {
            if(container.GetComponentsInChildren<PatrolerPanel>().All(x=>x.gmData != patroler))
            {
                var item = Instantiate(defaultPatroler, container);
                item.gmData = patroler;
                item.gameObject.SetActive(true);
            }
        }
    }
}
