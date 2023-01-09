using CommandTerminal;
using JiangH.Interfaces;
using JiangH.Messages;
using JiangH.Messages.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class TerminalCommand
{
    public static ISession session
    {
        get
        {
            return _session;
        }
        set
        {
            _session = value;
            _session.messageBus.Register(comm);
        }
    }

    public static IMessageOut comm = new Communication();

    private static ISession _session;


    [RegisterCommand(Help = "", MaxArgCount = 2, MinArgCount = 2)]
    public static void CommandChangeRegionOwner(CommandArg[] args)
    {
        var msg = new MESSAGE_CHANGE_REGION_OWNER()
        {
            region = session.regions.Single(x => x.name == args[0].String),
            owner = session.sects.Single(x => x.name == args[1].String)
        };

        comm.SendMessage(msg);
    }

    [RegisterCommand(Help = "", MaxArgCount = 2, MinArgCount = 2)]
    public static void CommandAddPatrolerToRegion(CommandArg[] args)
    {
        var msg = new MESSAGE_ADD_PATROLER_TO_REGION()
        {
            patroler = session.persons.Single(x => x.name == args[0].String),
            region = session.regions.Single(x => x.name == args[1].String)
        };

        comm.SendMessage(msg);
    }

    [RegisterCommand(Help = "", MaxArgCount = 1, MinArgCount = 1)]
    public static void CommandChangePlayer(CommandArg[] args)
    {
        var msg = new MESSAGE_CHANGE_PLAYER()
        {
            newPlayer = session.persons.Single(x => x.name == args[0].String),
        };

        comm.SendMessage(msg);
    }

    private class Communication : MessageOut
    {
    }
}
