using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using PetProject2026.Context;
using PetProject2026.DTOs.DTOHotel;
using PetProject2026.DTOs.DTORoom;
using PetProject2026.Models;
using PetProject2026.Services.Interfaces;
using System.Net.WebSockets;

namespace PetProject2026.Services.Implementations
{
    public class ImplsHotelService : IHotelService
    {
        private readonly BookingContext bookingContext;
        private readonly IDistributedCache _cache;
        public ImplsHotelService( BookingContext _bookingcontext, IDistributedCache cache)
        {
            bookingContext = _bookingcontext;
            _cache = cache;
        }
        public async Task<List<HotelDTO>> getAllHotel()
        {
            var cacheKey = "hotels_all";
            //1.Check cache
            var cacheData = await _cache.GetStringAsync(cacheKey);
            if (cacheData != null)
            {
                Console.WriteLine("Lay tu cache ");
                return JsonConvert.DeserializeObject<List<HotelDTO>>(cacheData);
            }
            //2. Neu chua co cache -> query DB
            Console.WriteLine("Lay tu db");

            var hotel = await bookingContext.hotel.Select(h => new HotelDTO
            {
                hName = h.hotelName,
                startLv = h.starLevel,
                address = h.address,
                description = h.desciption
            }).ToListAsync();

            //3. luu vao cache
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            };

            await _cache.SetStringAsync(
                cacheKey,
                JsonConvert.SerializeObject(hotel),
                options
                );
            
            return hotel;
        }

        public async Task<HotelDTO> getHotelById(int id)
        {
            var hotel = await bookingContext.hotel.FindAsync(id);
            if (hotel == null) { throw new Exception("Cannot find Hotel"); }
            return new HotelDTO
            {
                hName = hotel.hotelName,
                startLv = hotel.starLevel,
                address = hotel.address,
                description = hotel.desciption
            };

        }
        public async Task<HotelDTO> createHotel(CreateHotelDTO request)
        {
            var hotel = new Hotel
            {
                hotelName = request.hName,
                starLevel = request.startLv,
                address = request.address,
                desciption = request.description
            };
             await bookingContext.hotel.AddAsync(hotel);
            await bookingContext.SaveChangesAsync();
            return new HotelDTO
            {
                hName = hotel.hotelName,
                startLv = hotel.starLevel,
                address = hotel.address,
                description = hotel.desciption
            };
        }
        public async Task<UpdateHotelDTO> updateHotelById(int id, UpdateHotelDTO request)
        {
            var hotel = await bookingContext.hotel.FindAsync(id);
            if (hotel == null) { throw new Exception("hotel not found"); }
            hotel.hotelName = request.hName;
            hotel.starLevel = request.startLv;
            hotel.address = request.address;
            hotel.desciption = request.description;
            await bookingContext.SaveChangesAsync();
            return new UpdateHotelDTO
            {
                hName = hotel.hotelName,
                startLv = hotel.starLevel,
                address = hotel.address,
                description = hotel.desciption
            };

        }
        public async Task deleteHotelById(int id)
        {
            var hotel = await bookingContext.hotel.FindAsync(id);
            if (hotel == null) { throw new Exception("hotel not found"); }
            bookingContext.hotel.Remove(hotel);
            await bookingContext.SaveChangesAsync();
        }

        Task<Hotel> IHotelService.updateHotelById(int id, UpdateHotelDTO request)
        {
            throw new NotImplementedException();
        }
    }
}
