using AudioStreaming.Domain;
using AudioStreaming.Infrastructure;

namespace AudioStreaming.Application;

public class MusicService
{
    private readonly MusicRepository _musicRepository;
    private readonly AlbumRepository _albumRepository;

    public MusicService(MusicRepository musicRepository, AlbumRepository albumRepository)
    {
        _musicRepository = musicRepository;
        _albumRepository = albumRepository;
    }

    public ResponseMusicDTO GetById(string id)
    {
        Music music = _musicRepository.GetById(id);
        return new ResponseMusicDTO{
            Id = music.Id.ToString(),
            Name = music.Name,
            Duration = music.Duration,
            Album = new ResponseAlbumDTO{
                Id = music.Album.Id.ToString(),
                Name = music.Album.Name,
                ImageUrl = music.Album.ImageUrl
            }
        };
    }

    public IEnumerable<ResponseMusicDTO> GetAll()
    {
        return _musicRepository.GetAll().Select(music => new ResponseMusicDTO{
            Id = music.Id.ToString(),
            Name = music.Name,
            Duration = music.Duration,
            Album = new ResponseAlbumDTO{
                Id = music.Album.Id.ToString(),
                Name = music.Album.Name,
                ImageUrl = music.Album.ImageUrl
            }
        });
    }

    public void Create(RequestMusicDTO request)
    {
        Album selectedAlbum = _albumRepository.GetById(request.AlbumId);
        Music music = new Music(request.Name, request.Duration, selectedAlbum);
        _musicRepository.Add(music);
    }

    public List<ResponseMusicDTO> Search(string query)
    {
        return _musicRepository.GetAll().Where(music => music.Name.Contains(query)).Select(music => new ResponseMusicDTO{
            Id = music.Id.ToString(),
            Name = music.Name,
            Duration = music.Duration,
            Album = new ResponseAlbumDTO{
                Id = music.Album.Id.ToString(),
                Name = music.Album.Name,
                ImageUrl = music.Album.ImageUrl
            }
        }).ToList();
    }
}
