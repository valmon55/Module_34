using ASP.Web_API.Contracts.Devices;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Contracts.Validation
{
    public class AddDeviceRequestValidator : AbstractValidator<AddDeviceRequest>
    {
        string[] _validLocations;
        public AddDeviceRequestValidator() 
        {
            _validLocations = new[]
            {
                "Kitchen",
                "Bathroom",
                "Livingroom",
                "Toilet"
            };
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Manufacturer).NotEmpty();
            RuleFor(x => x.Model).NotEmpty();
            RuleFor(x => x.SerialNumber).NotEmpty();
            RuleFor(x => x.CurrentVolts).InclusiveBetween(120, 220);
            RuleFor(x => x.GasUsage).NotNull();
            RuleFor(x => x.Location).NotEmpty().Must(IsSupported)
                .WithMessage($"Please choose one of the following locations: {string.Join(", ", _validLocations)}");
        }
        private bool IsSupported(string location)
        {
            return _validLocations.Any(x => x == location);
        }
    }
}
