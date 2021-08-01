using System;
using XOContracts;

namespace PlayerImpl
{
    public class Player
    {
        private XorO _mark;

        public Player()
        {
            _mark = XorO.X;
        }
        public XorO Mark
        {
            get
            {
                return _mark;
            }
            set
            {
                _mark = value;
            }

        }
    }
}