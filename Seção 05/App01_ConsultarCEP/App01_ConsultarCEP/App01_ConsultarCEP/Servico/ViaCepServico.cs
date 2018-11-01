using App01_ConsultarCEP.Servico.Modelo;
using Newtonsoft.Json;
using System.Net;

namespace App01_ConsultarCEP.Servico
{
    public class ViaCepServico
    {
        public static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViapCep(string cep)
        {
            string newUrl = string.Format(EnderecoURL, cep);
            var wc = new WebClient();
            string downlaod = wc.DownloadString(newUrl);
            return JsonConvert.DeserializeObject<Endereco>(downlaod) ?? null;
        }
    }
}
