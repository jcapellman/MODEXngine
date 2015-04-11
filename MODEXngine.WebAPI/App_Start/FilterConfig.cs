using System.Web.Mvc;

using MODEXngine.WebAPI.Filters;

namespace MODEXngine.WebAPI {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new Authentication());
        }
    }
}