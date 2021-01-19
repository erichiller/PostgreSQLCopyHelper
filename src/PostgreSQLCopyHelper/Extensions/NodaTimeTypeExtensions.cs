// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Linq;
using NpgsqlTypes;
using NodaTime;
using Npgsql;

namespace PostgreSQLCopyHelper
{
    public static class NodaTimeTypeExtensions
    {
        public static void AddUseNodaTime()
        {
            if (!NpgsqlConnection.GlobalTypeMapper.Mappings.Any(m => m.ClrTypes.Contains(typeof(NodaTime.LocalDate))))
            {
                NpgsqlConnection.GlobalTypeMapper.UseNodaTime();
            }
        }

        public static PostgreSQLCopyHelper<TEntity> MapDate<TEntity>(this PostgreSQLCopyHelper<TEntity> helper, string columnName, Func<TEntity, LocalDate> propertyGetter)
        {
            NodaTimeTypeExtensions.AddUseNodaTime();
            return helper.Map(columnName, propertyGetter, NpgsqlDbType.Date);
        }

        public static PostgreSQLCopyHelper<TEntity> MapDate<TEntity>(this PostgreSQLCopyHelper<TEntity> helper, string columnName, Func<TEntity, LocalDate?> propertyGetter)
        {
            NodaTimeTypeExtensions.AddUseNodaTime();
            return helper.MapNullable(columnName, propertyGetter, NpgsqlDbType.Date);
        }

        // public static PostgreSQLCopyHelper<TEntity> MapTime<TEntity>( this PostgreSQLCopyHelper<TEntity> helper, string columnName, Func<TEntity, TimeSpan> propertyGetter ) {
        //     return helper.Map( columnName, propertyGetter, NpgsqlDbType.Time );
        // }

        // public static PostgreSQLCopyHelper<TEntity> MapTime<TEntity>( this PostgreSQLCopyHelper<TEntity> helper, string columnName, Func<TEntity, TimeSpan?> propertyGetter ) {
        //     return helper.MapNullable( columnName, propertyGetter, NpgsqlDbType.Time );
        // }

        // public static PostgreSQLCopyHelper<TEntity> MapTimeStamp<TEntity>( this PostgreSQLCopyHelper<TEntity> helper, string columnName, Func<TEntity, LocalDate> propertyGetter ) {
        //     return helper.Map( columnName, propertyGetter, NpgsqlDbType.Date );
        // }

        // public static PostgreSQLCopyHelper<TEntity> MapTimeStamp<TEntity>( this PostgreSQLCopyHelper<TEntity> helper, string columnName, Func<TEntity, LocalDate?> propertyGetter ) {
        //     return helper.MapNullable( columnName, propertyGetter, NpgsqlDbType.Date );
        // }

        public static PostgreSQLCopyHelper<TEntity> MapTimeStamp<TEntity>(this PostgreSQLCopyHelper<TEntity> helper, string columnName, Func<TEntity, LocalDateTime> propertyGetter)
        {
            NodaTimeTypeExtensions.AddUseNodaTime();
            return helper.Map(columnName, propertyGetter, NpgsqlDbType.Timestamp);
        }

        public static PostgreSQLCopyHelper<TEntity> MapTimeStamp<TEntity>(this PostgreSQLCopyHelper<TEntity> helper, string columnName, Func<TEntity, LocalDateTime?> propertyGetter)
        {
            NodaTimeTypeExtensions.AddUseNodaTime();
            return helper.MapNullable(columnName, propertyGetter, NpgsqlDbType.Timestamp);
        }

        public static PostgreSQLCopyHelper<TEntity> MapTimeStampTz<TEntity>(this PostgreSQLCopyHelper<TEntity> helper, string columnName, Func<TEntity, ZonedDateTime> propertyGetter)
        {
            NodaTimeTypeExtensions.AddUseNodaTime();
            return helper.Map(columnName, propertyGetter, NpgsqlDbType.TimestampTz);
        }

        public static PostgreSQLCopyHelper<TEntity> MapTimeStampTz<TEntity>(this PostgreSQLCopyHelper<TEntity> helper, string columnName, Func<TEntity, ZonedDateTime?> propertyGetter)
        {
            NodaTimeTypeExtensions.AddUseNodaTime();
            return helper.MapNullable(columnName, propertyGetter, NpgsqlDbType.TimestampTz);
        }

        public static PostgreSQLCopyHelper<TEntity> MapInterval<TEntity>(this PostgreSQLCopyHelper<TEntity> helper, string columnName, Func<TEntity, Period> propertyGetter)
        {
            NodaTimeTypeExtensions.AddUseNodaTime();
            return helper.Map(columnName, propertyGetter, NpgsqlDbType.Interval);
        }

        // public static PostgreSQLCopyHelper<TEntity> MapInterval<TEntity>(this PostgreSQLCopyHelper<TEntity> helper, string columnName, Func<TEntity, Period?> propertyGetter)
        // {
        //     return helper.MapNullable(columnName, propertyGetter, NpgsqlDbType.Interval);
        // }

        public static PostgreSQLCopyHelper<TEntity> MapTimeTz<TEntity>(this PostgreSQLCopyHelper<TEntity> helper, string columnName, Func<TEntity, OffsetTime> propertyGetter)
        {
            NodaTimeTypeExtensions.AddUseNodaTime();
            return helper.Map(columnName, propertyGetter, NpgsqlDbType.TimeTz);
        }

        public static PostgreSQLCopyHelper<TEntity> MapTimeTz<TEntity>(this PostgreSQLCopyHelper<TEntity> helper, string columnName, Func<TEntity, OffsetTime?> propertyGetter)
        {
            NodaTimeTypeExtensions.AddUseNodaTime();
            return helper.MapNullable(columnName, propertyGetter, NpgsqlDbType.TimeTz);
        }

        // public static PostgreSQLCopyHelper<TEntity> MapTimeTz<TEntity>(this PostgreSQLCopyHelper<TEntity> helper, string columnName, Func<TEntity, DateTime> propertyGetter)
        // {
        //     return helper.Map(columnName, propertyGetter, NpgsqlDbType.TimeTz);
        // }

        // public static PostgreSQLCopyHelper<TEntity> MapTimeTz<TEntity>(this PostgreSQLCopyHelper<TEntity> helper, string columnName, Func<TEntity, DateTime?> propertyGetter)
        // {
        //     return helper.MapNullable(columnName, propertyGetter, NpgsqlDbType.TimeTz);
        // }

        // public static PostgreSQLCopyHelper<TEntity> MapTimeTz<TEntity>(this PostgreSQLCopyHelper<TEntity> helper, string columnName, Func<TEntity, TimeSpan> propertyGetter)
        // {
        //     return helper.Map(columnName, propertyGetter, NpgsqlDbType.TimeTz);
        // }

        // public static PostgreSQLCopyHelper<TEntity> MapTimeTz<TEntity>(this PostgreSQLCopyHelper<TEntity> helper, string columnName, Func<TEntity, TimeSpan?> propertyGetter)
        // {
        //     return helper.MapNullable(columnName, propertyGetter, NpgsqlDbType.TimeTz);
        // }
    }
}
