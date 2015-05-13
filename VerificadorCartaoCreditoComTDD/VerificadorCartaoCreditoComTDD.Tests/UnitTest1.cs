using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VerificadorCartaoCreditoComTDD.Models;
using VerificadorCartaoCreditoComTDD.Controllers;

namespace VerificadorCartaoCreditoComTDD.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        /*
        VISA: 4111111111111111 (válido)
        VISA: 4111111111111 (inválido)
        VISA: 4012888888881881 (válido)
        AMEX: 378282246310005 (válido)
        Descubra: 6011111111111117 (válido)
        MasterCard: 5105105105105100 (válido)
        MasterCard: 5105105105105106 (inválido)
        Desconhecido: 9111111111111111 (inválido)
        */

        [TestMethod]
        public void deveriaRetornarCartaoVISAValido()
        {
            //VISA: 4111111111111111 (válido)
            String numCartao = "4111111111111111";
            CartaoCredito cartaoCredito = new CartaoCredito();
            cartaoCredito.NumeroCartaoCredito = numCartao;

            // Assert
            ValidarCartaoController validarCartaoCredito = new ValidarCartaoController();
            string strRetorno = validarCartaoCredito.validarCartao(cartaoCredito);
            Assert.AreEqual("VISA: 4111111111111111 (válido)", strRetorno);

        }

        [TestMethod]
        public void deveriaRetornarCartaoVISAInvalido()
        {
            //VISA: 4111111111111 (inválido)
            String numCartao = "4111111111111";
            CartaoCredito cartaoCredito = new CartaoCredito();
            cartaoCredito.NumeroCartaoCredito = numCartao;

            // Assert
            ValidarCartaoController validarCartaoCredito = new ValidarCartaoController();
            string strRetorno = validarCartaoCredito.validarCartao(cartaoCredito);
            Assert.AreEqual("VISA: 4111111111111 (inválido)", strRetorno);

        }


        [TestMethod]
        public void deveriaRetornarCartaoVISA2Valido()
        {
            //VISA: 4012888888881881 (válido)
            String numCartao = "4012888888881881";
            CartaoCredito cartaoCredito = new CartaoCredito();
            cartaoCredito.NumeroCartaoCredito = numCartao;

            // Assert
            ValidarCartaoController validarCartaoCredito = new ValidarCartaoController();
            string strRetorno = validarCartaoCredito.validarCartao(cartaoCredito);
            Assert.AreEqual("VISA: 4012888888881881 (válido)", strRetorno);

        }

        [TestMethod]
        public void deveriaRetornarCartaoAMEXValido()
        {
            //AMEX: 378282246310005 (válido)
            String numCartao = "378282246310005";
            CartaoCredito cartaoCredito = new CartaoCredito();
            cartaoCredito.NumeroCartaoCredito = numCartao;

            // Assert
            ValidarCartaoController validarCartaoCredito = new ValidarCartaoController();
            string strRetorno = validarCartaoCredito.validarCartao(cartaoCredito);
            Assert.AreEqual("AMEX: 378282246310005 (válido)", strRetorno);

        }

        [TestMethod]
        public void deveriaRetornarCartaoDiscoverValido()
        {
            //Discover: 6011111111111117 (válido)
            String numCartao = "6011111111111117";
            CartaoCredito cartaoCredito = new CartaoCredito();
            cartaoCredito.NumeroCartaoCredito = numCartao;

            // Assert
            ValidarCartaoController validarCartaoCredito = new ValidarCartaoController();
            string strRetorno = validarCartaoCredito.validarCartao(cartaoCredito);
            Assert.AreEqual("Discover: 6011111111111117 (válido)", strRetorno);

        }

        [TestMethod]
        public void deveriaRetornarCartaoMasterCardValido()
        {
            //MasterCard: 5105105105105100 (válido)
            String numCartao = "5105105105105100";
            CartaoCredito cartaoCredito = new CartaoCredito();
            cartaoCredito.NumeroCartaoCredito = numCartao;

            // Assert
            ValidarCartaoController validarCartaoCredito = new ValidarCartaoController();
            string strRetorno = validarCartaoCredito.validarCartao(cartaoCredito);
            Assert.AreEqual("MasterCard: 5105105105105100 (válido)", strRetorno);

        }

        [TestMethod]
        public void deveriaRetornarCartaoMasterCardInvalido()
        {
            //MasterCard: 5105105105105106 (inválido)
            String numCartao = "5105105105105106";
            CartaoCredito cartaoCredito = new CartaoCredito();
            cartaoCredito.NumeroCartaoCredito = numCartao;

            // Assert
            ValidarCartaoController validarCartaoCredito = new ValidarCartaoController();
            string strRetorno = validarCartaoCredito.validarCartao(cartaoCredito);
            Assert.AreEqual("MasterCard: 5105105105105106 (inválido)", strRetorno);

        }

        [TestMethod]
        public void deveriaRetornarCartaoDesconhecidoInvalido()
        {
            //Desconhecido: 9111111111111111 (inválido)
            String numCartao = "9111111111111111";
            CartaoCredito cartaoCredito = new CartaoCredito();
            cartaoCredito.NumeroCartaoCredito = numCartao;

            // Assert
            ValidarCartaoController validarCartaoCredito = new ValidarCartaoController();
            string strRetorno = validarCartaoCredito.validarCartao(cartaoCredito);
            Assert.AreEqual("Desconhecido: 9111111111111111 (inválido)", strRetorno);

        }

    }
}