using ChinookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookWcfService
{
    public class ChinookService : IChinookService
    {

        public List<ArtistDTO> GetArtists()
        {
            List<ArtistDTO> artists = new List<ArtistDTO>();

            using (var context = new ChinookEntities())
            {
                var query = context.Artists.ToList();
                foreach (var artist in query)
                {
                    artists.Add(new ArtistDTO
                    {
                        Name = artist.Name
                    });
                }
            }

            return artists;
        }

        public List<ArtistAlbums> GetArtistsAlbums()
        {
            List<ArtistAlbums> artistAlbums = new List<ArtistAlbums>();
            using (var context = new ChinookEntities())
            {
                var query = context.Artists.ToList();
                foreach (var artist in query)
                {
                    ArtistAlbums artAlbums = new ArtistAlbums();
                    artAlbums.Name = artist.Name;
                    foreach (var album in artist.Albums)
                    {
                        artAlbums.Albums.Add(album.Title);
                    }
                    artistAlbums.Add(artAlbums);
                }
            }

            return artistAlbums;
        }
    }
}
