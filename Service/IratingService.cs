using Entity;

namespace Service
{
    public interface IratingService
    {
        Task<Rating> addRating(Rating rating);
    }
}