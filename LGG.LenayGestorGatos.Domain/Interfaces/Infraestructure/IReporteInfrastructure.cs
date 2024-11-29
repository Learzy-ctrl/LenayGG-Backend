﻿/// Developer : Israel Curiel
/// Creation Date : 14/11/2024
/// Creation Description:Interface
/// Update Date : --/--/--
/// Update Description : ----
///CopyRight: Lenay gestor de gastos
namespace LGG.LenayGestorGatos.Domain.Interfaces.Infraestructure
{
    public interface IReporteInfrastructure
    {
        /// <summary>
        /// Consulta los gastos filtrados por un rango de fechas
        /// </summary>
        /// <returns></returns>
        Task<object> GetGastosByFilter(ConsultaGastosAggregate aggregate);
    }
}
