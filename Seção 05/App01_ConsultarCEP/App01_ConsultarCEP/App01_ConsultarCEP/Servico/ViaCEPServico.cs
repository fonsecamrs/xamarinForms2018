using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using App01_ConsultarCEP.Servico.Modelo;

namespace App01_ConsultarCEP.Servico
{
    public class ViaCEPServico
    {
        private static string enderecoURL = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP (string cep)
        {
            string NovoEnderecoURL = string.Format(enderecoURL, cep);

            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(NovoEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);

            if (end.cep == null)
            {
                return null;
            }

            return end;
        }
    }
}
