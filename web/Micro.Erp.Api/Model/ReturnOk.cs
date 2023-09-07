using Micro.Erp.Domain.Notifications;

namespace Micro.Erp.Api.Model;

public class ReturnOk
{
    public int StatusCode { get; set; }
    public IReadOnlyCollection<Notification> Messages { get; set; }
    public bool Ok { get; set; }
    public object? Response { get; set; }

    public ReturnOk(object? data, IReadOnlyCollection<Notification> messages = null, bool ok = true, int code = 200)
    {
        this.Messages = messages;
        this.Ok = ok;
        this.Response = data;
        this.StatusCode = code;
    }
}