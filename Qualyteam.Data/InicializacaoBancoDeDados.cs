using Qualyteam.Data.Contexts;
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
            InicializarDadosDB(context);
        }

        private static void InicializarDadosDB(in QualyTeamContext context)
        {
            if (context.IndicadorMensal.Any()) return;

            var indicadores = new List<IndicadorMensal>
            {
                new IndicadorMensal(1, "IndicadorMensal_1", DateTime.Now.AddMonths(1)),
                new IndicadorMensal(2, "IndicadorMensal_2", DateTime.Now.AddMonths(2)),
                new IndicadorMensal(3, "IndicadorMensal_3", DateTime.Now.AddMonths(3)),
                new IndicadorMensal(4, "IndicadorMensal_4", DateTime.Now.AddMonths(4)),
                new IndicadorMensal(5, "IndicadorMensal_5", DateTime.Now.AddMonths(5))
            };

            var coletas = new List<Coleta>
            {
                new Coleta(1, 1.5m, indicadores.Where(x=> x.Id == 5).First()),
                new Coleta(2, 2.4m, indicadores.Where(x=> x.Id == 4).First()),
                new Coleta(3, 3.3m, indicadores.Where(x=> x.Id == 3).First()),
                new Coleta(4, 4.2m, indicadores.Where(x=> x.Id == 2).First()),
                new Coleta(5, 5.1m, indicadores.Where(x=> x.Id == 1).First())
            };

            context.IndicadorMensal.AddRange(indicadores);
            context.Coletas.AddRange(coletas);

            context.SaveChanges();
        }
    }
}
