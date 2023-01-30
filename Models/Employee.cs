using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Test.test.Models
{
    [Table("employees")]
    public class Employee
    {
        [Key]
        public int employee_id { get; set; }
        public string firstName {get;set;}
        public string lastName {get;set;}
        public string email { get; set; }
        public string phone {get; set;}
        public DateTime? hireDate {get; set;}
        public int? job_id { get; set;}
        public decimal salary { get; set;}
        public int? managerid { get; set;}    
        public int? departmentid { get; set;}
    }
}
