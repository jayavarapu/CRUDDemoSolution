using CRUDDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDDemo.Controllers
{
    public class PlayerController : Controller
    {
        private CrudContext _crudContext = null;

        public PlayerController()
        {
            _crudContext = new CrudContext();
        }
        // GET: Player
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetPlayers()
        {
            List<Player> players = new List<Player>();
            players = _crudContext.PlayerSet.ToList();
            return Json(new { list = players }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetPlayerById(int id)
        {
            Player payer = new Player();
            payer = _crudContext.PlayerSet.Find(id);
            return Json(new { player = payer }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddPlayer(Player player)
        {
            _crudContext.PlayerSet.Add(player);
            _crudContext.SaveChanges();
            return Json(new { status = "Player added successfully!" },JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdatePlayer(Player player)
        {
            _crudContext.Entry(player).State = System.Data.Entity.EntityState.Modified;
            _crudContext.SaveChanges();
            return Json(new { status = "Player updated successfuly!" });
        }

        public JsonResult Delete(int payerId)
        {
            Player payer = _crudContext.PlayerSet.Find(payerId);
            _crudContext.PlayerSet.Remove(payer);
            _crudContext.SaveChanges();
            return Json(new { status = "Player Deleted successfuly!" });
        }
    }
}