﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGG.LenayGestorGatos.Domain.DTOs.Wallet
{
    public class WalletDto
    {
        [Key]
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public decimal Saldo { get; set; }
        public decimal TazaInteres { get; set; }
        public int IdTipoCuenta { get; set; }
        public DateTime FechaDePago { get; set; }
        public DateTime FechaCorte { get; set; }
        public string IdUsuario { get; set; }
        public string Color { get; set; }

    }
}
