
namespace TimeKeepingCode.Code
{
    public class CasherCheckerReportWrapper
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RestDay { get; set; }
        public string Monday { get; set; }
        public string Tuesday { get; set; }
        public string Wednesday { get; set; }
        public string Thursday { get; set; }
        public string Friday { get; set; }
        public string Saturday { get; set; }
        public string Sunday { get; set; }
        public string Type { get; set; }
        public bool IsWarehouse { get; set; }

        public CasherCheckerReportWrapper(int id,string name,string restday,string monday,
            string tuesday,string wednesday,string thursday,string friday,string saturday,
            string sunday,string type,bool isWarehouse)
        {
            this.Id = id;
            this.Name = name;
            this.RestDay = restday;
            this.Monday = monday;
            this.Tuesday = tuesday;
            this.Wednesday = wednesday;
            this.Thursday = thursday;
            this.Friday = friday;
            this.Saturday = saturday;
            this.Sunday = sunday;
            this.Type = type;
            this.IsWarehouse = isWarehouse;
        }
    }
}
