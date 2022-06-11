using Spread.Data.Seed;

namespace Microsoft.EntityFrameworkCore.Migrations;

public static class MigrationBuilderExtensions
{
    public static void MigrateUsers(this MigrationBuilder migrationBuilder)
    {
        migrationBuilder.InsertData("Users",
                                    new string[]
                                    {
                                        "Id", "UserName", "EMail", "Password", "PasswordHash", "VerificationId", "IsBlocked", "IsActive", "IsDeleted", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy"
                                    },
                                    new object[,]
                                    {
                                        { ConstantIds.User.AdminId, "admin", "admin@spread.com", "123", "2", null, false, true, false, DateTime.Now, null, DateTime.Now, null },
                                    },
                                    schema: "Profile");
    }

    public static void MigrateLookups(this MigrationBuilder migrationBuilder)
    {
        migrationBuilder.InsertData("LookupTypes", 
                                    new string[] 
                                    {
                                        "Id", "Name", "IsActive", "IsDeleted", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy"
                                    }, 
                                    new object[,] 
                                    {
                                        {  ConstantIds.LookupType.CountryId, "Ülke", true, false, DateTime.Now, null, DateTime.Now, null },
                                        {  ConstantIds.LookupType.CityId, "Şehir", true, false, DateTime.Now, null, DateTime.Now, null },
                                        {  ConstantIds.LookupType.CountyId, "İlçe", true, false, DateTime.Now, null, DateTime.Now, null },
                                    }, 
                                    schema: "Main");

        var azId = Guid.NewGuid();

        migrationBuilder.InsertData("Lookups", 
                                    new string[] 
                                    {
                                        "Id", "Name", "TypeId", "ParentId", "IsActive", "IsDeleted", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy"
                                    }, 
                                    new object[,] 
                                    {
                                        {  ConstantIds.Lookup.TurkiyeId, "Türkiye", ConstantIds.LookupType.CountryId, null, true, false, DateTime.Now, null, DateTime.Now, null },
                                        {  Guid.NewGuid(), "Almanya", ConstantIds.LookupType.CountryId, null, true, false, DateTime.Now, null, DateTime.Now, null },
                                        {  Guid.NewGuid(), "Rusya", ConstantIds.LookupType.CountryId, null, true, false, DateTime.Now, null, DateTime.Now, null },
                                        {  Guid.NewGuid(), "Fransa", ConstantIds.LookupType.CountryId, null, true, false, DateTime.Now, null, DateTime.Now, null },
                                        {  azId, "Azerbaycan", ConstantIds.LookupType.CountryId, null, true, false, DateTime.Now, null, DateTime.Now, null },


                                        { ConstantIds.Lookup.AnkaraId, "Ankara", ConstantIds.LookupType.CityId, ConstantIds.Lookup.TurkiyeId, true, false, DateTime.Now, null, DateTime.Now, null },
                                        { Guid.NewGuid(), "İstanbul", ConstantIds.LookupType.CityId, ConstantIds.Lookup.TurkiyeId, true, false, DateTime.Now, null, DateTime.Now, null },
                                        { Guid.NewGuid(), "İzmir", ConstantIds.LookupType.CityId, ConstantIds.Lookup.TurkiyeId, true, false, DateTime.Now, null, DateTime.Now, null },
                                        { Guid.NewGuid(), "Adana", ConstantIds.LookupType.CityId, ConstantIds.Lookup.TurkiyeId, true, false, DateTime.Now, null, DateTime.Now, null },
                                        { Guid.NewGuid(), "Samsun", ConstantIds.LookupType.CityId, ConstantIds.Lookup.TurkiyeId, true, false, DateTime.Now, null, DateTime.Now, null },
                                        { Guid.NewGuid(), "Sivas", ConstantIds.LookupType.CityId, ConstantIds.Lookup.TurkiyeId, true, false, DateTime.Now, null, DateTime.Now, null },

                                        { Guid.NewGuid(), "Bakü", ConstantIds.LookupType.CityId, azId, true, false, DateTime.Now, null, DateTime.Now, null },
                                        { Guid.NewGuid(), "Gence", ConstantIds.LookupType.CityId, azId, true, false, DateTime.Now, null, DateTime.Now, null },
                                        { Guid.NewGuid(), "Şuşa", ConstantIds.LookupType.CityId, azId, true, false, DateTime.Now, null, DateTime.Now, null },
                                    }, 
                                    schema: "Main");
    }
}
