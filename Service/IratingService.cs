using Entity;

namespace Service
{
    public interface IratingService
    {
        Task addRating(Rating rating);
    }
}