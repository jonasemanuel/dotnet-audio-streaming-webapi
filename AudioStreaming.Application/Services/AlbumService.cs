using AudioStreaming.Admin.Infrastructure;
using AudioStreaming.Domain;

namespace AudioStreaming.Application;

public class AlbumService
{
    private readonly AlbumRepository _albumRepository;
    private readonly ArtistRepository _artistRepository;

    public AlbumService(AlbumRepository albumRepository, ArtistRepository artistRepository)
    {
        _albumRepository = albumRepository;
        _artistRepository = artistRepository;
    }

    public List<ResponseAlbumDTO> GetAll()
    {
        var albums = _albumRepository.GetAll();
        return albums.Select(album => new ResponseAlbumDTO
        {
            Id = album.Id.ToString(),
            Name = album.Name,
            Artist = album.Owner.Name
        }).ToList();
    }

    public void Create(RequestAlbumDTO dto)
    {
        var artist = _artistRepository.GetById(dto.ArtistId);
        if (artist == null)
        {
            throw new Exception("Artist not found");
        }

        var album = new Album(dto.Name, artist, dto.ImageUrl);
        _albumRepository.Add(album);
    }
}