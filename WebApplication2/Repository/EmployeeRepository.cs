using Microsoft.AspNetCore.SignalR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IHubContext<SignalServer> _hubContext;
        //private readonly SignalServer _signal; // SignalR class DI
        string connectionString = "";

        public EmployeeRepository(IConfiguration configuration, IHubContext<SignalServer> hubContext)//, SignalServer signal)
        {
            connectionString = configuration.GetConnectionString("EmployeeDBDatabase");
            _hubContext = hubContext;
            //_signal = signal;
        }
        public List<Employee> GetAllEmployees()
        {
            //return db.Employee.ToList();

            var employees_list = new List<Employee>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlDependency.Start(connectionString);

                string commandText = "select Empid, EmpName, EmpCountry from dbo.Employee";

                SqlCommand cmd = new SqlCommand(commandText, sqlConnection);

                SqlDependency dependency = new SqlDependency(cmd);

                //SignalServer s = new SignalServer();

                //dependency.OnChange += new OnChangeEventHandler(_signal.dbChangeNotification); // Hub call
                dependency.OnChange += new OnChangeEventHandler(dbChangeNotification);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var employee = new Employee
                    {
                        Empid = Convert.ToInt32(reader["Empid"]),
                        EmpName = reader["EmpName"].ToString(),
                        EmpCountry = reader["EmpCountry"].ToString()
                    };
                    employees_list.Add(employee);
                }
            }

            return employees_list;
        }

        private void dbChangeNotification(object sender, SqlNotificationEventArgs e)
        {
            _hubContext.Clients.All.SendAsync("updatedEmployeesList"); // call the function from signalR hub

            //_signal.DisplayEmployees();
            // _signal.Check();

        }
    }
}
