using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using Negocio;
using Utilitario;

namespace ClienteMVC.Controllers
{
    public class SucursalController : Controller
    {
        //
        #region AccesosLN

        public BancoLN oBancoLN { get { return new BancoLN(); } }
        public SucursalLN oSucursalLN { get { return new SucursalLN(); } }

        #endregion

        public ActionResult Index(int IdBancoPar = 0)
        {

            List<Sucursal> lista = oSucursalLN.Listar_Sucursal_PorBanco(IdBancoPar);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_ListadoSucursal", lista);
            }
            else
            {
                List<Banco> listaBanco = oBancoLN.Listar_Banco("");
                ViewBag.ListaBanco = listaBanco;
                return View(lista);
            }

        }

        [HttpGet]
        public ActionResult Editar(int IdSucursal = 0)
        {

            Sucursal sucursal;
            if (IdSucursal == 0)
            {
                sucursal = new Sucursal();
                sucursal.FechaRegistro = DateTime.Now;
            }
            else
            {
                sucursal = oSucursalLN.Recuperar_Sucursal_PorCodigo(IdSucursal);
            }
            List<Banco> listaBanco = oBancoLN.Listar_Banco("");
            ViewBag.ListaBanco = listaBanco;
            return View(sucursal);

        }


        public ActionResult Editar(Sucursal sucursal)
        {

            if (ModelState.IsValid)
            {

                try
                {
                    if (sucursal.IdSucursal == 0)
                    {
                        oSucursalLN.Insertar_Sucursal(sucursal);
                    }
                    else
                    {
                        oSucursalLN.Actualizar_Sucursal(sucursal);
                    }
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("*", "no se pudo grabar los datos. " + ex.Message);

                }
            }
            List<Banco> listaBanco = oBancoLN.Listar_Banco("");
            ViewBag.ListaBanco = listaBanco;
            return View(sucursal);

        }

    }
}
