using AudioStreaming.Admin.Infrastructure;
using AudioStreaming.Domain;
using AudioStreaming.Infrastructure;

namespace AudioStreaming.Application;

public class PlaylistService
{
    private readonly PlaylistRepository _playlistRepository;
    private readonly MusicRepository _musicRepository;
    private readonly CustomerRepository _customerRepository;

    public PlaylistService(PlaylistRepository playlistRepository, MusicRepository musicRepository, CustomerRepository customerRepository)
    {
        _playlistRepository = playlistRepository;
        _musicRepository = musicRepository;
        _customerRepository = customerRepository;
    }

    public IEnumerable<ResponsePlaylistDTO> GetAll()
    {
        return _playlistRepository.GetAll().Select(playlist => new ResponsePlaylistDTO{
            Id = playlist.Id.ToString(),
            Name = playlist.Name,
            Description = playlist.Description
        }).ToList();
    }

    public ResponsePlaylistDTO GetById(string id)
    {
        Playlist playlist = _playlistRepository.GetById(id);
        return new ResponsePlaylistDTO{
            Id = playlist.Id.ToString(),
            Name = playlist.Name,
            Description = playlist.Description,
            OwnerId = playlist.Owner.Id.ToString(),
            Musics = playlist.Musics.Select(music => new ResponseMusicDTO{
                Id = music.Id.ToString(),
                Name = music.Name,
                Duration = music.Duration,
                Album = new ResponseAlbumDTO{
                    Id = music.Album.Id.ToString(),
                    Name = music.Album.Name,
                    ImageUrl = music.Album.ImageUrl
                }
            }).ToList()
        };
    }

    public void Create(RequestPlaylistDTO playlist)
    {
        Customer customer = _customerRepository.GetById(playlist.OwnerId);
        _playlistRepository.Add(new Playlist(playlist.Name, playlist.Description, customer));
    }

    public void AddMusic(string playlistId, string musicId)
    {
        Playlist playlist = _playlistRepository.GetById(playlistId);
        Music music = _musicRepository.GetById(musicId);
        playlist.AddMusics(new List<Music>{music});
        _playlistRepository.Update(playlist);
    }
}
