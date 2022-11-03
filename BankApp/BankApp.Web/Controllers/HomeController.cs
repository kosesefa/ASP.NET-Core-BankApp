using BankApp.Web.Data.Context;
using BankApp.Web.Data.Entities;
using BankApp.Web.Data.İnterfaces;
using BankApp.Web.Data.Reporsitories;
using BankApp.Web.Data.UnitOfWork;
using BankApp.Web.Mapping;
using BankApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BankApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserMapper _userMapper;
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUserMapper userMapper, IUnitOfWork unitOfWork)
        {

            _userMapper = userMapper;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {

            return View(_userMapper.MapToListOfUserList(_unitOfWork.GetRepository<ApplicationUser>().GetAll()));
        }
    }
} 
