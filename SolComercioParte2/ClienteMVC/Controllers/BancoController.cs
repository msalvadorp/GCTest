using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using Negocio;

namespace ClienteMVC.Controllers
{
    public class BancoController : Controller
    {
        public BancoLN oBancoLN { get { return new BancoLN(); } }

        public ActionResult Index(string txtFiltro = "")
        {
            List<Banco> lista = new BancoLN().Listar_Banco(txtFiltro);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_ListadoBanco", lista);
            }

            return View(lista);
        }


        public ActionResult Editar(int IdBanco = 0)
        {
            Banco banco;
            if (IdBanco == 0)
            {
                banco = new Banco();
            }
            else
            {
                banco = oBancoLN.Recuperar_Banco_PorCodigo(IdBanco);
            }

            return PartialView("_EditarBanco", banco);
        }

        public ActionResult GrabarBanco(Banco banco)
        {

            if (ModelState.IsValid)
            {
                try
                {


                    if (banco.IdBanco == 0)
                    {
                        oBancoLN.Insertar_Banco(banco);
                    }
                    else
                    {
                        oBancoLN.Actualizar_Banco(banco);
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("*", ex.Message);
                    //Grabar log
                    //throw;
                }
            }

            return PartialView("_EditarBancoCuerpo", banco);
        }

    }
}
