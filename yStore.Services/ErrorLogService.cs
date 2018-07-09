using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yStore.Data.Infrastructure;
using yStore.Data.Repositories;
using yStore.Model.Models;

namespace yStore.Services
{
    public interface IErrorLogService
    {
        ErrorLog Create(ErrorLog error);
        void Save();
    }
    public class ErrorLogService : IErrorLogService
    {
        IErrorLogRepository _errorLogRepository;
        IUnitOfWork _unitOfWork;
        public ErrorLogService(IErrorLogRepository errorLogRepository, IUnitOfWork unitOfWork)
        {
            this._errorLogRepository = errorLogRepository;
            this._unitOfWork = unitOfWork;
        }

        public ErrorLog Create(ErrorLog error)
        {
            return _errorLogRepository.Add(error);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
