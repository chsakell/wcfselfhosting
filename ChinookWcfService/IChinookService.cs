using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChinookWcfService
{
    [ServiceContract]
    public interface IChinookService
    {
        [OperationContract]
        List<ArtistDTO> GetArtists();

        [OperationContract]
        List<ArtistAlbums> GetArtistsAlbums();
    }

    [DataContract]
    public class ArtistDTO
    {
        [DataMember]
        public string Name { get; set; }
    }

    [DataContract]
    public class ArtistAlbums
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public List<string> Albums { get; set; }
        public ArtistAlbums()
        {
            Albums = new List<string>();
        }
    }
}
