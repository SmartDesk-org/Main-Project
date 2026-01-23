using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ResourceFlow.Domain.Entities.Booking;
using ResourceFlow.Domain.Enums.Authorization;
using ResourceFlow.Domain.Enums.Resource_Booking;
using ResourceFlow.Infrastructure.Persistence.EF.Context;

namespace ResourceFlow.WebAPI.Controllers.OData
{
    //[AllowAnonymous]
    public class ResourceBookingsController : ODataController
    {
        private readonly AppDbContext _context;

        public ResourceBookingsController(AppDbContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        // GET /odata/ResourceBookings
        [EnableQuery(MaxTop = 100)]
        public IQueryable<ResourceBooking> Get()
        {
            return _context.resourceBookings;
        }
        [AllowAnonymous]
        [ModuleAuthorize(ModuleCode.RBT,PermissionAction.View)]
        //GET /odata/ResourceBookings(1)
        [EnableQuery]
        public SingleResult<ResourceBooking> Get([FromRoute] int key)
        {
            var result = _context.resourceBookings.Where(x => x.Id == key);
            return SingleResult.Create(result);
        }
      

    }
}
