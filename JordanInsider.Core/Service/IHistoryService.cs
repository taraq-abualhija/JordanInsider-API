using JordanInsider.Core.Models;
using System.Collections.Generic;

namespace JordanInsider.Core.Services
{
    public interface IHistoryService
    {
        List<History> GetHistoryByUserId(int userId);
        History GetHistoryById(int historyId);
        void CreateHistory(History historyData);
        void UpdateHistory(History historyData);
        void DeleteHistory(int historyId);
    }
}
