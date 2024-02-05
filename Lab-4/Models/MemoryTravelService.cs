//namespace Laboratorium_nr3.Models
//{
//    public class MemoryTravelService : ITravelService
//    {
//        private readonly Dictionary<int, Travel> _travels =
//            new Dictionary<int, Travel>();
//        private int _id = 0;
//        public void Add(Travel travel)
//        {
//            travel.Id = _id++;
//            _travels[travel.Id] = travel;
//        }
//        public void Delete(int id)
//        {
//            _travels.Remove(id);
//        }
//        public Travel FindById(int id)
//        {
//            return _travels[id];
//        }
//        public void Update(Travel travel)
//        {
//            _travels[travel.Id] = travel;
//        }
//        public List<Travel> GetAll()
//        {
//            return _travels;
//        }
//    }
//}
