using JordanInsider.Core.Models;
using System.Collections.Generic;

namespace JordanInsider.Core.Repository
{
    public interface IHistoryRepository
    {
        List<History> GetHistoryByUserId(int userId);
        History GetHistoryById(int historyId);
        void CreateHistory(History historyData);
        void UpdateHistory(History historyData);
        void DeleteHistory(int historyId);
    }
}
