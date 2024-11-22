using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace OIC_FK31.Data
{
    public class userDetail
    {
        public int UserDetailID { get; set; }
        public string UserID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PostalCode { get; set; }
        public string Prefecture { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Building { get; set; }
    }
}
