using JiangH.Interfaces;
using System;
using UnityEngine;
using UnityEngine.UI;

class DateControl : MonoBehaviour
{
    public Text date;

    private ISession session;

    public void SetSession(ISession session)
    {
        this.session = session;
    }

    private void FixedUpdate()
    {
        date.text = $"{session.date.year}-{session.date.month}-{session.date.day}";
    }

    public void OnTimeInc()
    {
        session.date.DaysInc();
    }
}