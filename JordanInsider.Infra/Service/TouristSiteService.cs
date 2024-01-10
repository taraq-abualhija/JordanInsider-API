using JordanInsider.Core.Models;
using JordanInsider.Core.Repository;
using JordanInsider.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JordanInsider.Infra.Service
{
    public class TouristSiteService : ITouristSiteService
    {
        private readonly ITouristSiteRepository _touristSiteRepository;

        public TouristSiteService(ITouristSiteRepository touristSiteRepository)
        {
            _touristSiteRepository = touristSiteRepository;
        }

        public List<Touristsite> GetAllTouristSites()
        {
            return _touristSiteRepository.GetAllTouristSites();
        }

        public Touristsite GetTouristSiteById(decimal id)
        {
            return _touristSiteRepository.GetTouristSiteById(id);
        }

        public void CreateTouristSite(Touristsite touristSiteData)
        {
            _touristSiteRepository.CreateTouristSite(touristSiteData);
        }

        public void UpdateTouristSite(Touristsite touristSiteData)
        {
            _touristSiteRepository.UpdateTouristSite(touristSiteData);
        }

        public void DeleteTouristSite(decimal id)
        {
            _touristSiteRepository.DeleteTouristSite(id);
        }
        public void AcceptTouristSite(decimal id)
        {
            _touristSiteRepository.AcceptTouristSite(id);
        }
        public List<Touristsite> SearchTouristSiteByName(string name)
        {

           return _touristSiteRepository.SearchTouristSiteByName (name);

        }

    }
}
