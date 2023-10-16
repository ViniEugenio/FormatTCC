using FormatTCC.API.Filters;

namespace FormatTCC.API.Configurations
{
    public static class FiltersConfiguration
    {

        public static void ConfigureFilters(this IServiceCollection services)
        {
            services.AddMvc(options => options.Filters.Add(typeof(ModelStateValidatorFilter)));
        }

    }
}
