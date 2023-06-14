using SW.DataAccess;
using SW.Domain.CustomExceptions;
using SW.Domain.DTOs;
using System;

namespace SW.Domain.ServicesImplementations
{
    public class ServicesRebels : IServicesRebels
    {
        private readonly IRepositoryRebels _rebelsRepository;

        public ServicesRebels(IRepositoryRebels repository)
        {
            _rebelsRepository = repository;
        }

        public RebelDTO AddRebel(RebelDTO rebel)
        {
            try
            {
                Rebel insertedRebel = _rebelsRepository.Create(rebel.MappingToDomainEntity());
                if (insertedRebel is null)
                {
                    throw new SavingToFileException("No record was saved");
                }
                else
                {
                    return rebel;
                }
            }
            catch (Exception ex)
            {
                throw new SavingToFileException(ex.Message);
            }
        }

    }
}
