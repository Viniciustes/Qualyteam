﻿using Qualyteam.Data.Contexts;
using Qualyteam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Qualyteam.Data
{
    /// <summary>
    /// Classe que insere dados iniciais no banco de dados que está em memoria
    /// </summary>
    public class InicializacaoBancoDeDados
    {
        public static void Inicializar(in QualyTeamContext context)
        {
            InicializarIndicadorMensal(context);
        }

        private static void InicializarIndicadorMensal(in QualyTeamContext context)
        {
            if (context.IndicadorMensal.Any()) return;

            var indicadores = new List<IndicadorMensal>
            {
                new IndicadorMensal(1, "IndicadorMensal_1", DateTime.Now.AddMonths(1)),
                new IndicadorMensal(2, "IndicadorMensal_2", DateTime.Now.AddMonths(2)),
                new IndicadorMensal(3, "IndicadorMensal_3", DateTime.Now.AddMonths(3)),
                new IndicadorMensal(4, "IndicadorMensal_4", DateTime.Now.AddMonths(4))
            };

            context.IndicadorMensal.AddRange(indicadores);

            context.SaveChanges();
        }
    }
}
