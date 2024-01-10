using JordanInsider.Core.Models;
using JordanInsider.Core.Repository;
using System;
using System.Collections.Generic;

namespace JordanInsider.Core.Services
{
    public class HistoryService:IHistoryService
    {
        private readonly IHistoryRepository historyRepository;

        public HistoryService(IHistoryRepository historyRepository)
        {
            this.historyRepository = historyRepository;
        }

        public List<History> GetHistoryByUserId(int userId)
        {
            try
            {
                return historyRepository.GetHistoryByUserId(userId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public History GetHistoryById(int historyId)
        {
            try
            {
                return historyRepository.GetHistoryById(historyId);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void CreateHistory(History historyData)
        {
            try
            {
                historyRepository.CreateHistory(historyData);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UpdateHistory(History historyData)
        {
            try
            {
                historyRepository.UpdateHistory(historyData);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void DeleteHistory(int historyId)
        {
            try
            {
                historyRepository.DeleteHistory(historyId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
