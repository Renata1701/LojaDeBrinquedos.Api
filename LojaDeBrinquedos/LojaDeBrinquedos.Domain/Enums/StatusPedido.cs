using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDeBrinquedos.Domain.Enums;
public enum StatusPedido
{
    Pendente = 1,
    Pago = 2,
    Enviado = 3,
    Entregue = 4,
    Cancelado = 5
}
