using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Repository;
using WebApplication2.Models;
using Microsoft.Data.SqlClient;

namespace WebApplication2
{
    public class SignalServer : Hub
    {


        //public void Task GetEmployeeJson(IEmployeeRepo _employeeRepository)
        //{

        //    Clients.All.SendAsync("UpdateEmployeesJson", _employeeRepository.GetAllEmployees());
        

        //    //    await Clients.All.SendAsync("updatedEmployeesList");//, _employeeRepository.GetAllEmployees());

        //    //    //await Clients.Client(Context.ConnectionId).SendAsync("updateEmployeeJson",_employeeRepository.GetAllEmployees());
        //    //}


        //    // Function declared in Hub
        //    //public void Check()
        //    //{ 
        //    //    Clients.All.SendAsync("updatedEmployeesList");
        //    //}



        //    // retrieve all the employees data when db change got triggered


        //    //private readonly IEmployeeRepository _employeeRepository;

        //    //public SignalServer(EmployeeRepository employeeRepository)
        //    //{
        //    //    _employeeRepository = employeeRepository;
        //    //}
        //    //public void DisplayEmployees()
        //    //{
        //    //    Clients.All.SendAsync("updatedEmployeesList", _employeeRepository.GetAllEmployees());
        //    //}

        }
}
