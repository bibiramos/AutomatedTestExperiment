using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace ECommerceAutomatedTest.Config
{
    public class TestConfig
    {
        public int driverWaitTimeoutInSeconds
        {
            get;

            set;
        }

        public int numberOfItemsOnCart
        {
            get;

            set;
        }

        public string searchTerm
        {
            get;

            set;
        }

        public string siteUrl
        {
            get;

            set;
        }

        public TestConfig()
        {
            this.driverWaitTimeoutInSeconds = Int32.Parse(ConfigurationManager.AppSettings["driverWaitTimeoutInSeconds"]);

            this.numberOfItemsOnCart = Int32.Parse(ConfigurationManager.AppSettings["numberOfItemsOnCart"]);

            this.searchTerm = ConfigurationManager.AppSettings["searchTerm"];

            this.siteUrl = ConfigurationManager.AppSettings["siteUrl"];
        }
    }
}
