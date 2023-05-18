using HotelBookingSystem.DAL.Contexts;
using HotelBookingSystem.DAL.Queries.HotelQ;
using HotelBookingSystem.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.DAL.Handlers.HotelHandler
{
    public class GetHotelByIDHandler : IRequestHandler<GetHotelByID, Hotel>
    {
        public GetHotelByIDHandler(HotelBookingContext context)
        {
            _Context = context;
        }

        public HotelBookingContext _Context { get; }

        public async Task<Hotel> Handle(GetHotelByID request, CancellationToken cancellationToken)
        {
            var Hotel2 = await _Context.Hotels
                .IgnoreAutoIncludes()
                .Select(x => new
                {
                    x.Name, x.Address, x.City,x.Id,
                    x.State,x.HotelRating,
                    endPoint = x.HotelPictures.Where(y=>y.HotelId == x.Id).Select(x=>x.ImageEndpoint).ToList(),
                }).ToListAsync();

            var Hotel = await _Context.Hotels
                .IgnoreAutoIncludes()
                .Where(H => H.Id == request.Id)
                .Select(x => new Hotel
                {
                    Address= x.Address,
                    City= x.City,   
                    Id= x.Id,
                    State=x.State,
                    Description= x.Description,
                    HotelRating= x.HotelRating,
                    Name= x.Name,
                    Pincode= x.Pincode,
                    Status=x.Status,
                    HotelRooms  = x.HotelRooms.Select(x=>new HotelRoom
                    {
                        Id= x.Id,
                        BedSize= x.BedSize,
                        Description= x.Description,
                        Rate= x.Rate,
                        RoomName= x.RoomName,
                        RoomType= x.RoomType,
                        RoomPictures = x.RoomPictures.Select(r=>new RoomPicture
                        {
                            ImageEndpoint= r.ImageEndpoint,
                        }).ToList(),
                    }).ToList(),
                    HotelAminities= x.HotelAminities.Select(a=>new HotelAminity
                    {
                        Aminity = a.Aminity,
                    }).ToList(),
                    HotelPictures= x.HotelPictures.Select(x=>new HotelPicture
                    {
                        ImageEndpoint= x.ImageEndpoint,
                    }).ToList(),
                }).FirstOrDefaultAsync();

            return Hotel ?? throw new Exception("Object not found");
        }
    }
}
