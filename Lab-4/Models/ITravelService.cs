using Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_nr3.Models
{
    public interface ITravelService
    {
        int Add(Travel travel);
        void Update(Travel travel);
        void Delete(int id);
        Travel? FindById(int id);
        List<Travel> GetAll();
        List<OrganizationEntity> FindAllOrganization();
        PagingList<Travel> FindPage(int page, int size);
        

    }
}
