using System;

using MODEXngine.PCL.Transports.Internal;

namespace MODEXngine.WebBusinessLayer.Managers {
    public class AuthManager : BaseManager {
        public AuthUserToken GetAuthUserTokenFromHeaderToken(Guid token) {
            return new AuthUserToken();
        }
    }
}