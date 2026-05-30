using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.Business.Concrete
{
    public class SubscriberManager : GenericManager<Subscriber>, ISubscriberService
    {
        private readonly ISubscriberRepository _subscriberRepository;
        public SubscriberManager(IRepository<Subscriber> _repository, ISubscriberRepository subscriberRepository) : base(_repository)
        {
            _subscriberRepository = subscriberRepository;
        }

        public async Task<Subscriber> TGetByEmailAsync(string email)
        {
            return await _subscriberRepository.GetByEmailAsync(email);
        }
    }
}
