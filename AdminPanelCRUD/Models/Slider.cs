using System.ComponentModel.DataAnnotations;

namespace AdminPanelCRUD.Models
{
    public class Slider
    {
        public int Id { get; set; }
        [StringLength(maximumLength:25)]
        public string FirstTitle { get; set; }
        [StringLength(maximumLength:25)]
        public string SecondTitle { get; set; }
        [StringLength(maximumLength:250)]
        public string Description { get; set; }
        public string RedirectUrl { get; set; }
        [StringLength(maximumLength:20)]
        public string RedirectUrlText { get; set; }
        public string ImgUrl { get; set; }

    }
}
