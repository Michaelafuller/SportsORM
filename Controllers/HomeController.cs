using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {   
            ViewBag.WomensLeagues = _context.Leagues
                .Where(l => l.Name.Contains("Women"))
                .ToList();

            ViewBag.HockeyLeagues = _context.Leagues
                .Where(l => l.Name.Contains("Hockey"))
                .ToList();

            IList<League> FootballLeagues = _context.Leagues
                .Where(l => l.Name.Contains("Football"))
                .ToList();

            IList<League> All = _context.Leagues
                .Where(l => l.Sport != null)
                .ToList();

            ViewBag.NotFootball = All
                .Except(FootballLeagues);

            ViewBag.WithConference = _context.Leagues
                .Where(l => l.Name.Contains("Conference"))
                .ToList();

            ViewBag.AtlanticLeagues = _context.Leagues
                .Where(l => l.Name.Contains("Atlantic"))
                .ToList();

            ViewBag.DallasTeams = _context.Teams
                .Where(t => t.Location.Contains("Dallas"))
                .ToList();

            ViewBag.Raptors = _context.Teams
                .Where(t => t.TeamName.Contains("Raptors"))
                .ToList();

            ViewBag.CityLocation = _context.Teams
                .Where(t => t.Location.Contains("City"))
                .ToList();

            ViewBag.NameBeginsT = _context.Teams
                .Where(t => t.TeamName.StartsWith("T"))
                .ToList();

            ViewBag.OrderedByLocation = _context.Teams
                .Where(t => t.TeamName != null)
                .OrderBy(t => t.Location)
                .ToList();

            ViewBag.RevOrderedByTeamName = _context.Teams
                .Where(t => t.TeamName != null)
                .OrderByDescending(t => t.TeamName)
                .ToList();

            var LastNameCooper = _context.Players
                .Where(p => p.LastName.Contains("Cooper"))
                .ToList();
            ViewBag.LastNameCooper = LastNameCooper;
            
            var FirstNameJoshua = _context.Players
                .Where(p => p.FirstName.Contains("Joshua"))
                .ToList();
            ViewBag.FirstNameJoshua = FirstNameJoshua;

            ViewBag.LastNameCooperNotJoshua = LastNameCooper
                .Except(FirstNameJoshua);

            ViewBag.FirstNameAlexanderOrWyatt = _context.Players
                .Where(p => p.FirstName.Contains("Wyatt") || p.FirstName.Contains("Alexander"))
                .ToList();

            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}