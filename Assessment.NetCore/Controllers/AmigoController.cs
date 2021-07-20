using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Assessment.NetCore.Data;
using Assessment.NetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Assessment.NetCore.Controllers
{
    public class AmigoController : Controller
    {
        private readonly DataContext _context;

        public AmigoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("/cadastrar")]
        public IActionResult CadastroAniversarioAmigos()
        {
            return View();
        }
        [HttpGet]
        [Route("/lista")]
        public IActionResult ListaCompletaAmigos()
        {
            var amigos = _context.Amigos.ToList();
            return View(amigos);
        }

        [HttpPost]
        [Route("/listaAniv")]
        public IActionResult CadastroComSucesso(Amigo amigo)
        {
            _context.Amigos.Add(amigo);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");

        }
        [HttpPost]
        [Route("/removerAmigo")]
        public IActionResult RemoverAmigo(long id)
        {
            _context.Amigos.Remove(_context.Amigos.Find(id) ?? throw new InvalidOperationException());
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        [Route("/removerAmigoListaCompleta")]
        public IActionResult RemoverAmigoLista(long id)
        {
            _context.Amigos.Remove(_context.Amigos.Find(id) ?? throw new InvalidOperationException());
            _context.SaveChanges();
            return RedirectToAction("ListaCompletaAmigos", "Amigo");
        }

        [HttpPost]
        [Route("/editarAmigo")]
        public IActionResult EditarAmigo(long id)
        {
            var amigo = _context.Amigos.Find(id);

            return View(amigo);
        }
        
        
        [HttpPost]
        [Route("/confirmarEdicao")]
        public IActionResult ConfirmarEdicao(long id, string nome, string sobrenome, 
            DateTime dataDeNascimento)
        {
            var amigoOld =  _context.Amigos.Find(id);
            if (amigoOld != null)
            {
                amigoOld.nome = nome;
                amigoOld.sobrenome = sobrenome;
                amigoOld.dataDeNascimento = dataDeNascimento;
                _context.Amigos.Update(amigoOld);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Home");        
        }

        [HttpGet]
        [Route("/pesquisarAmigo")]
        public IActionResult ConsultaAmigo(String nome)
        {
            var listaAmigos = _context.Amigos.ToList();
            if (!string.IsNullOrEmpty(nome))
            { 
                var listaPesquisar = listaAmigos.Where(amigo => amigo.nome.Contains(nome));
                var amigos = listaPesquisar.ToList();
                return View(amigos);
            }
            return RedirectToAction("ListaCompletaAmigos", "Amigo");    
        }
    }
}