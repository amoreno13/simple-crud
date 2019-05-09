using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {        
        private IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        //eu usaria uma viewModel, com um AutoMapper da vida em tudo, mas já está tarde
        public ActionResult Index()
        {
            var model = this._unitOfWork.UsuarioRepository.GetAll();

            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            var model = id.HasValue ? this._unitOfWork.UsuarioRepository.GetById(id.Value) : new Domain.Entities.Usuario();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]        
        public ActionResult Edit(Domain.Entities.Usuario model)
        {
            if (model.UsuarioId > 0)
                this._unitOfWork.UsuarioRepository.Update(model);
            else
                this._unitOfWork.UsuarioRepository.Add(model);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                var usuario = this._unitOfWork.UsuarioRepository.GetById(id);
                this._unitOfWork.UsuarioRepository.Remove(usuario);
            }

            return RedirectToAction("Index");
        }
    }
}