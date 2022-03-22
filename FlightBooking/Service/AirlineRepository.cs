using FlightBooking.Interface;
using FlightBooking.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBooking.Service
{
    public class AirlineRepository : IAirlineRepository
    {
        private FlightDbContext _context;
        private IWebHostEnvironment _hostingEnvironment;

        public AirlineRepository(FlightDbContext _context, IWebHostEnvironment _hostingEnvironment)
        {
            this._context = _context;
            this._hostingEnvironment = _hostingEnvironment;
        }
        public Airline GetAirlineById(Guid id)
        {
            return _context.Airlines.FirstOrDefault(x => x.AirlineId == id);

        }

        public List<Airline> GetAirlineList()
        {
            return _context.Airlines.ToList();
        }

        public Airline SaveAirline(Airline model)
        {
            if (model.image.Length > 0)
            {
                string uploads = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads");
                if (!Directory.Exists(uploads))
                {
                    Directory.CreateDirectory(uploads);
                }
                string fileName = Guid.NewGuid() + model.image.FileName;
                string filePath = Path.Combine(uploads, fileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.image.CopyToAsync(fileStream);
                }
                model.Logo += uploads + fileName;
            }
            _context.Airlines.Add(model);
            _context.SaveChanges();
            return model;
        }
    }
}
