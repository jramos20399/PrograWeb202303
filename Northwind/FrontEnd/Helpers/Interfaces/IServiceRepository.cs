namespace FrontEnd.Helpers.Interfaces
{
    public interface IServiceRepository
    {

        HttpClient Client { get; set; }

        HttpResponseMessage GetResponse(string url);
        HttpResponseMessage PutResponse(string url, object model);
        HttpResponseMessage PostResponse(string url, object model);
        HttpResponseMessage DeleteResponse(string url);
    }
}
