using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MusicServices.MusicBrain.Release
{
    public class ReleaseNode
    {
        public ReleaseNode( XmlNodeList Nodes, XmlNamespaceManager Nsmanager)
        {
            this.Nodes = Nodes;
            this.Nsmanager = Nsmanager;
        }

        public XmlNodeList Nodes { get; set; }
        public XmlNamespaceManager Nsmanager { get; set; }
    }
}
