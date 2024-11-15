using System.ComponentModel.DataAnnotations;

namespace OIC_FK31.Data
{
    public class facility
    {
        public int FacilityID { get; set; }
        public string FacilityName { get; set; }
        public string FacilityAddress { get; set; }
        public string FacilityPhone { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime OpeningTime { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime ClosingTime { get; set; }
        public string FacilityPostCode { get; set; }
        public string FacilityphotoPath { get; set; }
    }
}
