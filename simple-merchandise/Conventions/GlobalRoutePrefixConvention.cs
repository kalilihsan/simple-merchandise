using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace simple_merchandise.Conventions
{
    public class GlobalRoutePrefixConvention : IApplicationModelConvention
    {
        private readonly AttributeRouteModel attributeRouteModel;

        public GlobalRoutePrefixConvention(string prefix)
        {
            attributeRouteModel = new AttributeRouteModel(new RouteAttribute(prefix));
        }

        public void Apply(ApplicationModel applicationModel)
        {
            foreach (var controller in applicationModel.Controllers)
            {
                foreach (var selector in controller.Selectors.Where(s => s.AttributeRouteModel != null))
                {
                    selector.AttributeRouteModel = AttributeRouteModel.CombineAttributeRouteModel(
                        attributeRouteModel,
                        selector.AttributeRouteModel);
                }
            }
        }
    }
}
