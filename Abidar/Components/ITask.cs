using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Abidar.Components
{
    public interface ITask
    {
        void Execute(XmlNode configuration);
    }
}
