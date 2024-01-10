using JordanInsider.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JordanInsider.Core.Repository
{
    public interface ITouristSiteRepository
    {
        List<Touristsite> GetAllTouristSites();
        Touristsite GetTouristSiteById(decimal id);
        void CreateTouristSite(Touristsite touristSiteData);
        void UpdateTouristSite(Touristsite touristSiteData);
        void DeleteTouristSite(decimal id);
        public void AcceptTouristSite(decimal id);
        public List<Touristsite> SearchTouristSiteByName(string name);

    }
}
