using System;

namespace MODEXngine.PCL.Common {
    public class MODEXception : Exception {
        private readonly string _exceptionStr;

        public MODEXception() { }

        public MODEXception(string exceptionStr) { _exceptionStr = exceptionStr; }

        public override string ToString() { return _exceptionStr; }
    }
}