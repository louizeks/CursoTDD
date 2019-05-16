using CursoTDD.DominioTest._util;
using ExpectedObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CursoTDD.DominioTest.Cursos
{
    public class CursoTest
    {
        [Fact]
        public void DeveCriarCurso()
        {
            var cursoEsperado = new
            {
                Nome = "PD",
                CargaHoraria = (double)30,
                PublicoAlvo = PublicoAlvo.Empreendedor,
                Valor = (double)50
            };

            var curso = new Curso(cursoEsperado.Nome,
                cursoEsperado.CargaHoraria,
                cursoEsperado.PublicoAlvo,
                cursoEsperado.Valor);

            cursoEsperado.ToExpectedObject()
                .ShouldMatch(curso);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCursoTerNomeInvalido(string nomeInvalido)
        {
            var cursoEsperado = new
            {
                Nome = "PD",
                CargaHoraria = (double)30,
                PublicoAlvo = PublicoAlvo.Empreendedor,
                Valor = (double)50
            };

            Assert.Throws<ArgumentException>(() =>
                new Curso(nomeInvalido, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor))
                .ComMensagem("Nome inválido");
        }

        [Theory]
        [InlineData(-10)]
        [InlineData(-2)]
        [InlineData(-1)]
        public void NaoDeveTerUmaCargaHorariaMenorQue1(double cargaHorariaInvalida)
        {
            var cursoEsperado = new
            {
                Nome = "PD",
                CargaHoraria = (double)30,
                PublicoAlvo = PublicoAlvo.Empreendedor,
                Valor = (double)50
            };

            Assert.Throws<ArgumentException>(() =>
               new Curso(cursoEsperado.Nome, cargaHorariaInvalida, cursoEsperado.PublicoAlvo, cursoEsperado.Valor))
               .ComMensagem("Carga horária inválida");
        }

        [Theory]
        [InlineData(-10)]
        [InlineData(-2)]
        [InlineData(-1)]
        public void NaoDeveTerValorMenorQue1(double valorInvalido)
        {
            var cursoEsperado = new
            {
                Nome = "PD",
                CargaHoraria = (double)30,
                PublicoAlvo = PublicoAlvo.Empreendedor,
                Valor = (double)50
            };

            Assert.Throws<ArgumentException>(() =>
              new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, valorInvalido))
              .ComMensagem("Valor inválido");
        }
    }

    public enum PublicoAlvo
    {
        Estudante,
        Universitario,
        Empregado,
        Empreendedor
    }

    public class Curso
    {
        public string Nome { get; private set; }
        public double CargaHoraria { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }
        public double Valor { get; private set; }

        public Curso(string nome, double cargaHoraria, PublicoAlvo publicoAlvo, double valor)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome inválido");

            if (cargaHoraria < 1)
                throw new ArgumentException("Carga horária inválida");

            if (valor < 1)
                throw new ArgumentException("Valor inválido");

            this.Nome = nome;
            this.CargaHoraria = cargaHoraria;
            this.PublicoAlvo = publicoAlvo;
            this.Valor = valor;
        }
    }
}
