using Interview.Web.Common;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interview.Web
{
    public class AppSettings: IAppSettings
    {
        private readonly string _inventoryConnectionString;
        public AppSettings(IConfiguration configuration)
        {
            _inventoryConnectionString = configuration["InventoryConnectionString"];
        }
        public string InventoryConnectionString => _inventoryConnectionString;
    }
}
