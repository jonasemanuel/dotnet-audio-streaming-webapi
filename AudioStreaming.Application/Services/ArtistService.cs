using AudioStreaming.Admin.Infrastructure;
using AudioStreaming.Domain;

namespace AudioStreaming.Application;

public class ArtistService
{
    private readonly ArtistRepository _artistRepository;
    private readonly AlbumRepository _albumRepository;

    public ArtistService(ArtistRepository artistRepository, AlbumRepository albumRepository)
    {
        _artistRepository = artistRepository;
        _albumRepository = albumRepository;
    }

    public void Create(RequestArtistDTO request)
    {
        Artist artist = new Artist(request.Name, request.ImageUrl);
        _artistRepository.Add(artist);
    }

    public IEnumerable<ResponseArtistDTO> GetAll()
    {
        return _artistRepository.GetAll().Select(artist => new ResponseArtistDTO{
            Id = artist.Id.ToString(),
            Name = artist.Name,
            ImageUrl = artist.ImageUrl
        }).ToList();
    }

    public void AddAlbum(Guid artistId, RequestAlbumDTO album)
    {
        Artist artist = _artistRepository.GetById(artistId.ToString());
        artist.CreateAlbum(album.Name, album.ImageUrl);
        _artistRepository.Update(artist);
    }
}
