using System.ComponentModel.DataAnnotations;

namespace WebMvc.Models
{
    public class BookViewModel
    {
        [Display(Name ="書別識別碼")]    
        
        public int Id { get; set; }

        [Display(Name = "書本名稱")]
        [Required(ErrorMessage ="請輸入書本名稱")]
        public string Title { get; set; }

        [Display(Name = "書本價格")]
        [Required(ErrorMessage = "請輸入書本價格")]
        public int Price { get; set; }
      

    }
}
