using MyProject.Interface;
using MyProject.Models;

namespace MyProject.Services
{
    public class StockPhotosService: IStockPhotosService
    {
        public string GetPhotoUrl(string text)
        {
            return GetStockPhotos().Where(w => w.MainText.ToLower() == text).FirstOrDefault().Url;
        }
        public StockPhotos GetPhotoId(int Id)
        {
            return GetStockPhotos().ElementAt(Id);
        }
        public IEnumerable<Models.StockPhotos> GetStockPhotos()
        {
            return new List<Models.StockPhotos>
            {
            new Models.StockPhotos("https://images.ctfassets.net/ham3h61ph2oq/4l9VRaFHGbgm8VkF5qyj6T/5814e1f0aba28f6850bb853267954cb1/love-descriptive.jpg",
            "Love", "Affection"),
             new Models.StockPhotos("https://assets.website-files.com/57e134cf4bfd281659d2bf28/6491449e572ce04545094b82_photocase_photo_id_3374948_nl.jpg",
            "Hate", "Affection"),
            new Models.StockPhotos("https://assets.website-files.com/57e134cf4bfd281659d2bf28/6476e88b2a595cf06aaf0c49_photocase_photo_id_5293850_landscape.jpg",
            "BEST IN MAY 2023", "Affection"),
            new Models.StockPhotos("https://assets.website-files.com/57e134cf4bfd281659d2bf28/646b65dc7b7e21b4810df8b6_photocase_photo_id_4156954_nl2.jpg",
            "ROLLING", "Affection"),
            new Models.StockPhotos("https://assets.website-files.com/57e134cf4bfd281659d2bf28/646b7e7749082c551380217b_photocase_photo_id_4383430_nl.jpg",
            "GLIDING", "Affection"),
            new Models.StockPhotos("https://assets.website-files.com/57e134cf4bfd281659d2bf28/646b6c38113785ea7e77d1f3_photocase_photo_id_4890904_landscape.jpg",
            "FLYING", "Affection"),
            new Models.StockPhotos("https://assets.website-files.com/57e134cf4bfd281659d2bf28/644771819a4739610612e3b1_elizanl.jpg",
            "BEST IN APRIL 2023", "Affection"),
            new Models.StockPhotos("https://assets.website-files.com/57e134cf4bfd281659d2bf28/6437a82287e28f7d4aa3d661_photocase_photo_id_3409297_landscape.jpg",
            "YES!", "Affection"),
            new Models.StockPhotos("https://assets.website-files.com/57e134cf4bfd281659d2bf28/6437a69183ff83782e722901_photocase_photo_id_3314720_landscape.jpg",
            "NO!", "Affection"),
            new Models.StockPhotos("https://assets.website-files.com/57e134cf4bfd281659d2bf28/6436523e424c6f05a86e7d2e_photocase_photo_id_4580677_landscape.jpg",
            "MAYBE?", "Affection"),
            new Models.StockPhotos("https://assets.website-files.com/57e134cf4bfd281659d2bf28/642292ae577cb30003a5f559_photocase_photo_id_5217679_landscape.jpg",
            "BEST IN MARCH 2023!", "Affection"),
            new Models.StockPhotos("https://assets.website-files.com/57e134cf4bfd281659d2bf28/641023c46ae450aa9fb9fd80_photocase_photo_id_4134454_landscape.jpg",
            "SWEET!", "Affection"),
            new Models.StockPhotos("https://assets.website-files.com/57e134cf4bfd281659d2bf28/641025198b78467419d92896_photocase_photo_id_276360_landscape.jpg",
            "HOT!", "Affection"),
            new Models.StockPhotos("https://assets.website-files.com/57e134cf4bfd281659d2bf28/6410422dd30b06326b3e795b_photocase_photo_id_52486_nl.jpg",
            "SOUR VS. BITTER!", "Affection"),
            new Models.StockPhotos("https://assets.website-files.com/57e134cf4bfd281659d2bf28/63fdaeea77c63c1c08572851_photocase_photo_id_5178079_landscape.jpg",
            "BEST IN FEBRUARY 2023!", "Affection"),
            new Models.StockPhotos("https://assets.website-files.com/57e134cf4bfd281659d2bf28/63eca40330aee3584c2e3fb2_photocase_photo_id_134268_landscape.jpg",
            "2001 - 2009!", "Affection"),
        };
        }
    }
}


//p_text.push("BEST IN FEBRUARY 2023!");
//span_text.push("Affection");
//span_text.push("Aversion");
//span_text.push("Favourite images from this month");
//span_text.push("Create Rotation");
//span_text.push("Overcome Adhesion");
//span_text.push("Beat Gravity");
//span_text.push("Favourite images from this month");
//span_text.push("Acceptance");

//span_text.push("Refusal");
//span_text.push("Indecision");
//span_text.push("Favourite images from this month");
//span_text.push("Sugar, Kitsch and Love");
//span_text.push("Heat and Pain");
//span_text.push("brrr, bah and yuck");
//span_text.push("Favourite images from this month");
//span_text.push("Loud & Commercial");
