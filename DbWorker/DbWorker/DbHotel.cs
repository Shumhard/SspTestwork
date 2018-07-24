using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DbWorker
{
    public static class DbHotel
    {
        public static Hotel GetHotel(Guid hotelGuid)
        {
            using (var context = new DbRepository.OpenSspContext())
            {
                var hotel = new Hotel();

                var dbHotel = context.Hotel.SingleOrDefault(x => x.Guid == hotelGuid);
                if(dbHotel == null)
                {
                    return null;
                }

                hotel.Guid = dbHotel.Guid;
                hotel.Name = dbHotel.Name;
                hotel.Address = dbHotel.Address;
                hotel.Buildings = new List<Building>();

                foreach(var dbBuilding in dbHotel.Housing)
                {
                    var building = new Building
                    {
                        Guid = dbBuilding.Guid,
                        Name = dbBuilding.Name,
                        SortNumber = (int)dbBuilding.SortNumber,
                        Rooms = new List<Room>()
                    };

                    foreach(var dbRoom in dbBuilding.Room)
                    {
                        var room = new Room
                        {
                            Guid = dbRoom.Guid,
                            Name = dbRoom.Name,
                            Status = (RoomStatus?)dbRoom.Status,
                            CostPerDay = dbRoom.CostPerDay,
                            CostService = dbRoom.CostService
                        };
                        building.Rooms.Add(room);
                    }

                    hotel.Buildings.Add(building);
                }

                return hotel;
            }
        }

        public static OperationResult AddBuilding(Guid hotelGuid, string name)
        {
            using (var context = new DbRepository.OpenSspContext())
            {
                var dbBuilding = context.Housing.FirstOrDefault(x => x.HotelGuid == hotelGuid && x.Name == name);
                if(dbBuilding != null)
                {
                    return OperationResult.DuplicateNameError;
                }

                //dbBuilding = new DbRepository.Housing();
                //{
                //    Guid = Guid.NewGuid(),
                //    Name = name,
                //    SortNumber = context.Building.Count(),
                //    HotelGuid = hotelGuid
                //};
                //context.Building.Add(dbBuilding);

                context.SaveChanges();

                return OperationResult.Success;
            }
        }
    }
}
