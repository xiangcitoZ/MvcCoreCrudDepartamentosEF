using Microsoft.AspNetCore.Mvc;
using MvcCoreCrudDepartamentosEF.Models;
using MvcCoreCrudDepartamentosEF.Repository;

namespace MvcCoreCrudDepartamentosEF.Controllers
{
    public class DepartamentosController : Controller
    {
        private RepositoryDepartamentos repo;
        public DepartamentosController(RepositoryDepartamentos repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {   
            List<Departamento> departamentos = 
                this.repo.GetDepartamentos();
            return View(departamentos);

        }

        public IActionResult Details(int iddepartamento)
        {
            Departamento departamento = 
                this.repo.FindDepartamento(iddepartamento);
            return View(departamento);

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Departamento departamento)
        {
            await this.repo.InsertDepartamentoAsync
                (departamento.IdDepartamento, departamento.Nombre
                , departamento.Localidad);
            return RedirectToAction("Index");

        }

        public IActionResult Edit(int iddepartamento)
        {
            Departamento departamento = this.repo.FindDepartamento(iddepartamento);
            return View(departamento);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Departamento departamento)
        {
            await this.repo.UpdateDepartamento
                (departamento.IdDepartamento, departamento.Nombre
                , departamento.Localidad);
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Delete(int iddepartamento)
        {
            await this.repo.DeleteDepartamento(iddepartamento);
            return RedirectToAction("Index");

        }

    }
}
