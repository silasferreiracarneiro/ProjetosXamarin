using App01_ConsultarCEP.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App01_ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Botao.Clicked += BuscarCep;
        }

        private void BuscarCep(object sender, EventArgs args)
        {
            var cep = Cep.Text.Trim();

            if (isValid(cep))
            {
                try {
                    var endereco = ViaCepServico.BuscarEnderecoViapCep(cep);
                    if (endereco == null)
                    {
                        DisplayAlert("ERRO", "Cep não encontrado !", "Ok");
                        return;
                    }

                    Resultado.Text = string.Format("Endereço: {2} de {3} {0}, {1}", endereco.Localidade, endereco.Uf, endereco.Logradouro, endereco.Bairro);
                }
                catch (Exception e)
                {
                    DisplayAlert("ERRO CRÍTICO", e.Message, "Ok");
                }
            }
            else
            {
                DisplayAlert("Erro", "Cep inválido !", "Ok");
            }
        }

        private bool isValid(string cep)
        {
            if(cep.Length != 8)
                return false;
            if (int.TryParse(cep, out int novoCep))
                return false;
            return true;
        }
    }
}
