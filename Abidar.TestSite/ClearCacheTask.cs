using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Abidar.Components;
using System.Xml;
using System.IO;
using System.Collections;

namespace Abidar.TestSite
{
    public class ClearCacheTask : ITask
    {
        #region ITask Members

        public void Execute(XmlNode configuration)
        {
            foreach (DictionaryEntry entry in HttpRuntime.Cache)
            {
                HttpRuntime.Cache.Remove(entry.Key.ToString());
            }
        }

        #endregion
    }
}
