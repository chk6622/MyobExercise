namespace MyobExercise.Model
{
    /// <summary>
    /// Tax level
    /// </summary>
    public class TaxLevel
    {
        public int BottomIncome { get; set; }  //the bottom income of this income level 

        public int CeilingIncome { get; set; } = int.MaxValue;  //the ceiling income of this income level

        public int BaseTax { get; set; }   //the base tax of this income level

        public double UnitTax { get; set; }  //the unit tax of the part income which is more than the ceiling income of the previous income level
    }
}
