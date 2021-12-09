using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DietAnalyzer.Models.Domains
{
    /// <summary>
    /// 
    /// A simple domain class for FoodItem
    /// Most fields are actually stored in Nutrition and Restrictions
    /// 
    /// </summary>

    /// <remarks>
    /// Note: there are two possible ways to store a food image: 
    /// 1) as a static wwwroot resource, and 2) as a byte array in the database
    /// Currently, 1) is used for all pre-defined foods (data seeding), and 2) is used for all custom user foods
    /// I am not 100% sure if this is the right approach, though the internet seems to tentatively approve it
    /// 
    /// In any case, this class also includes a short GetImageSrc method (basically a getter) that returns
    /// image string in a consistent format. Always use this method to access images from outside this class, 
    /// unless you are sure you know what you are doing.
    /// 
    /// </remarks>
    public class FoodItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public string ImageFromApp { get; set; }
        public byte[] ImageFromUser { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public NutritionFood Nutrition { get; set; }
        public RestrictionFood Restrictions { get; set; }

        public ICollection<FoodMeasure> Measures { get; set; }
        public ICollection<DietItem> DietItems { get; set; }
        public FoodItem()
        {
            DietItems = new Collection<DietItem>();
            Measures = new Collection<FoodMeasure>();
        }
        public string GetImageSrc()
        {
            return ImageFromApp ?? 
                (ImageFromUser == null ? null :
                String.Format("data:image/png;base64,{0}", Convert.ToBase64String(ImageFromUser))); 
        }

    }
}
