using AutoMapper;
using Ott.Models;
using Ott.Dto;
using ProfileEntity = Ott.Models.Profile;

namespace ott.Profiles{
public class MappingProfile : AutoMapper.Profile
{
    public MappingProfile()
    {
        // User
        CreateMap<RegisterRequestDTO, User>();
        CreateMap<User, RegisterResponseDTO>();

        // Movie
        CreateMap<Movie, MovieResponseDTO>();

        // Profile
        CreateMap<ProfileEntity, ProfileResponseDTO>();

        // Rating
        CreateMap<CreateRatingRequestDTO, Rating>();

        // Watchlist → Movie response
        CreateMap<Watchlist, WatchlistResponseDTO>()
            .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.Movie.MovieId))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Movie.Title))
            .ForMember(dest => dest.PosterUrl, opt => opt.MapFrom(src => src.Movie.PosterUrl));

        // Payment
        CreateMap<Payment, PaymentResponseDTO>();
    }
}}