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
    public class OrdenPagoController : Controller
    {
        //
        #region AccesosLN

        public BancoLN oBancoLN { get { return new BancoLN(); } }
        public SucursalLN oSucursalLN { get { return new SucursalLN(); } }
        public OrdenPagoLN oOrdenPagoLN { get { return new OrdenPagoLN(); } }
        public TipoLN oTipoLN { get { return new TipoLN(); } }

        #endregion

        public ActionResult Index(int IdSucursal = 0, int TipoMoneda = 0, int TipoSituacion = 0)
        {

            List<OrdenPago> lista = oOrdenPagoLN.Listar_OrdenPago(IdSucursal, TipoMoneda, TipoSituacion);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_ListaOrdenPago", lista);
            }
            else
            {
                LlenarViewBag();
                return View(lista);
            }

        }

        [HttpGet]
        public ActionResult Editar(int IdOrdenPago = 0)
        {

            OrdenPago op;
            if (IdOrdenPago == 0)
            {
                op = new OrdenPago();
                op.FechaPago = DateTime.Now;
            }
            else
            {
                op = oOrdenPagoLN.Recuperar_OrdenPago_PorCodigo(IdOrdenPago);
            }

            LlenarViewBag();
            return View(op);

        }

        [HttpPost]
        public ActionResult Editar(OrdenPago OrdenPago)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (OrdenPago.IdOrdenPago == 0)
                    {
                        oOrdenPagoLN.Insertar_OrdenPago(OrdenPago);
                    }
                    else
                    {
                        oOrdenPagoLN.Actualizar_OrdenPago(OrdenPago);
                    }
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("*", ex.Message);
                }
            }
            LlenarViewBag();
            return View(OrdenPago);

        }

        private void LlenarViewBag()
        {
            List<Sucursal> listaSucursal = oSucursalLN.Listar_Sucursal();
            listaSucursal.Insert(0, new Sucursal() { IdSucursal = 0, NombreBancoSucursal = "<< TODOS >> "});
            ViewBag.ListaSucursal = listaSucursal;

            List<EnumTipos> lista = new List<EnumTipos>();
            lista.Add(EnumTipos.TipoMoneda);
            lista.Add(EnumTipos.TipoSituacionOrdenPago);
            Dictionary<EnumTipos, List<Tipo>> parametro = oTipoLN.Listar_Tipo_PorGrupo(lista);

            Tipo tipoNuevo = new Tipo() { IdTipo = 0, Nombre = " << TODOS >> "};
            parametro[EnumTipos.TipoMoneda].Insert(0, tipoNuevo);
            parametro[EnumTipos.TipoSituacionOrdenPago].Insert(0, tipoNuevo);

            ViewBag.ListaTipos = parametro;
        }
    }
}
