using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using MODEXngine.PCL.Common;
using MODEXngine.WebBusinessLayer.Managers;

namespace MODEXngine.WebAPI.Filters {
    public class Authentication : DelegatingHandler {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
            if (request.RequestUri.PathAndQuery.Contains("Auth")) {
                return await base.SendAsync(request, cancellationToken);
            }

            try {
                var token = request.Headers.GetValues("Token").FirstOrDefault();

                if (token == null) {
                    throw new MODEXception("No token in Header found");
                }

                var result = new AuthManager().GetAuthUserTokenFromHeaderToken(Guid.Parse(token));

                if (result == null) {
                    throw new MODEXception("Token invalid");
                }

                request.Properties.Add(Constants.WEBAPI_Header_Token, result);

                return await base.SendAsync(request, cancellationToken);
            } catch (MODEXception ex) {
                var response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                var tsc = new TaskCompletionSource<HttpResponseMessage>();

                tsc.SetResult(response);

                return await tsc.Task;
            }
        }
    }
}