using System.Collections.Generic;
using MySurfboardsMVP.Models;

namespace MySurfboardsMVP.Services
{
    public interface ISurfboardDataService
    {
        List<Surfboard> GetAllSurfboards();
        int Post(Surfboard surfboard);
    }
}