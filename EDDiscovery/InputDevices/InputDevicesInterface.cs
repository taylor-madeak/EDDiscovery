﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDDiscovery.InputDevices
{
    public class InputDeviceIdentity
    {
        public string Name;
        public Guid Instanceguid, Productguid;
    }

    public class InputDeviceEvent
    {
        public InputDeviceInterface Device;

        public int EventNumber { get; set; }     // indentity of event : keys code, joystick buttons/axis/pov number, etc
        public bool Pressed { get; set; }   // button pressed.. or POV is not centred, or null if it does not press.
        public int Value { get; set; }      // if applicable, axis for instance..

        public InputDeviceEvent(InputDeviceInterface d, int en , bool p, int v = 0)
        {
            Device = d; EventNumber = en; Pressed = p; Value = v; 
        }

        public string ToString(int trunc = 1000)
        {
            return string.Format("Device {0} Event {1} Pressed {2} Value {3}", Device.ID().Name.Truncate(0, trunc), EventName(), Pressed, Value);
        }

        //public Tuple<string, bool> BindingsMatch() { return Device.BindingsMatch(this); }
        public string EventName() { return Device.EventName(this); }
    }

    public interface InputDeviceInterface
    {
        InputDeviceIdentity ID();
        System.Threading.AutoResetEvent Eventhandle();          // set when device changes state

        List<InputDeviceEvent> GetEvents();                     // get events after change state
        void Dispose();

        string EventName(InputDeviceEvent e);   // Frontier event name from input event

        bool? IsPressed(string eventname);       // if an input supports pressed, true/false, else null
    }
}