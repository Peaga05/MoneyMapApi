namespace Domain.Base.PagedResult
{
    public class PagedResultDto<T>
    {
        public int Amount {  get; set; }
        public List<T> Result { get; set; }
    }
}
