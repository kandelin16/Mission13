using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mission13_ka.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace mission13_ka.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BowlingDBContext context;

        public HomeController(ILogger<HomeController> logger, BowlingDBContext temp)
        {
            _logger = logger;
            context = temp;
        }

        //Default teamID is -1, which means no team is selected
        public IActionResult Index(int teamID = -1)
        {
            ViewBag.teams = context.Teams.ToList();
            
            if (teamID == -1)
            {
                ViewBag.bowlers = context.Bowlers.ToList();
                ViewBag.selectedTeam = new Team { TeamID = -1, TeamName = "" };
            }
            else
            {
                ViewBag.bowlers = context.Bowlers.Where(b => b.TeamID == teamID).ToList();
                ViewBag.selectedTeam = context.Teams.FirstOrDefault(t => t.TeamID == teamID);
            }
            return View();
        }

        public IActionResult UpdateBowler(IFormCollection form)
        {
            var bowler = context.Bowlers.FirstOrDefault(b => b.BowlerID == int.Parse(form["id"]));
            bowler.BowlerFirstName = form["firstName"];
            bowler.BowlerLastName = form["lastName"];
            bowler.BowlerMiddleInit = form["middleInit"];
            bowler.BowlerAddress = form["address"];
            bowler.BowlerPhoneNumber = form["phone"];
            bowler.BowlerCity = form["city"];
            bowler.BowlerState = form["state"];
            bowler.BowlerZip = form["zip"];
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public IActionResult DeleteBowler(int ID)
        {
            using (var context = new BowlingDBContext())
            {
                var bowler = context.Bowlers.FirstOrDefault(b => b.BowlerID == ID);
                //List<Bowler_Score> scores = context.Bowler_Scores.Where(s => s.BowlerID == bowler.BowlerID).ToList();
                //foreach (Bowler_Score score in scores)
                //{
                //    context.Bowler_Scores.Remove(score);
                //}
                context.Bowlers.Remove(bowler);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult AddBowler(IFormCollection form)
        {
            var bowler = new Bowler();
            bowler.BowlerFirstName = form["firstName"];
            bowler.BowlerLastName = form["lastName"];
            bowler.BowlerMiddleInit = form["middleInit"];
            bowler.BowlerAddress = form["address"];
            bowler.BowlerPhoneNumber = form["phone"];
            bowler.BowlerCity = form["city"];
            bowler.BowlerState = form["state"];
            bowler.BowlerZip = form["zip"];
            bowler.TeamID = int.Parse(form["team"]);
            context.Bowlers.Add(bowler);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
