using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Htp.Validation.Domain.Contracts;
using Htp.Validation.Domain.Contracts.Comands;
using Htp.Validation.Domain.Contracts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Htp.Validation.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/payments")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService paymentService;
        private readonly IUrlHelper urlHelper;
        private readonly ILogger<PaymentsController> logger;

        public PaymentsController(IPaymentService paymentService, 
            IUrlHelper urlHelper, ILogger<PaymentsController> logger)
        {
            this.paymentService = paymentService;
            this.urlHelper = urlHelper;

            this.logger = logger;
        }

        [HttpGet(Name = "GetPayments")]
        public async Task<ActionResult> GetPayments()
        {
            logger.LogInformation(LoggingEvents.ListItems, "List payments");

            var payments = await paymentService.GetAllAsync();

            var wrapper = new LinkedCollectionResourceWrapper<PaymentModel>(payments);
            return Ok(CreateLinksForPayment(wrapper)); 
        }

        [HttpGet("{id}", Name = "GetPayment")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> GetPayment(int id)
        {
            logger.LogInformation(LoggingEvents.GetItem, "Get payment by Id");

            var payment = await paymentService.GetAsync(id);

            if (payment == null)
                return NotFound($"Payment with id {id} not found"); // TODO: add localization

            return Ok(CreateLinksForPayment(payment));
        }

        [HttpPost(Name = nameof(CreatePayment))]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        // TODO: ask about return type
        // public async Task<ActionResult<PaymentModel>> CreatePayment([FromBody] CreatePaymentRequest createPaymentRequest)
        public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentRequest createPaymentRequest)
        {
            logger.LogInformation(LoggingEvents.InsertItem, "Insert new payment");

            if (createPaymentRequest == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            var paymentModel = await paymentService.AddAsync(createPaymentRequest);

            return CreatedAtAction(nameof(GetPayment), new { id = paymentModel.Id }, CreateLinksForPayment(paymentModel));
        }

        private PaymentModel CreateLinksForPayment(PaymentModel paymentModel)
        {
            var id = new { id = paymentModel.Id };

            paymentModel.Links.Add(
                new Link()
                {
                    Rel = "self",
                    Href = urlHelper.Link(nameof(GetPayment), id),
                    Action = "GET",
                    Types = new string[] { "application/json" }

                });
                

            //user.Links.Add(
            //    new LinkDto(this.urlHelper.Link(nameof(this.ModifyHateoasUser), idObj),
            //    "update_user",
            //    "PUT"));

            //user.Links.Add(
            //    new LinkDto(this.urlHelper.Link(nameof(this.PartiallyModifyHateoasUser), idObj),
            //    "partially_update_user",
            //    "PATCH"));

            //user.Links.Add(
            //    new LinkDto(this.urlHelper.Link(nameof(this.DeleteHateoasUser), idObj),
            //    "delete_user",
            //    "DELETE"));

            return paymentModel;
        }

        private LinkedCollectionResourceWrapper<PaymentModel> CreateLinksForPayment(LinkedCollectionResourceWrapper<PaymentModel> wrapper)
        {
            wrapper.Links.Add(
                new Link()
                {
                    Rel = "self",
                    Href = urlHelper.Link(nameof(GetPayments), new { }),
                    Action = "GET",
                    Types = new string[] { "application/json" }

                });

            return wrapper;
        }
    }
}
