﻿namespace LGG.LenayGestorGatos.Aplication.Interfaces.Controllers;
public interface IApiController
{
    IPersonaPresenter PersonaPresenter { get; }
    IUsuarioPresenter usuarioPresenter { get; }
    IFireAuthPresenter fireAuthPresenter { get; }
    IWalletPresenter walletPresenter { get; }
    ITransactionPresenter transactionPresenter { get; }
    IReportePresenter reportePresenter { get; }
    INotificationPresenter notificationPresenter { get; }
}
