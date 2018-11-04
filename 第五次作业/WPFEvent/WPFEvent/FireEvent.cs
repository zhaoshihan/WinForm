using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFEvent
{
    public class FireEventArgs : EventArgs
    {
        public FireEventArgs(string room, int ferocity)
        {
            this.room = room;
            this.ferocity = ferocity;
        }

        public string room;
        public int ferocity;

    }

    public class FireAlarm
    {
        public delegate void FireEventHandler(object sender, FireEventArgs fe);
        public event FireEventHandler FireEvent;

        public void ActivateFireAlarm(string room, int ferocity)
        {
            FireEventArgs fireArgs = new FireEventArgs(room, ferocity);
            FireEvent(this, fireArgs);
        }
    }
}