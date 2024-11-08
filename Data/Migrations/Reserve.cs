using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace OIC_FK31.Data.Migrations
{
    public class Reserve
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int BuildingID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string EmailConfirm { get; set; }
        public string Phone {  get; set; }
        public string PhoneConfirm { get; set; }
        public string Postalcode {  get; set; }
        public string Prefecture { get; set; }
        public string city { get; set; }
        public string Address { get; set; }
        public string Building { get; set; }
    }
}
