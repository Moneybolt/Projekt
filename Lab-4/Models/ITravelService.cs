namespace Laboratorium_nr3.Models
{
    public interface ITravelService
    {
        int Add(Travel travel);
        void Update(Travel travel);
        void Delete(int id);
        Travel? FindById(int id);
        List<Travel> GetAll();
    }
}
