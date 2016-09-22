﻿using Newtonsoft.Json.Linq;
using System.Linq;

namespace EDDiscovery.EliteDangerous.JournalEvents
{
    //When written: Player has escaped interdiction
    //Parameters: 
    //•	Interdictor: interdicting pilot name
    //•	IsPlayer: whether player or npc
    public class JournalEscapeInterdiction : JournalEntry
    {
        public JournalEscapeInterdiction(JObject evt, EDJournalReader reader) : base(evt, JournalTypeEnum.EscapeInterdiction, reader)
        {
            Interdictor = evt.Value<string>("Interdictor");
            IsPlayer = evt.Value<bool>("IsPlayer");
        }
        public string Interdictor { get; set; }
        public bool IsPlayer { get; set; }

    }
}