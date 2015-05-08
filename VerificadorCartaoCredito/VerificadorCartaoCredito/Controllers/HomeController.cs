using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VerificadorCartaoCredito.Models;

namespace VerificadorCartaoCredito.Controllers
{
    public class HomeController : Controller
    {
        public String StrBandeira = "";
        public String StrMensagem = "";

        public ActionResult Index()
        {
            ViewBag.Message = "";
            return View();
        }

        //
        // POST: /ValidarCartao
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "NumeroCartaoCredito")] CartaoCredito cartaoCredito)
        {
            //Validar Bandeira e Comprimento
            if (!isBandeiraComprimentoValido(cartaoCredito))
            {
                System.Diagnostics.Debug.WriteLine(StrMensagem);
                ViewBag.Message = StrBandeira + ": " + cartaoCredito.NumeroCartaoCredito + " (inválido)";
                return View();
            }

            //Validar pelo algoritimo Luhn
            if (!isValidoLuhn(cartaoCredito))
            {
                System.Diagnostics.Debug.WriteLine(StrMensagem);
                ViewBag.Message = StrBandeira + ": " + cartaoCredito.NumeroCartaoCredito + " (inválido)";
            }
            else
            {
                ViewBag.Message = StrBandeira + ": " + cartaoCredito.NumeroCartaoCredito + " (válido)";
            }


            return View();
        }


        public Boolean isBandeiraComprimentoValido(CartaoCredito cartaoCredito)
        {
            String StrNumCartao = "";

            if (cartaoCredito.NumeroCartaoCredito != null)
            {
                StrNumCartao = cartaoCredito.NumeroCartaoCredito;
            }
            else
            {
                StrBandeira = "Desconhecido";
                StrMensagem = "Número do cartão não preenchido";
                return false;
            }

            //Validar Bandeira e Comprimento
            //Tipo de Cartão  começa com    Número Comprimento
            //AMEX            34 ou 37      15
            //Discover        6011          16
            //MasterCard      51 - 55       16
            //Visa            4             13 ou 16

            if (StrNumCartao.StartsWith("6011"))
            {
                StrBandeira = "Discover";
                if (StrNumCartao.Length == 16)
                {
                    return true;
                }
                else
                {
                    StrMensagem = "Cartão Discover deve conter 16 dígitos";
                    return false;
                }
            }

            if (StrNumCartao.StartsWith("34") || StrNumCartao.StartsWith("37"))
            {
                StrBandeira = "AMEX";
                if (StrNumCartao.Length == 15)
                {
                    return true;
                }
                else
                {
                    StrMensagem = "Cartão AMEX deve conter 15 dígitos";
                    return false;
                }
            }
            if (StrNumCartao.StartsWith("51") || StrNumCartao.StartsWith("55"))
            {
                StrBandeira = "MasterCard";
                if (StrNumCartao.Length == 16)
                {
                    return true;
                }
                else
                {
                    StrMensagem = "Cartão MasterCard deve conter 16 dígitos";
                    return false;
                }
            }
            if (StrNumCartao.StartsWith("4"))
            {
                StrBandeira = "Visa";
                if ((StrNumCartao.Length == 13) || (StrNumCartao.Length == 16))
                {
                    return true;
                }
                else
                {
                    StrMensagem = "Cartão Visa deve conter 13 ou 16 dígitos";
                    return false;
                }
            }
            StrBandeira = "Desconhecido";
            StrMensagem = "Bandeira do cartão não identificada";
            return false;
        }

        public Boolean isValidoLuhn(CartaoCredito cartaoCredito)
        {
            String StrNumCartao = "";
            StrNumCartao = cartaoCredito.NumeroCartaoCredito;

            //Validar pelo algoritimo Luhn
            //Tome uma sequência de números inteiros positivos e a inverta.
            
            char[] ArrayCharNumCartao = StrNumCartao.ToCharArray().Reverse().ToArray();
            
            String StrNumCartaoInvertido = new string(ArrayCharNumCartao);
            System.Diagnostics.Debug.WriteLine(StrNumCartaoInvertido);

            //Começando pelo segundo número, dobre o valor de cada número de forma alternada ("24145... = "28185...).
            //Para dígitos maiores que 9 será necessário que some cada dígito("10", 1 + 0 = 1) ou subtraia por 9("10", 10 - 9 = 1).
            int soma = 0;
            for (int i=1; i < ArrayCharNumCartao.Length; i=i+2)
            {
                String StrNum = ArrayCharNumCartao.GetValue(i).ToString();
                int num = System.Convert.ToInt16(StrNum);
                num = num * 2;

                if (num > 9)
                {
                    num = num - 9;
                }

                soma = soma + num;

                //ArrayCharNumCartao.SetValue(System.Convert.ToChar(num), i);
            }

            /*
            StrNumCartaoInvertido = new string(ArrayCharNumCartao);
            System.Diagnostics.Debug.WriteLine(StrNumCartaoInvertido);

            //Some todos os números da sequência.
            int soma = 0;
            */
            for (int i = 0; i < ArrayCharNumCartao.Length; i=i+2)
            {
                String StrNum = ArrayCharNumCartao.GetValue(i).ToString();
                int num = System.Convert.ToInt16(StrNum);
                soma = soma + num;
            }

            System.Diagnostics.Debug.WriteLine("Soma: " + soma);

            //Se o total for múltiplo de 10, o número é válido.
            if (soma % 10 == 0)
            {
                StrMensagem = "Cartão válido";
                return true;
            } else
            {
                StrMensagem = "Cartão inválido";
                return false;
            }
            
        }
    }
}