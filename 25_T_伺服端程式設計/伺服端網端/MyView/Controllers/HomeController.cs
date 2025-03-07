using Microsoft.AspNetCore.Mvc;
using MyView.Models;
using NuGet.Packaging.Licenses;
using System.ComponentModel;
using System.Diagnostics;

namespace MyView.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private List<NightMarket> GetData()
        {
            string[] id = { "A01", "A02", "A03", "A04", "A05", "A06", "A07" };
            string[] name = { "���ש]��", "�sԳ���Ӱ�", "���X�]��", "�C�~�]��", "���]��", "�j�F�]��", "�Z�t�]��" };

            string[] address = { "813����������ϸθ۸�", "800�������s���ϥɿŨ�", "800�x�W�������s���Ϥ��X�G��",
                "80652�������e��ϳͱۥ|��758��", "�x�n���_�Ϯ��w���T�q533��", "�x�n���F�ϪL�˸��@�q276��",
                "�x�n������ϪZ�t��69��42��" };

            List<NightMarket> list = new List<NightMarket>();  //ű�yList�x������

            for (int i = 0; i < name.Length; i++)
            {
                NightMarket nm = new NightMarket();
                nm.ID = id[i];
                nm.Name = name[i];
                nm.Address = address[i];


                list.Add(nm);
            }

            return list;
        }

        public IActionResult Index()
        {
            var list = GetData();

            // select * from list


            //LinQ
            var result = from n in list
                         select n;


            return View(result);
        }

        public IActionResult IndexRWD()
        {
            var list = GetData();

            // select * from list


            //LinQ
            var result = from n in list
                         orderby n.ID descending
                         select n;


            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Razor()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
