using MusicServices.Dto;
using Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace MusicServices.MusicBrain.Release
{
    public  static class ReleaseMusicBrain
    {
        private static XmlDocument GetXMLReleases(string url)
        {
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load(url);

            return xmlDoc;
        }

        private static ReleaseNode GetReleaseNodes(string id)
        {
            string url = "http://musicbrainz.org/ws/2/release/?query=arid:" + id + "&limit=10";

            XmlDocument xml = GetXMLReleases(url);

            //Add manager namespace:
            var nsManager = new XmlNamespaceManager(xml.NameTable);
            nsManager.AddNamespace("mbz", "http://musicbrainz.org/ns/mmd-2.0#");

            //Get Release Nodes
            XmlNodeList nodes = xml.SelectNodes("//mbz:metadata/mbz:release-list/mbz:release", nsManager);

            return new ReleaseNode(nodes, nsManager);
        }


        public static List<ReleaseDto> GetReleases(string id)
        {
            var releaseNode = GetReleaseNodes(id);

            List<ReleaseDto> ListRelease = new List<ReleaseDto>();

            foreach (XmlNode node in releaseNode.Nodes)
            {
                ReleaseDto release = new ReleaseDto();

                release.ReleaseId = node.Attributes["id"].Value;
                release.Title = node.SelectSingleNode("mbz:title", releaseNode.Nsmanager).InnerText;
                release.Status = node.SelectSingleNode("mbz:status", releaseNode.Nsmanager) != null ? node.SelectSingleNode("mbz:status", releaseNode.Nsmanager).InnerText : string.Empty;

                //Label node 
                var labelnode = node.SelectSingleNode("mbz:label-info-list/mbz:label-info/mbz:label/mbz:name", releaseNode.Nsmanager);
                if (labelnode != null)
                    release.Label = labelnode.InnerText;

                release.NumberOfTracks = System.Int32.Parse(node.SelectSingleNode("mbz:medium-list/mbz:track-count", releaseNode.Nsmanager).InnerText ?? "0");

                //other artists
                List<OtherArtistDto> OtherArtists = new List<OtherArtistDto>();

                XmlNodeList Artists = node.SelectNodes("mbz:artist-credit/mbz:name-credit/mbz:artist", releaseNode.Nsmanager);
                foreach (XmlNode artist in Artists)
                {
                    string artistid = artist.Attributes["id"].Value;

                    // not need to add self as a colaborating artist on one's own release
                    if (artistid != id)
                    {
                        var otherArtist = new OtherArtistDto();
                        otherArtist.Id = id;
                        otherArtist.Name = artist.SelectSingleNode("mbz:name", releaseNode.Nsmanager).InnerText;
                        OtherArtists.Add(otherArtist);
                    }
                }
                release.OtherArtists = OtherArtists;
                ListRelease.Add(release);
            }


            return ListRelease;
        }


        //public static int GetReleaseCount(string id)
        //{
        //    var releaseNode = GetReleaseNodes(id);
        //    return releaseNode.Nodes.Count;
        //}
    }
}
