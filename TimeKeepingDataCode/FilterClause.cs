
namespace TimeKeepingDataCode
{
    public struct FilterClause<T>
    {
        private bool isFilter;
        private T data;

        public FilterClause(T data)
        {
            this.data = data;
            this.isFilter = true;
        }

        public T Value { get { return this.data; } }
        public bool IsFilter { get { return this.isFilter; } }
    }
}
