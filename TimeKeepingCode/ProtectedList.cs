using System.Collections.Generic;

namespace TimeKeepingCode
{
    public class ProtectedList<T>
    {
        private List<T> list;

        public ProtectedList(List<T> value)
        {
            this.list = new List<T>(value);
        }

        public IEnumerable<T> GetList() 
        {
            return this.list;
        }
    }
}
