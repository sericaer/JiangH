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

    [RegisterCommand(Help = "Test", MaxArgCount = 0)]
    public static void CommandTest(CommandArg[] args)
    {
        Terminal.Buffer.Clear();
    }

    [RegisterCommand(Help = "", MaxArgCount = 2, MinArgCount = 2)]
    public static void CommandChangeRegionOwner(CommandArg[] args)
    {
        var region = session.regions.Single(x => x.name == args[0].String);
        var sect = session.sects.Single(x => x.name == args[1].String);

        var msg = new MESSAGE_CHANGE_REGION_OWNER()
        {
            region = session.regions.Single(x => x.name == args[0].String),
            owner = session.sects.Single(x => x.name == args[1].String)
        };

        comm.SendMessage(msg);
    }

    private class Communication : MessageOut
    {
    }
}
