/// Developer : Israel Curiel
/// Creation Date : 25/10/2024
/// Creation Description:Clase
/// Update Date : 03/11/2024
/// Update Description : Datos Extras agregados(envio de fecha actual y devolucion de datos de la billetera) 
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
            var response = await _unitRepository.transactionInfraestructure.AddGasto(aggregate);

            if (response.NumError == 0)
            {
                var idDevice = await _unitRepository.usuarioInfrastructure.GetUserDeviceId(respuesta.Resultado);
                var notification = await _unitRepository.fireAuthInfraestructure.SendNotification(idDevice, "Gasto", aggregate.Dinero.ToString(), aggregate.Fecha);
                if (notification != null)
                {
                    notification.idUsuario = respuesta.Resultado;
                    await _unitRepository.notificationInfrastructure.AddNotification(notification);
                }
            }
            return response;
        }

        public async Task<RespuestaDB> AddIngreso(TransactionAggregate aggregate, string token)
        {
            var respuesta = await _unitRepository.fireAuthInfraestructure.ValidateAuth(token);
            if (respuesta.NumError != 0)
            {
                return respuesta;
            }
            aggregate.IdUsuario = respuesta.Resultado;
            var response = await _unitRepository.transactionInfraestructure.AddIngreso(aggregate);

            if (response.NumError == 0)
            {
                var idDevice = await _unitRepository.usuarioInfrastructure.GetUserDeviceId(respuesta.Resultado);
                var notification = await _unitRepository.fireAuthInfraestructure.SendNotification(idDevice, "Ingreso", aggregate.Dinero.ToString(), aggregate.Fecha);
                if (notification != null)
                {
                    notification.idUsuario = respuesta.Resultado;
                    await _unitRepository.notificationInfrastructure.AddNotification(notification);
                }
            }
            return response;
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
            var respons = await _unitRepository.transactionInfraestructure.AddIngreso(aggregate.Ingreso);
            if (respons.NumError == 0)
            {
                var idDevice = await _unitRepository.usuarioInfrastructure.GetUserDeviceId(respuesta.Resultado);
                var notification = await _unitRepository.fireAuthInfraestructure.SendNotification(idDevice, "Transferencia", aggregate.Ingreso.Dinero.ToString(), aggregate.Ingreso.Fecha);
                if (notification != null)
                {
                    notification.idUsuario = respuesta.Resultado;
                    await _unitRepository.notificationInfrastructure.AddNotification(notification);
                }
            }
            return respons;
        }

        public async Task<object> GetTransaccionesByIdUsuario(string token)
        {
            var respuesta = await _unitRepository.fireAuthInfraestructure.ValidateAuth(token);
            if (respuesta.NumError != 0)
            {
                return respuesta;
            }
            var IdUsuario = respuesta.Resultado;
            TimeZoneInfo cdmxTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
            DateTime cdmxDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, cdmxTimeZone);
            var gastoObject = await _unitRepository.transactionInfraestructure.GetRegistrosGastosByIdUsuario(IdUsuario, cdmxDateTime);
            var ingresoObject = await _unitRepository.transactionInfraestructure.GetRegistrosIngresosByIdUsuario(IdUsuario, cdmxDateTime);
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
                BilleteraSaldo = g.BilleteraSaldo,
                BilleteraNombre = g.BilleteraNombre,
                BilleteraColor = g.BilleteraColor,
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
                BilleteraSaldo = i.BilleteraSaldo,
                BilleteraNombre = i.BilleteraNombre,
                BilleteraColor = i.BilleteraColor,
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
            TimeZoneInfo cdmxTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
            DateTime cdmxDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, cdmxTimeZone);
            var gastoObject = await _unitRepository.transactionInfraestructure.GetRegistrosGastosByIdWallet(aggregate, cdmxDateTime);
            var ingresoObject = await _unitRepository.transactionInfraestructure.GetRegistrosIngresosByIdWallet(aggregate, cdmxDateTime);
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
                BilleteraSaldo = g.BilleteraSaldo,
                BilleteraNombre = g.BilleteraNombre,
                BilleteraColor = g.BilleteraColor,
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
                BilleteraSaldo = i.BilleteraSaldo,
                BilleteraNombre = i.BilleteraNombre,
                BilleteraColor = i.BilleteraColor,
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
