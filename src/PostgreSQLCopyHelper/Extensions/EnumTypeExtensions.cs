using System;
using System.Text.RegularExpressions;
using NpgsqlTypes;

/**
 * Currently, this will always convert to snake casing. 
 * Ideally it would use the <see href="https://github.com/efcore/EFCore.NamingConventions/blob/master/EFCore.NamingConventions/NamingConventions/Internal/SnakeCaseNameRewriter.cs">`EFCore.NamingStrategy methods</see>, but those are internal.
 * 
 * [SnakeCase](https://github.com/efcore/EFCore.NamingConventions/blob/master/EFCore.NamingConventions/NamingConventions/Internal/SnakeCaseNameRewriter.cs)
 *   is added to DbContextOptions via an [extension method](https://github.com/efcore/EFCore.NamingConventions/blob/c442559286a8856f1dbae92274ef94d7037abdae/EFCore.NamingConventions/NamingConventionsExtensions.cs#L10)
 * 
 * [DbContext.Database doesn't seem useful](https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.infrastructure.databasefacade?view=efcore-3.1)
 * 
 * [DbContext.Model doesn't seem like it holds what we need either](https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.metadata.imodel?view=efcore-3.1)
 * 
 * [DbContext](https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontext?view=efcore-3.1#properties)
 *
 * [IConventionAnnotation](https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.metadata.iconventionannotation?view=efcore-3.1)
**/

namespace PostgreSQLCopyHelper {
    public static class EnumTypeExtensions {

        /**
         * <summary>
         * This is a pretty lazy method of adding enums, it just converts to string 
         * </summary>
         * <param name="helper"></param>
         * <param name="columnName"></param>
         * <param name="dbEnumName">this currently isn't used, in the future it could be used to validate</param>
         * <param name="propertyGetter"></param>
         * <typeparam name="TEntity"></typeparam>
         * <typeparam name="TEnum"></typeparam>
         * <returns></returns>
         */
        public static PostgreSQLCopyHelper<TEntity> MapEnum<TEntity, TEnum>( 
                                                                            this PostgreSQLCopyHelper<TEntity> helper, 
                                                                            string columnName, 
                                                                            string dbEnumName, 
                                                                            Func<TEntity, TEnum> propertyGetter ) {
            return helper.Map(  columnName, 
                                (x) => {
                                    string value   = propertyGetter( x ).ToString();
                                    var newName = Regex.Replace( 
                                                                value, 
                                                                "[a-z][A-Z]", Q => $"{Q.Value[ 0 ]}_{Q.Value[ 1 ]}" 
                                                            ).ToLower();
                                    Console.WriteLine($"propertyGetter: {propertyGetter}={propertyGetter(x)}={newName}");
                                    return newName;
                                }, 
                                NpgsqlDbType.Text );
        }

    }
}
