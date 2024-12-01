using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Backend.Features.Transfers
{
    public interface ITransferService
    {
        IEnumerable<Transfer> GetAllTransfers();
        Transfer? GetTransferById(int id);
        void AddTransfer(Transfer transfer);
        void UpdateTransfer(Transfer transfer);
        void DeleteTransfer(int id);
    }

    public class TransferService : ITransferService
    {

    }
}
