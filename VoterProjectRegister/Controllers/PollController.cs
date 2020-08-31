using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VoterProjectRegister.Data;

namespace VoterProjectRegister.Controllers
{
    public class PollController : Controller
    {

        private readonly VoterDBContext _context;

        public PollController(VoterDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
