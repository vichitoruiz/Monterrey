using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSEL.MONTERREY.Application.Utils;

namespace SSEL.MONTERREY.WPF.Helpers;

    public static class FoseCalculator
    {
        public static decimal Calcular(decimal consumo, decimal tarifa)
        {
            return consumo * tarifa;
        }
    }

