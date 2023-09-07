using System.Security.Claims;
using Micro.Erp.Api.Model;
using Micro.Erp.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace Micro.Erp.Api.Controllers;

public class BaseController : ControllerBase
{
    
    protected Guid UsuarioId => Guid.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
    private readonly NotificationContext _notificationContext;
    public BaseController(NotificationContext notificationContext)
    {
        _notificationContext = notificationContext;
    }
    
    public override ObjectResult StatusCode(int statusCode, object? value)
    {
        var response = new ReturnOk(value);
        if (_notificationContext.HasNotifications)
        {
            response.Response = null;
            response.Messages = _notificationContext.Notifications;
            response.Ok = false;
            response.StatusCode = 400;
            return base.StatusCode(statusCode: 400, value: response);
        }
        return base.StatusCode(200, response);
    }
}