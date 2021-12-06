using System;

namespace VidyaBase.DOMAIN
{
    public class GObject
    {
        private bool success = true;

        public bool Successful
        {
            get { return success; }
        }

        private VidyaException vex = null;

        public VidyaException Vex
        {
            get { return vex; }
            set
            {
                success = false;
                vex = value;
            }

        }
    }
}
