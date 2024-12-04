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
        // void DeleteTransfer(int id);
    }

    public class TransferService : ITransferService
    {
        private readonly List<Transfer> _transfers = new();
        public IEnumerable<Transfer> GetAllTransfers()
        {
            return _transfers;
        }

        public void AddTransfer(Transfer transfer)
        {
            _transfers.Add(transfer);
        }

        public Transfer? GetTransferById(int id)
        {
            return _transfers.FirstOrDefault(t => t.Id == id);
        }

        public void UpdateTransfer(Transfer transfer)
        {
            var existingTransfer = _transfers.FirstOrDefault(t => t.Id == transfer.Id);
            if (existingTransfer == null)
            {
                return;
            }

            existingTransfer.Reference = transfer.Reference;
            existingTransfer.TransferFrom = transfer.TransferFrom;
            existingTransfer.TransferTo = transfer.TransferTo;
            existingTransfer.TransferStatus = transfer.TransferStatus;
            //Items
        }
    }
}
