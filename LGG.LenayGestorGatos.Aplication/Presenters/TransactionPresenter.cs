using LGG.LenayGestorGatos.Domain.Aggregates.Transactions;
using LGG.LenayGestorGatos.Domain.DTOs.Transaction;

/// Developer : Israel Curiel
/// Creation Date : 25/10/2024
/// Creation Description:Clase
/// Update Date : --
/// Update Description : --
///CopyRight: Lenay gestor de gastos
namespace LGG.LenayGestorGatos.Aplication.Presenters
{
    public class TransactionPresenter : ITransactionPresenter
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IMapper _mapper;
        public TransactionPresenter(IUnitRepository unitRepository, IMapper mapper)
        {
            _unitRepository = unitRepository;
            _mapper = mapper;
        }

        public async Task<RespuestaDB> AddGasto(TransactionAggregate aggregate, string token)
        {
            var respuesta = await _unitRepository.fireAuthInfraestructure.ValidateAuth(token);
            if (respuesta.NumError != 0)
            {
                return respuesta;
            }
            aggregate.IdUsuario = respuesta.Resultado;
            return await _unitRepository.transactionInfraestructure.AddGasto(aggregate);
        }

        public async Task<RespuestaDB> AddIngreso(TransactionAggregate aggregate, string token)
        {
            var respuesta = await _unitRepository.fireAuthInfraestructure.ValidateAuth(token);
            if (respuesta.NumError != 0)
            {
                return respuesta;
            }
            aggregate.IdUsuario = respuesta.Resultado;
            return await _unitRepository.transactionInfraestructure.AddIngreso(aggregate);
        }

        public async Task<RespuestaDB> AddTransferencia(TransferAggregate aggregate, string token)
        {
            var respuesta = await _unitRepository.fireAuthInfraestructure.ValidateAuth(token);
            if (respuesta.NumError != 0)
            {
                return respuesta;
            }
            aggregate.Gasto.IdUsuario = respuesta.Resultado;
            aggregate.Ingreso.IdUsuario = respuesta.Resultado;
            var response = await _unitRepository.transactionInfraestructure.AddGasto(aggregate.Gasto);
            if(response.NumError != 0)
            {
                return response;
            }
            return await _unitRepository.transactionInfraestructure.AddIngreso(aggregate.Ingreso);
        }

        public async Task<object> GetTransaccionesByIdUsuario(string token)
        {
            var respuesta = await _unitRepository.fireAuthInfraestructure.ValidateAuth(token);
            if (respuesta.NumError != 0)
            {
                return respuesta;
            }
            var IdUsuario = respuesta.Resultado;
            var gastoObject = await _unitRepository.transactionInfraestructure.GetRegistrosGastosByIdUsuario(IdUsuario);
            var ingresoObject = await _unitRepository.transactionInfraestructure.GetRegistrosIngresosByIdUsuario(IdUsuario);
            var listGasto = gastoObject as List<GastoDto>;
            var listIngreso = ingresoObject as List<IngresoDto>;
            if(listGasto == null || listIngreso == null)
            {
                return ingresoObject;
            }

            var listaTransaccion = new List<TransaccionDto>();

            listaTransaccion.AddRange(listGasto.Select(g => new TransaccionDto
            {
                Id = g.Id,
                Descripcion = g.DescripcionDelGasto,
                Fecha = g.Fecha,
                CategoriaIcono = g.CategoriaIcono,
                CategoriaColor = g.CategoriaColor,
                CategoriaNombre = g.CategoriaNombre,
                Dinero = g.Dinero,
                TipoTransaccion = "-" 
            }));

            listaTransaccion.AddRange(listIngreso.Select(i => new TransaccionDto
            {
                Id = i.Id,
                Descripcion = i.Descripcion,
                Fecha = i.Fecha,
                CategoriaIcono = i.CategoriaIcono,
                CategoriaColor = i.CategoriaColor,
                CategoriaNombre = i.CategoriaNombre,
                Dinero = i.Dinero,
                TipoTransaccion = "+" 
            }));

            listaTransaccion = listaTransaccion.OrderByDescending(t => t.Fecha).ToList();

            return listaTransaccion;

        }

        public async Task<object> GetTransaccionesByIdWallet(IdWalletAggregate aggregate, string token)
        {
            var respuesta = await _unitRepository.fireAuthInfraestructure.ValidateAuth(token);
            if (respuesta.NumError != 0)
            {
                return respuesta;
            }
            var gastoObject = await _unitRepository.transactionInfraestructure.GetRegistrosGastosByIdWallet(aggregate);
            var ingresoObject = await _unitRepository.transactionInfraestructure.GetRegistrosIngresosByIdWallet(aggregate);
            var listGasto = gastoObject as List<GastoDto>;
            var listIngreso = ingresoObject as List<IngresoDto>;
            if (listGasto == null || listIngreso == null)
            {
                return ingresoObject;
            }

            var listaTransaccion = new List<TransaccionDto>();

            listaTransaccion.AddRange(listGasto.Select(g => new TransaccionDto
            {
                Id = g.Id,
                Descripcion = g.DescripcionDelGasto,
                Fecha = g.Fecha,
                CategoriaIcono = g.CategoriaIcono,
                CategoriaColor = g.CategoriaColor,
                CategoriaNombre = g.CategoriaNombre,
                Dinero = g.Dinero,
                TipoTransaccion = "-"
            }));

            listaTransaccion.AddRange(listIngreso.Select(i => new TransaccionDto
            {
                Id = i.Id,
                Descripcion = i.Descripcion,
                Fecha = i.Fecha,
                CategoriaIcono = i.CategoriaIcono,
                CategoriaColor = i.CategoriaColor,
                CategoriaNombre = i.CategoriaNombre,
                Dinero = i.Dinero,
                TipoTransaccion = "+"
            }));

            listaTransaccion = listaTransaccion.OrderByDescending(t => t.Fecha).ToList();

            return listaTransaccion;
        }

        public async Task<object> GetCategorias(string token)
        {
            var respuesta = await _unitRepository.fireAuthInfraestructure.ValidateAuth(token);
            if (respuesta.NumError != 0)
            {
                return respuesta;
            }
            return await _unitRepository.transactionInfraestructure.GetCategorias();
        }
    }
}
