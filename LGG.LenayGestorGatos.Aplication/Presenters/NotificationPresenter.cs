using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGG.LenayGestorGatos.Aplication.Presenters
{
    public class NotificationPresenter : INotificationPresenter
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IMapper _mapper;
        public NotificationPresenter(IUnitRepository unitRepository, IMapper mapper)
        {
            _unitRepository = unitRepository;
            _mapper = mapper;
        }
    }
}
