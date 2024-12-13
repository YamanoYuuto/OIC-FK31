using System.ComponentModel.DataAnnotations;

namespace OIC_FK31.Data
{
    public class facility
    {
        public int FacilityID { get; set; }
        [Required(ErrorMessage = "施設名を入力してください")]
        public string FacilityName { get; set; }
        [Required(ErrorMessage = "住所を入力してください")]
        public string FacilityAddress { get; set; }
        [Required(ErrorMessage = "電話番号を入力してください")]
        public string FacilityPhone { get; set; }
        [Required(ErrorMessage = "開館時間を入力してください")]
        [DataType(DataType.DateTime)]
        public DateTime OpeningTime { get; set; }
        [Required(ErrorMessage = "閉館時間を入力してください")]
        [DataType(DataType.DateTime)]
        public DateTime ClosingTime { get; set; }
        [Required(ErrorMessage = "郵便番号を入力してください")]
        public string FacilityPostCode { get; set; }
        public string FacilityphotoPath { get; set; }
    }
}
