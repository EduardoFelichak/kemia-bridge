using AutoMapper;

namespace KemiaBridge.Service.Mappers
{
    public static class MappingExtensions
    {
        public static IMappingExpression<TSource, TDestination> IgnoreNullSourceValues<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> mappingExpression)
        {
            mappingExpression.ForAllMembers(options =>
            {
                options.Condition((src, dest, srcMember) => srcMember != null);
            });

            return mappingExpression;
        }
    }
}
