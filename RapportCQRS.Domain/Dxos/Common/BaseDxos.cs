using AutoMapper;

namespace RapportCQRS.Domain.Dxos.Common
{
    public class BaseDxos: IBaseDxos
    {
        protected IMapper _mapper;

        public IMapper GetMapper()
        {
            return _mapper;
        }
    }

}