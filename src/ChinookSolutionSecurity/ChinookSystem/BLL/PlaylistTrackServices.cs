using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#region Additional Namespaces
using ChinookSystem.ViewModels;
using ChinookSystem.Entities;
using ChinookSystem.BLL;
using ChinookSystem.DAL;
#endregion

namespace ChinookSystem.BLL
{
    public class PlaylistTrackServices
    {
        #region Constructor and Context Dependency
        private readonly ChinookContext _context;

        //obtain the context link from IServiceCollection when this
        //  set of service is injected into the "outside user"
        internal PlaylistTrackServices(ChinookContext context)
        {
            _context = context;
        }

        #endregion

        #region Queries
        //This is ThreadExceptionEventArgs query that gets me the playlist tracks
        public List<PlaylistTrackInfo> PlaylistTrack_GetUserPlaylistTracks(string playlistname, string username)
        {
            IEnumerable<PlaylistTrackInfo> info = _context.PlaylistTracks
                                    .Where(x => x.Playlist.Name.Equals(playlistname)
                                    && x.Playlist.UserName.Equals(username))
                                    .Select(x => new PlaylistTrackInfo
                                    {
                                        TrackId = x.TrackId,
                                        TrackNumber = x.TrackNumber,
                                        SongName = x.Track.Name,
                                        Miliseconds = x.Track.Milliseconds
                                    })
                                    .OrderBy(x => x.TrackNumber);
            return info.ToList();

        }
        #endregion
        #region Commands


        #endregion
    }
}
