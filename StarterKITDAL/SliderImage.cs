namespace StarterKITDAL
{
    public class SliderImage:BaseEntity
    {
        public string Name { get; set; }    
        public string ImageUrl { get; set; }
        public string SliderPosition { get; set; } //Mainslider, SecondRowSlider, ProductImage
        public string SliderMainText { get; set; }
        public string SliderDetailText { get; set; }
        public int SliderOrder { get; set; }
    }
}
