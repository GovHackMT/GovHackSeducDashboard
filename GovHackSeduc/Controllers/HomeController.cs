using GovHackSeduc.Entity;
using GovHackSeduc.Helper;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace GovHackSeduc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var url = "http://govhackseduc.azurewebsites.net/tables/Aluno?ZUMO-API-VERSION=2.0.0";
            var a = HttpRequestHelper.GetDataFromUrls<List<Aluno>>(url);

            var b = a;

            return View();
        }

        public string GetAlunos()
        {
            var url = "http://govhackseduc.azurewebsites.net/tables/Aluno?ZUMO-API-VERSION=2.0.0";
            var a = HttpRequestHelper.GetDataFromUrls<List<Aluno>>(url);
            return JsonConvert.SerializeObject(a);
        }

        public string GetFaltaPorMotivo()
        {
            var url = "http://govhackseduc.azurewebsites.net/tables/Aula?ZUMO-API-VERSION=2.0.0";
            var alunos = HttpRequestHelper.GetDataFromUrls<List<Aula>>(url);

            var source = new SourceBarChart();

            alunos = (from x in alunos where x.Ausente select x).ToList();

            var faltasPorMotivo = (from p in alunos group p by p.AusenteJustificativaTipo into grupoAluno
                                   select new FaltaPorMotivo {
                                       Justifictiva = grupoAluno.Key.Value,
                                       Quantidade = grupoAluno.Count(),
                                   }).ToList();

            var index = 0;
            var listaDeCores = HttpRequestHelper.GetSerieColor();

            foreach (var p in faltasPorMotivo)
            {
                source.XValues.Add(GetJustificativaDescription(p.Justifictiva));
                source.YValues.Add(p.Quantidade);
                source.BackGroundColor.Add(listaDeCores[index].BackgroundColor);
                source.BorderColor.Add(listaDeCores[index].BorderColor);

                index++;

                if (index == 5)
                    index = 0;
            }

            // just to test
            //source = seedFaltaPorMotivo();

            return JsonConvert.SerializeObject(source);
        }

        public string GetFaltaPorMateria()
        {
            var url = "http://govhackseduc.azurewebsites.net/tables/Aula?ZUMO-API-VERSION=2.0.0";
            var alunos = HttpRequestHelper.GetDataFromUrls<List<Aula>>(url);

            var source = new SourceBarChart();

            alunos = (from x in alunos where x.Ausente select x).ToList();

            var faltasPorMotivo = (from p in alunos
                                   group p by p.Nome into grupoAluno
                                   select new FaltaPorMateria
                                   {
                                       NomeMateria = grupoAluno.Key,
                                       Quantidade = grupoAluno.Count(),
                                   }).ToList();

            var index = 0;
            var listaDeCores = HttpRequestHelper.GetSerieColor();

            foreach (var p in faltasPorMotivo)
            {
                source.XValues.Add(p.NomeMateria);
                source.YValues.Add(p.Quantidade);
                source.BackGroundColor.Add(listaDeCores[index].BackgroundColor);
                source.BorderColor.Add(listaDeCores[index].BorderColor);

                index++;

                if (index == 5)
                    index = 0;
            }

            // just to test
            //source = seedFaltaPorMateria();

            return JsonConvert.SerializeObject(source);
        }

        public string GetFaltaPorEscola()
        {
            var url = "http://govhackseduc.azurewebsites.net/tables/Aula?ZUMO-API-VERSION=2.0.0";
            var alunos = HttpRequestHelper.GetDataFromUrls<List<Aula>>(url);

            var source = new SourceBarChart();

            alunos = (from x in alunos where x.Ausente select x).ToList();

            var faltasPorMotivo = (from p in alunos
                                   group p by p.Escola into grupoAluno
                                   select new FaltaPorEscola
                                   {
                                       NomeEscola = grupoAluno.Key,
                                       Quantidade = grupoAluno.Count(),
                                   }).ToList();

            var index = 0;
            var listaDeCores = HttpRequestHelper.GetSerieColor();

            foreach (var p in faltasPorMotivo)
            {
                source.XValues.Add(p.NomeEscola);
                source.YValues.Add(p.Quantidade);
                source.BackGroundColor.Add(listaDeCores[index].BackgroundColor);
                source.BorderColor.Add(listaDeCores[index].BorderColor);

                index++;

                if (index == 5)
                    index = 0;
            }

            // just to test
            //source = seedFaltaPorEscola();

            return JsonConvert.SerializeObject(source);
        }

        private SourceBarChart seedFaltaPorMotivo()
        {
            var a = new SourceBarChart();

            a.XValues.Add("Saude");
            a.XValues.Add("Transporte");
            a.XValues.Add("Familia");
            a.XValues.Add("Outros");

            a.YValues.Add(144);
            a.YValues.Add(380);
            a.YValues.Add(99);
            a.YValues.Add(329);

            var listaDeCores = HttpRequestHelper.GetSerieColor();

            a.BackGroundColor.Add(listaDeCores[0].BackgroundColor);
            a.BorderColor.Add(listaDeCores[0].BorderColor);

            a.BackGroundColor.Add(listaDeCores[1].BackgroundColor);
            a.BorderColor.Add(listaDeCores[1].BorderColor);

            a.BackGroundColor.Add(listaDeCores[2].BackgroundColor);
            a.BorderColor.Add(listaDeCores[2].BorderColor);

            a.BackGroundColor.Add(listaDeCores[3].BackgroundColor);
            a.BorderColor.Add(listaDeCores[3].BorderColor);

            return a;
        }

        private SourceBarChart seedFaltaPorMateria()
        {
            var a = new SourceBarChart();

            a.XValues.Add("História");
            a.XValues.Add("Portugues");
            a.XValues.Add("Geografia");
            a.XValues.Add("Matematica");
            a.XValues.Add("Física");
            a.XValues.Add("Quimica");

            a.YValues.Add(144);
            a.YValues.Add(380);
            a.YValues.Add(99);
            a.YValues.Add(329);
            a.YValues.Add(99);
            a.YValues.Add(329);

            var listaDeCores = HttpRequestHelper.GetSerieColor();

            a.BackGroundColor.Add(listaDeCores[0].BackgroundColor);
            a.BorderColor.Add(listaDeCores[0].BorderColor);

            a.BackGroundColor.Add(listaDeCores[1].BackgroundColor);
            a.BorderColor.Add(listaDeCores[1].BorderColor);

            a.BackGroundColor.Add(listaDeCores[2].BackgroundColor);
            a.BorderColor.Add(listaDeCores[2].BorderColor);

            a.BackGroundColor.Add(listaDeCores[3].BackgroundColor);
            a.BorderColor.Add(listaDeCores[3].BorderColor);

            a.BackGroundColor.Add(listaDeCores[4].BackgroundColor);
            a.BorderColor.Add(listaDeCores[4].BorderColor);

            a.BackGroundColor.Add(listaDeCores[5].BackgroundColor);
            a.BorderColor.Add(listaDeCores[5].BorderColor);

            return a;
        }

        private SourceBarChart seedFaltaPorEscola()
        {
            var a = new SourceBarChart();

            a.XValues.Add("Escola Estadual Liceu Cuiabano");
            a.XValues.Add("Escola Estadual Presidente Medices");
            a.XValues.Add("Escola Municipal Jose Magno");
            a.XValues.Add("Escola Municipal Alcebiades Calhao");
            a.XValues.Add("Escola Municipal Dom Jose do Despraiado");
            a.XValues.Add("Escola Municiapl Maria Glaucia Pinho");

            a.YValues.Add(543);
            a.YValues.Add(987);
            a.YValues.Add(212);
            a.YValues.Add(199);
            a.YValues.Add(118);
            a.YValues.Add(476);

            var listaDeCores = HttpRequestHelper.GetSerieColor();

            a.BackGroundColor.Add(listaDeCores[0].BackgroundColor);
            a.BorderColor.Add(listaDeCores[0].BorderColor);

            a.BackGroundColor.Add(listaDeCores[1].BackgroundColor);
            a.BorderColor.Add(listaDeCores[1].BorderColor);

            a.BackGroundColor.Add(listaDeCores[2].BackgroundColor);
            a.BorderColor.Add(listaDeCores[2].BorderColor);

            a.BackGroundColor.Add(listaDeCores[3].BackgroundColor);
            a.BorderColor.Add(listaDeCores[3].BorderColor);

            a.BackGroundColor.Add(listaDeCores[4].BackgroundColor);
            a.BorderColor.Add(listaDeCores[4].BorderColor);

            a.BackGroundColor.Add(listaDeCores[5].BackgroundColor);
            a.BorderColor.Add(listaDeCores[5].BorderColor);

            return a;
        }

        private string GetJustificativaDescription(AusenciaJustificativaTipo valor)
        {
            switch (valor)  
            {
                case AusenciaJustificativaTipo.Familiar:
                    return "Familiar";
                case AusenciaJustificativaTipo.Saude:
                    return "Saude"; ;
                case AusenciaJustificativaTipo.Transporte:
                    return "Transporte"; ;
                case AusenciaJustificativaTipo.Outros:
                    return "Outros"; ;
                default:
                    return "Não informado";
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}