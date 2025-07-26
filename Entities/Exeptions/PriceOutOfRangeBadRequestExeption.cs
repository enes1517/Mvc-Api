namespace Entities.Exeptions
{
    public class PriceOutOfRangeBadRequestExeption : BadRequestExeption
    {
        public PriceOutOfRangeBadRequestExeption() : base("Maximum price should be less than 1000 and greater than 10. ")
        {  
        
        } 
    }
}
