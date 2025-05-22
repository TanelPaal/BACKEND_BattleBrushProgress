namespace App.DAL.EF.DataSeeding;

public static class InitialData
{
    public static readonly (string roleName, Guid? id)[]
        Roles =
        [
            ("admin", null),
        ];
    
    private static readonly Guid RegularUserId = new Guid("11000000-0000-0000-0000-000000000001");
    private static readonly Guid AdminUserId = new Guid("11000000-0000-0000-0000-000000000002");

    public static readonly (string name, string firstName, string lastName, string password, Guid id, string[] roles)[]
        Users =
        [
            ("admin@taltech.ee", "admin", "taltech", "Foo.Bar.1", AdminUserId, ["admin"]),
            ("user@taltech.ee", "user", "taltech", "Foo.Bar.2", RegularUserId, []),
        ];
    
    private static readonly Guid RegularUserPersonId = new Guid("11000000-0000-0000-0000-000000000003");

    public static readonly (string personName, Guid userId, Guid id)[]
        Persons =
        {
            ("Test Person", RegularUserId, RegularUserPersonId),
        };
    
    
    // Define GUIDs explicitly for brands so they can be referenced in other tables
    private static readonly Guid GwBrandId = new Guid("2228c4a4-ecec-4ed0-a002-3746f05c4177");
    private static readonly Guid VallejoBrandId = new Guid("0ccbffd9-5ae2-4d2e-b033-756c24ff67bf");
    private static readonly Guid ArmypainterBrandId = new Guid("860d2163-c35c-4fbe-b428-cd3ef7a09299");

    // Add initial data for Brands with explicit GUIDs
    public static readonly (string brandName, string headquartersLocation, string contactEmail, string contactPhone, Guid id)[]
        Brands =
        [
            ("Games Workshop", "Nottingham, UK", "contact@games-workshop.com", "+44-115-900-4994", GwBrandId),
            ("Vallejo", "Barcelona, Spain", "vallejo@acrylicosvallejo.com", "+34-935-60-0070", VallejoBrandId),
            ("Army Painter", "Randers, Denmark", "info@thearmypainter.com", "+45-7022-0890", ArmypainterBrandId),
        ];

    // Define GUIDs for paint lines
    private static readonly Guid CitadelLineId = new Guid("96562f1a-51fb-440e-a47c-ca8de9f07bf1");
    private static readonly Guid ModelColorLineId = new Guid("a79868a9-a441-4bc8-ad3c-64953ac772f0");
    private static readonly Guid WarpaintsLineId = new Guid("4ad3284b-de35-4d89-8b70-b6277f01c9ce");

    // Add initial data for PaintLines with brand references
    public static readonly (string paintLineName, string description, Guid brandId, Guid id)[]
        PaintLines =
        [
            ("Citadel", "Premium paints designed for Warhammer miniatures", GwBrandId, CitadelLineId),
            ("Model Color", "High-density acrylic colors for brushwork", VallejoBrandId, ModelColorLineId),
            ("Warpaints", "Complete range for miniature painting", ArmypainterBrandId, WarpaintsLineId),
        ];
    
    // Define GUIDs for paint types
    private static readonly Guid AcrylicTypeId = new Guid("5a79a01f-5c97-477d-8236-122c422bbc76");
    private static readonly Guid OilTypeId = new Guid("cd9a0d22-5cac-46c6-99b3-539ba133ed93");
    private static readonly Guid ContrastTypeId = new Guid("9138f172-d527-42e4-96ae-7648ce493802");

    // Add initial data for PaintTypes
    public static readonly (string paintTypeName, string paintTypeDesc, Guid id)[]
        PaintTypes =
        [
            ("Acrylic", "Water-based paint that dries quickly", AcrylicTypeId),
            ("Oil", "Oil-based paint with longer drying time, good for blending", OilTypeId),
            ("Contrast", "Specialized paint that shades and highlights in one coat", ContrastTypeId),
        ];
    
    
    // Define GUIDs for some test paints
    private static readonly Guid AbaddonBlackId = new Guid("11111111-1111-1111-1111-111111111111");
    private static readonly Guid UltramarineBlueId = new Guid("22222222-2222-2222-2222-222222222222");
    private static readonly Guid CerWhId = new Guid("33333333-3333-3333-3333-333333333333");

    public static readonly (string paintName, string hexCode, string upc, Guid brandb, Guid painttype, Guid paintline, Guid? id)[]
        Paints =
        [
            ("Abaddon Black", "000000", "111122223333", GwBrandId, AcrylicTypeId, CitadelLineId, AbaddonBlackId),
            ("Ultramarine Blue", "0047AB", "333344445555", GwBrandId, AcrylicTypeId, CitadelLineId, UltramarineBlueId),
            ("Ceramite White", "ffffff", "444455556666", GwBrandId, AcrylicTypeId, CitadelLineId, CerWhId),
            ("White Scar", "ffffff", "555566667777", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("Averland Sunset", "fbba00", "666677778888", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("Yriel Yellow", "ffda00", "777788889999", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("Flash Gitz Yellow", "ffee00", "888899990000", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("Jokaero Orange", "e6200f", "999900001111", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("Troll Slayer Orange", "eb641b", "000011112222", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("Fire Dragon Bright", "f1844a", "111122223333", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("Mephiston Red", "9b0e05", "222233334444", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("Evil Suns Scarlet", "c00b0c", "333344445555", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("Wild Rider Red", "e21516", "444455556666", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("Khorne Red", "6a0a01", "555566667777", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("Wazdakka Red", "8d0d01", "666677778888", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("Squig Orange", "b04d3e", "777788889999", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("Screamer Pink", "831740", "888899990000", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("Pink Horror", "96325c", "999900001111", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("Emperors Children", "bd3f75", "222233334444", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("Naggaroth Night", "433656", "333344445555", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("Xereus Purple", "4b205c", "444455556666", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("Genestealer Purple", "7c5ca4", "555566667777", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("Deamonette Hide", "696685", "666677778888", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("Warpfiend Grey", "6b6a74", "777788889999", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("Slaneesh Grey", "8e8c97", "888899990000", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("Kantor Blue", "06234f", "999900001111", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("Alatoic Blue", "2e5689", "222233334444", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("Hoeth Blue", "4f7fb5", "333344445555", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("Macragge Blue", "14397a", "444455556666", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("Altdorf Guard Blue", "274b9b", "555566667777", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("Calgar Blue", "456eb5", "666677778888", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("Caledor Sky", "38689c", "777788889999", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("Teclis Blue", "387bbf", "888899990000", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("Lothern Blue", "3ba1d1", "999900001111", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("Thousand Sons Blue", "18abcc", "222233334444", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("Ahriman Blue", "1f8c9c", "333344445555", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("The Fang", "457479", "444455556666", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("Russ Grey", "55768a", "555566667777", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("Fenrisian Grey", "789ebb", "666677778888", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("Stegadon Scale Green", "004261", "777788889999", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("Sotek Green", "056976", "888899990000", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("Temple Guard Blue", "35998e", "999900001111", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("Thunderhawk Blue", "417074", "222233334444", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("Incubi Darkness", "094345", "333344445555", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("Kabalite Green", "008660", "444455556666", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("Sybarite Green", "36a062", "555566667777", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("Caliban Green", "003b1d", "666677778888", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("Warpstone Glow", "257326", "777788889999", GwBrandId, AcrylicTypeId, CitadelLineId, null),
            ("Moot Green", "57aa2d", "888899990000", GwBrandId, AcrylicTypeId, CitadelLineId, null),
        ];
    
    private static readonly Guid StateUnpaitedId = new Guid("10000000-0000-0000-0000-000000000001");
    private static readonly Guid StateBaseCoatedId = new Guid("10000000-0000-0000-0000-000000000002");
    private static readonly Guid StateFullyPaintedId = new Guid("10000000-0000-0000-0000-000000000003");
    
    
    // Add initial data for MiniStates
    public static readonly (string stateName, string stateDesc, Guid id)[]
        MiniStates =
        [
            ("Unpainted", "Model in its raw form, not painted", StateUnpaitedId),
            ("Base Coated", "Model with primary base colors applied", StateBaseCoatedId),
            ("Fully Painted", "Model with complete paint job and details", StateFullyPaintedId),
        ];

    // Define GUIDs for MiniFactions
    private static readonly Guid TyranidId = new Guid("a933fbb8-308e-408b-8a99-a3fe3f695c77");
    private static readonly Guid TauId = new Guid("6a778a7a-6840-4ab3-94fd-55811a583a4a");
    private static readonly Guid OrksId = new Guid("0126efbc-d3d7-4277-94c6-df650d6d271c");
    
    // Add initial data for MiniFactions
    public static readonly (string factionName, string factionDesc, Guid id)[]
        MiniFactions =
        [
            ("Tyranid", "The Tyranids are an extragalactic composite species of hideous, insectoid xenos.", TyranidId),
            ("Tau", "The T'au Empire, also spelled Tau Empire in older Imperial records, is a rapidly expanding, multispecies xenos stellar empire situated within the Imperium of Man's Ultima Segmentum, near the Eastern Fringes of the Milky Way Galaxy.", TauId),
            ("Orks", "The Orks, also called Greenskins, are a savage, warlike, green-skinned species of bestial, asexual humanoids who are spread all across the galaxy.", OrksId),
        ];
    
    // Define GUIDs for MiniManufacturers
    private static readonly Guid ManufacturerGWId = new Guid("ab93d852-6097-48fe-b5e6-5f8666f31dfa");
    
    // Add initial data for MiniManufacturers
    public static readonly (string manufacturerName, string manuHQ, string contactEmail, string contactPhone, Guid id)[]
        MiniManufacturers =
        [
            ("Games Workshop", "Nottingham, UK", "contact@games-workshop.com", "+44-115-900-4994", ManufacturerGWId),
        ];
    
    // Define GUIDs for MiniProperties
    private static readonly Guid PropMetalId = new Guid("a83b1b2a-7749-4ed3-a74b-ba47fe1d0160");
    private static readonly Guid PropPlasticId = new Guid("58fc59d9-fafd-4592-82e3-a2d8262a915c");
    private static readonly Guid PropResinId = new Guid("c5056892-430e-4107-a430-bc3ee3933b87");
    
    // Add initial data for MiniProperties
    public static readonly (string propertyName, string propertyDesc, Guid id)[]
        MiniProperties =
        [
            ("Metal", "Made out of metal", PropMetalId),
            ("Plastic", "Made out of plastic", PropPlasticId),
            ("Resin", "Made out of epoxy resin", PropResinId),
        ];

    private static readonly Guid HTyrantId = new Guid("00000000-0000-0000-0000-000000000001");
    private static readonly Guid TermagantId = new Guid("00000000-0000-0000-0000-000000000002");
    private static readonly Guid CarnifexId = new Guid("00000000-0000-0000-0000-000000000003");
    private static readonly Guid OrkBoyId = new Guid("00000000-0000-0000-0000-000000000004");
    private static readonly Guid NobId = new Guid("00000000-0000-0000-0000-000000000005");
    private static readonly Guid DeffDreadId = new Guid("00000000-0000-0000-0000-000000000006");
    private static readonly Guid FireWarriorId = new Guid("00000000-0000-0000-0000-000000000007");
    private static readonly Guid CrisisSuitId = new Guid("00000000-0000-0000-0000-000000000008");
    private static readonly Guid RiptideId = new Guid("00000000-0000-0000-0000-000000000009");
    
    public static readonly (string miniName, string miniDesc, Guid factionId, Guid manuId, Guid propertyId, Guid id)[]
        Miniature =
        [
            ("Hive Tyrant", "Lorem Ipsum", TyranidId, ManufacturerGWId, PropPlasticId, HTyrantId),
            ("Termagant", "Fast, numerous and expendable infantry", TyranidId, ManufacturerGWId, PropPlasticId, TermagantId),
            ("Carnifex", "Living battering ram, heavily armored", TyranidId, ManufacturerGWId, PropPlasticId, CarnifexId),

            ("Ork Boy", "Brutal close combat infantry", OrksId, ManufacturerGWId, PropPlasticId, OrkBoyId),
            ("Nob", "Larger and stronger Ork leader", OrksId, ManufacturerGWId, PropPlasticId, NobId),
            ("Deff Dread", "Ork walker loaded with brutal melee weapons", OrksId, ManufacturerGWId, PropPlasticId, DeffDreadId),

            ("Fire Warrior", "Mainstay ranged infantry of the Tau Empire", TauId, ManufacturerGWId, PropPlasticId, FireWarriorId),
            ("Crisis Battlesuit", "Versatile elite battlesuit unit", TauId, ManufacturerGWId, PropPlasticId, CrisisSuitId),
            ("Riptide Battlesuit", "Massive battlesuit with heavy weaponry", TauId, ManufacturerGWId, PropPlasticId, RiptideId)
        ];

}
