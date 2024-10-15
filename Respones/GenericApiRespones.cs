namespace baby_shop_backend.Respones
{
    public class GenericApiRespones<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public string Error { get; set; }
            
        public GenericApiRespones(int statuscode,string msg,T data,string error = null)
        {
            StatusCode = statuscode;
            Message = msg;
            Data = data;
            Error = error;
        }



    }
}
