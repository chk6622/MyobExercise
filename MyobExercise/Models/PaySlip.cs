namespace MyobExercise.Model
{
    /// <summary>
    /// Employee monthly pay slip
    /// </summary>
    public class PaySlip
    {
        /// <summary>
        /// The employee's name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// per calendar month
        /// </summary>
        public string PayPeriod { get; set; }

        /// <summary>
        /// The employee's annual salary
        /// </summary>
        public int AnnualSalary { get; set; }

        /// <summary>
        /// The employee's super rate
        /// </summary>
        public double SuperRate { get; set; }

        /// <summary>
        /// annual salary / 12 months
        /// </summary>
        public int GrossIncome { get; set; }

        /// <summary>
        /// The employee's income tax which is based on the tax table
        /// </summary>
        public int IncomeTax { get; set; }

        /// <summary>
        /// gross income - income tax
        /// </summary>
        public int NetIncome { get; set; }

        /// <summary>
        /// gross income x super rate
        /// </summary>
        public int Super { get; set; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Name}, {PayPeriod}, {GrossIncome}, {IncomeTax}, {NetIncome}, {Super}";
        }
    }
}
