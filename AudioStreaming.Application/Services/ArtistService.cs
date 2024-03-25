using AudioStreaming.Domain;
using AudioStreaming.Infrastructure;

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

    public void AddAlbum(Guid artistId, RequestAlbumDTO album)
    {
        Artist artist = _artistRepository.GetById(artistId.ToString());
        artist.CreateAlbum(album.Name, album.ImageUrl);
        _artistRepository.Update(artist);
    }
}
