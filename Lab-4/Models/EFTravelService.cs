using Laboratorium_nr3.Models;
using System;
using System.Linq;

public class EFTravelService : ITravelService
{
    private AppDbContext _context;

    public EFTravelService(AppDbContext context)
    {
        _context = context;
    }

    public int Add(Travel travel)
    {
        var e = _context.Travel.Add(TravelMapper.ToEntity(travel));
        _context.SaveChanges();
        return e.Entity.Id;
    }

    public void Delete(int id)
    {
        TravelEntity? find = _context.Travel.Find(id);
        if (find != null)
        {
            _context.Travel.Remove(find);
        }
    }

    public List<Travel> GetAll()
    {
        return _context.Travel.Select(e => TravelMapper.FromEntity(e)).ToList(); 
    }

    public Travel? FindById(int id)
    {
        return TravelMapper.FromEntity(_context.Travel.Find(id));
    }

    public void Update(Travel travel)
    {
        _context.Travel.Update(TravelMapper.ToEntity(travel));
    }  
}