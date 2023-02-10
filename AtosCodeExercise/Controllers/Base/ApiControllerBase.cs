using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
        private ISender _mediator = null!;

        public ISender Mediator
        {
            get
            {
                return _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
            }
            set 
            { 
                _mediator = value; 
            }
        }

        protected async Task<ActionResult<T>> Send<T>(IRequest<T> request)
        {
            return this.Ok(await this.Mediator.Send(request));
        }

        protected async Task<ActionResult> Send(IRequest request)
        {
            return this.Ok(await this.Mediator.Send(request));
        }
    }
}
