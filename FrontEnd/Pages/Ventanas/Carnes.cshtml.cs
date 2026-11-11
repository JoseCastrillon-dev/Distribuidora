using LibDominio.entidades;
using LibAplicacion.nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LibPresentacion.interfaces;

namespace FrontEnd.Pages.Ventanas
{
    public class CarnesModel : PageModel
    {
        private ICarnesPresentacion ICarnesPresentacion;

        public CarnesModel(ICarnesPresentacion ICarnesPresentacion)
        {
            this.ICarnesPresentacion = ICarnesPresentacion;
            this.Filtro = new Carnes();
        }

        [BindProperty] public List<Carnes> Lista { get; set; }
        [BindProperty] public Carnes? Filtro { get; set; }
        [BindProperty] public Carnes? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;


        public void OnGet() { OnPostBtBuscar(); }

        public void OnPostBtBuscar()
        {
            try
            {
                this.Filtro!.Codigo = this.Filtro!.Codigo ?? "";
                this.Filtro!.Nombre = this.Filtro!.Nombre ?? "";
                Lista = this.ICarnesPresentacion.Buscar(this.Filtro!);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtNuevo()
        {
            try
            {
                Formulario = true;
                this.Actual = new Carnes();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtGuardar()
        {
            try
            {
                if (this.Actual!.Id == 0)
                    this.Actual = this.ICarnesPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.ICarnesPresentacion.Actualizar(this.Actual!);
                OnPostBtBuscar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
            finally
            {
                OnPostBtBuscar();
            }
        }
        public void OnPostBtEditar(string data)
        {
            try
            {
                Formulario = true;
                OnPostBtBuscar();
                Actual = this.Lista.FirstOrDefault(x => x.Id == Convert.ToInt32(data));
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtPregBorrar(string data)
        {
            try
            {
                Borrar = true;
                OnPostBtBuscar();
                Actual = this.Lista.FirstOrDefault(x => x.Id == Convert.ToInt32(data));
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtBorrar()
        {
            try
            {
                if (this.Actual!.Id == 0)
                    return;
                this.Actual = this.ICarnesPresentacion.Borrar(this.Actual!);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
            finally
            {
                OnPostBtBuscar();
            }
        }
    }
}
