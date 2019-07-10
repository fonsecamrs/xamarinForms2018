using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Servico;
using App01_ConsultarCEP.Servico.Modelo;

namespace App01_ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs args)
        {
            try
            {
                string cep = CEP.Text.Trim();

                if (isValidCEP(cep))
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                    if (end != null)
                    {
                        RESULTADO.Text = string.Format("Endereço: {0}, {1}, {2} ", end.localidade, end.uf, end.logradouro);
                    }
                    else
                    {
                        DisplayAlert("Atenção", "O endereço não encontrado para o CEP informado: " + cep, "OK");
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message.ToString(), "OK");
            }
        }

        private bool isValidCEP(string cep)
        {
            cep = cep.Replace("-", "");

            bool status = true;
            int NovoCEP = 0;

            if (cep.Length != 8)
            {
                DisplayAlert("Erro", "CEP Inválido!", "OK");
                status = false;
            }

            if (!int.TryParse(cep, out NovoCEP))
            {
                DisplayAlert("Erro", "CEP Inválido!", "OK");
                status = false;
            }

            return status;
        }
    }
}
