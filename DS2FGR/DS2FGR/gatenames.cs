using System.Diagnostics;
using System.Text;

namespace FogWallNS
{
    public enum WarpNode
    {
        Lone,
        // game start spawn point
        GameStartSpawnSrc,
        GameStartSpawnDst,
        // warp gates
        NearPursuerBirdEntry,
        NearPursuerGiantMemoryEntrySrc,
        NearPateGiantMemoryEntrySrc,
        GiantLordMemoryEntrySrc,
        NearPursuerGiantMemoryExitDst,
        NearPateGiantMemoryExitDst,
        GiantLordMemoryExitDst,
        //
        NearPursuerBirdExit,
        NearPursuerGiantMemoryEntryDst,
        NearPateGiantMemoryEntryDst,
        GiantLordMemoryEntryDst,
        NearPursuerGiantMemoryExitSrc,
        NearPateGiantMemoryExitSrc,
        GiantLordMemoryExitSrc,
        //
        PirateShipWharf,
        PirateShipBastille,
        //
        DLC1EntranceBaseGame,
        DLC2EntranceBaseGame,
        DLC3EntranceBaseGame,
        DLC1EntranceDLC,
        DLC2EntranceDLC,
        DLC3EntranceDLC,
        //
        SirAlonneArmorDLCEntrySrc,
        SirAlonneArmorDLCEntryDst,
        SirAlonneMemoryExitSrc,
        SirAlonneMemoryExitDst,
        //
        ChasmPortalFromBlackGulchSrc,
        ChasmPortalFromShadedWoodsSrc,
        ChasmPortalFromCastleSrc,
        //
        ChasmPortalFromBlackGulchDst,
        ChasmPortalFromShadedWoodsDst,
        ChasmPortalFromCastleDst,
        //
        ChasmGulchExitWarpSrc,
        ChasmShadedWoodsExitWarpSrc,
        ChasmCastleExitWarpSrc,
        ChasmDarkLurkerExitWarpSrc,
        ChasmGulchExitWarpDst,
        ChasmShadedWoodsExitWarpDst,
        ChasmCastleExitWarpDst,
        ChasmDarkLurkerExitWarpDst,
        //
        IvoryKingFightEndSrc,
        IvoryKingFightEndDst,
        CoffinWarpSrc,
        CoffinWarpDst,
        LudAndZallenExitWarpSrc,
        LudAndZallenExitWarpDst,
        //
        DragonMemoriesCoveSrc,
        DragonMemoriesCoveDst,
        DragonMemoriesMemoryDst,
        DragonMemoriesMemorySrc,
        MemoryOfTheKingCryptSrc,
        MemoryOfTheKingCryptDst,
        MemoryOfTheKingMemoryDst,
        MemoryOfTheKingMemorySrc,
        // Things betwixt
        Tutorial1EntryFront,
        Tutorial1ExitFront,
        Tutorial2EntryFront,
        Tutorial2ExitFront,
        Tutorial3EntryFront,
        Tutorial3ExitFront,
        Tutorial1EntryBack,
        Tutorial1ExitBack,
        Tutorial2EntryBack,
        Tutorial2ExitBack,
        Tutorial3EntryBack,
        Tutorial3ExitBack,
        // Majula
        MajulaToForestOfFallenGiantsFront,
        MajulaToGraveOfSaintsFront,
        MajulaToHuntsmanCopseFront,
        MajulaToRotundaLockstoneFront,
        MajulaToGutterFront,
        MajulaToShadedWoodsFront,
        MajulaToForestOfFallenGiantsBack,
        MajulaToGraveOfSaintsBack,
        MajulaToHuntsmanCopseBack,
        MajulaToRotundaLockstoneBack,
        MajulaToGutterBack,
        MajulaToShadedWoodsBack,
        // Forest of the fallen giants
        LastGiantEntryFront,
        PursuerEntryFront,
        PursuerExitFront,
        ForestOfFallenGiantsBalconyFront,
        ForestOfFallenGiantsToCaleFront,
        ForestOfFallenGiantsAfterFirstBonfireFront,
        ForestOfFallenGiantsFromMajulaFront,
        ForestOfFallenGiantsToPursuerArenaFront,
        LastGiantEntryBack,
        PursuerEntryBack,
        PursuerExitBack,
        ForestOfFallenGiantsBalconyBack,
        ForestOfFallenGiantsToCaleBack,
        ForestOfFallenGiantsAfterFirstBonfireBack,
        ForestOfFallenGiantsFromMajulaBack,
        ForestOfFallenGiantsToPursuerArenaBack,
        // Brightstone cove tseldora
        CongregationEntryFront,
        CongregationExitFront,
        BrightstoneCoveToDoorsOfPharrosFront,
        DukesDearFreyjaEntryFront,
        DukesDearFreyjaExitFront,
        CongregationEntryBack,
        CongregationExitBack,
        BrightstoneCoveToDoorsOfPharrosBack,
        DukesDearFreyjaEntryBack,
        DukesDearFreyjaExitBack,
        // Aldias keep
        GuardianDragonEntryFront,
        GuardianDragonExitFront,
        AldiasKeepEntranceFront,
        GuardianDragonEntryBack,
        GuardianDragonExitBack,
        AldiasKeepEntranceBack,
        // The lost bastille
        GargoylesEntryFront,
        GargoylesExitFront,
        RuinSentinelsEntryFront,
        RuinSentinelsExitFront,
        RuinSentinelsHiddenDoor1ExitFront,
        RuinSentinelsHiddenDoor2ExitFront,
        RuinSentinelsHiddenDoor3ExitFront,
        RuinSentinelsHiddenDoor4ExitFront,
        RuinSentinesUpperExitFront,
        LostBastilleToSinnersRiseFront,
        LostBastilleToShipFromWharfFront,
        LostBastilleToBelfryLunaFront,
        LostSinnerEntryFront,
        LostSinnerExitFront,
        GargoylesEntryBack,
        GargoylesExitBack,
        RuinSentinelsEntryBack,
        RuinSentinelsExitBack,
        RuinSentinelsHiddenDoor1ExitBack,
        RuinSentinelsHiddenDoor2ExitBack,
        RuinSentinelsHiddenDoor3ExitBack,
        RuinSentinelsHiddenDoor4ExitBack,
        RuinSentinesUpperExitBack,
        LostBastilleToSinnersRiseBack,
        LostBastilleToShipFromWharfBack,
        LostBastilleToBelfryLunaBack,
        LostSinnerEntryBack,
        LostSinnerExitBack,
        // Harvest valley and earthen peak
        CovetousDemonEntryFront,
        CovetousDemonExitFront,
        EarthenPeakNearWindmillBurnLocationFront,
        MythaEntryFront,
        MythaExitFront,
        HarvestValleyToSkeletonLordsFront,
        CovetousDemonEntryBack,
        CovetousDemonExitBack,
        EarthenPeakNearWindmillBurnLocationBack,
        MythaEntryBack,
        MythaExitBack,
        HarvestValleyToSkeletonLordsBack,
        // No mans wharf
        FlexileSentryEntryFront,
        FlexileSentryExitFront,
        NoMansWharfToHeidesFront,
        FlexileSentryEntryBack,
        FlexileSentryExitBack,
        NoMansWharfToHeidesBack,
        // Iron keep
        SmeltorDemonEntryFront,
        SmeltorDemonExitFront,
        BelfrySolEntryFront,
        BelfrySolExitFront,
        IronKeepNearFlameThrowerAndTurtleFront,
        OldIronKingEntryFront,
        OldIronKingExitFront,
        SmeltorDemonToBonfireFront,
        IronKeepToBelfryAtPharrosLockstoneFront,
        IronKeepToEarthenPeakFront,
        SmeltorDemonEntryBack,
        SmeltorDemonExitBack,
        BelfrySolEntryBack,
        BelfrySolExitBack,
        IronKeepNearFlameThrowerAndTurtleBack,
        OldIronKingEntryBack,
        OldIronKingExitBack,
        SmeltorDemonToBonfireBack,
        IronKeepToBelfryAtPharrosLockstoneBack,
        IronKeepToEarthenPeakBack,
        // Huntsman Copse
        SkeletonLordsEntryFront,
        SkeletonLordsExitFront,
        ChariotEntryFront,
        ChariotExitFront,
        HuntsmanCopseToMajulaFront,
        SkeletonLordsEntryBack,
        SkeletonLordsExitBack,
        ChariotEntryBack,
        ChariotExitBack,
        HuntsmanCopseToMajulaBack,
        // The gutter and black gulch
        GutterNearAntQueenFront,
        TheRottenEntryFront,
        TheRottenExitFront,
        BlackGulchEntranceFront,
        TheGutterFromGraveOfSaintsFront,
        GutterNearAntQueenBack,
        TheRottenEntryBack,
        TheRottenExitBack,
        BlackGulchEntranceBack,
        TheGutterFromGraveOfSaintsBack,
        // Dragon aerie
        DragonAerieToAldiasKeepFront,
        AncientDragonFront,
        DragonAerieToAldiasKeepBack,
        AncientDragonBack,
        // Shaded woods -> Majula
        ShadedWoodsFromMajulaFront,
        ShadedWoodsFromMajulaBack,
        // Heides tower of flame
        DragonriderEntryFront,
        DragonriderExitFront,
        OldDragonslayerEntryFront,
        OldDragonslayerExitFront,
        HeidesToMajulaFront,
        HeidesToWharfFront,
        DragonriderEntryBack,
        DragonriderExitBack,
        OldDragonslayerEntryBack,
        OldDragonslayerExitBack,
        HeidesToMajulaBack,
        HeidesToWharfBack,
        // Shaded woods -> Shrine of winter
        ScorpionessNajkaEntryFront,
        ScorpionessNajkaExitFront,
        ShadedWoodsToMistyAreaFront,
        ScorpionessNajkaEntryBack,
        ScorpionessNajkaExitBack,
        ShadedWoodsToMistyAreaBack,
        // Door of pharros
        RoyalRatAuthorityEntryFront,
        RoyalRatAuthorityExitFront,
        DoorOfPharrosToRatKingDomainFront,
        DoorOfPharrosToOrdealEndBonfireFront,
        RoyalRatAuthorityEntryBack,
        RoyalRatAuthorityExitBack,
        DoorOfPharrosToRatKingDomainBack,
        DoorOfPharrosToOrdealEndBonfireBack,
        // Grave of saints
        GraveOfSaintsFromPitFront,
        RoyalRatVanguardEntryFront,
        RoyalRatVanguardExitFront,
        GraveOfSaintsNearUpperBonfireFront,
        GraveOfSaintsFromPitBack,
        RoyalRatVanguardEntryBack,
        RoyalRatVanguardExitBack,
        GraveOfSaintsNearUpperBonfireBack,
        // Memory of vammarBack, orro and jeigh
        GiantLordEntryFront,
        GiantLordExitFront,
        GiantLordEntryBack,
        GiantLordExitBack,
        // Shrine of amana
        DemonOfSongEntryFront,
        DemonOfSongExitFront,
        ShrineOfAmanaTo2ndBonfireFront,
        ShrineOfAmanaTo3rdBonfireFront,
        ShrineOfAmanaToDrangleicCastleFront,
        DemonOfSongEntryBack,
        DemonOfSongExitBack,
        ShrineOfAmanaTo2ndBonfireBack,
        ShrineOfAmanaTo3rdBonfireBack,
        ShrineOfAmanaToDrangleicCastleBack,
        // Drangleic castle
        LookingGlassKnightEntryFront,
        LookingGlassKnightExitFront,
        TwinDragonridersEntryFront,
        TwinDragonridersExitFront,
        FinalFightArenaFront,
        DrangleicCastleToChasmPortalFront,
        DrangleicCastleToShadedWoodsFront,
        LookingGlassKnightEntryBack,
        LookingGlassKnightExitBack,
        TwinDragonridersEntryBack,
        TwinDragonridersExitBack,
        FinalFightArenaBack,
        DrangleicCastleToChasmPortalBack,
        DrangleicCastleToShadedWoodsBack,
        // Undead Crypt
        VelsdatEntryFront,
        VelsdatExitFront,
        VendrickFront,
        UndeadCryptToShrineOfAmanaFront,
        UndeadCryptFromAgdayneToBonfireFront,
        VelsdatEntryBack,
        VelsdatExitBack,
        VendrickBack,
        UndeadCryptToShrineOfAmanaBack,
        UndeadCryptFromAgdayneToBonfireBack,
        // Dark chasm of old
        DarkChasmFromBlackGulchExitFront,
        DarkChasmFromDrangleicCastleExitFront,
        DarkChasmFromShadedWoodsExitFront,
        DarkLurkerExitFront,
        DarkChasmFromBlackGulchExitBack,
        DarkChasmFromDrangleicCastleExitBack,
        DarkChasmFromShadedWoodsExitBack,
        DarkLurkerExitBack,
        // Shulva sanctum city
        SihnTheSlumberingDragonEntryFront,
        ElanaTheSqualidQueenEntryFront,
        GankSquadBossEntryFront,
        GankSquadBossExitFront,
        ShulvaToGankFight1Front,
        ShulvaToGankFight2Front,
        BetweenElanaAndSihnFront,
        NearJesterThomasFront,
        ShulvaEntranceFront,
        SihnTheSlumberingDragonEntryBack,
        ElanaTheSqualidQueenEntryBack,
        GankSquadBossEntryBack,
        GankSquadBossExitBack,
        ShulvaToGankFight1Back,
        ShulvaToGankFight2Back,
        BetweenElanaAndSihnBack,
        NearJesterThomasBack,
        ShulvaEntranceBack,
        // Brume Tower
        BrumeTowerFrom2ndBonfireToCentralRoomFront,
        BrumeTowerToFoyerBonfireFromOutsideFront,
        BrumeTowerToScorchingIronSceptorKeyFront,
        SirAlonneEntryFront,
        SirAlonneExitFront,
        FumeKnightEntryFront,
        FumeKnightExitFront,
        BlueSmeltorDemonEntryFront,
        BlueSmeltorDemonExitFront,
        BrumeTowerEntranceFromLiftFront,
        BrumeTowerToBlueSmelterDungeonFront,
        BrumeTowerFrom2ndBonfireToCentralRoomBack,
        BrumeTowerToFoyerBonfireFromOutsideBack,
        BrumeTowerToScorchingIronSceptorKeyBack,
        SirAlonneEntryBack,
        SirAlonneExitBack,
        FumeKnightEntryBack,
        FumeKnightExitBack,
        BlueSmeltorDemonEntryBack,
        BlueSmeltorDemonExitBack,
        BrumeTowerEntranceFromLiftBack,
        BrumeTowerToBlueSmelterDungeonBack,
        // Frozen eleum loyce
        AavaTheKingsPetEntryFront,
        AavaTheKingsPetExitFront,
        LudAndZallenEntryFront,
        LudAndZallenExitFront,
        IvoryKingFront,
        EleumLoyceAfterGettingEyeToSeeGhostsFront,
        EleumLoyceCathedraEntranceFront,
        AavaTheKingsPetEntryBack,
        AavaTheKingsPetExitBack,
        LudAndZallenEntryBack,
        LudAndZallenExitBack,
        IvoryKingBack,
        EleumLoyceAfterGettingEyeToSeeGhostsBack,
        EleumLoyceCathedraEntranceBack,
        Count,
    }

    public enum SegmentName
    {
        Majula,
        Tutorial1,
        Tutorial2,
        Tutorial3,
        RotundaLockstone,
        FelkinsHole,
        MajulaToForestLever,
        ForestOfFallenGiantsFirstSegment,
        MelentiasHome,
        PatesHome,
        Pursuer,
        BeforePursuer,
        LastGiant,
        GraveOfSaints,
        LowerGraveOfSaints,
        GraveOfSaintsBonfire,
        RoyalRatVanguard,
        BenhartsPickle,
        BrightstoneArmyCamp,
        Congregation,
        BeforeFejya,
        DukesDearFrejya,
        FrejyaPrimalBonfire,
        DoorsOfPharros,
        ShrineOfWinter,
        NavlaansPrison,
        GuardianDragon,
        AfterGuardianDragon,
        BelfryLuna,
        Gargoyles,
        RuinSentinels,
        LostSinner,
        McDuffsWorkshop,
        RuinSentinelsHidden1,
        RuinSentinelsHidden2,
        RuinSentinelsHidden3,
        RuinSentinelsHidden4,
        LostBastilleShip,
        SinnersRise,
        LostBastilleDragonTooth,
    }

    public enum Cond
    {
        None,
        OneWay,
        FragrantBranchOfYore,
        RotundaLockstone,
        SoldiersKey,
        KingsRing,
        KingsRingFragrantBranch,
        KingsRingFirstFourSouls,
        FirstFourSouls,
        Catring,
        AshenMistHeart,
        AshenMistHeartSoldiersKey,
        AshenMistHeartSoldiersKeyKingsRing,
        AshenMistHeartKingMemory,
        OldKeyInBastille,
        BastilleKey,
        PharrosLockstone,
        ScorchingIronSceptor,
        ActivateBrumeTower,
        DarkCovenentJoined,
        DarkCovenentJoinedForgottenKey,
        ForgottenKey,
        DLC1Key,
        DLC2Key,
        DLC3Key,
        ShulvaSanctumKey,
        ActivateDragonStone,
        DLC3Eye,
        DLC3Unfreezed,
        DropDownPath,
        FrigidOutskirtsKey,
        ShipBellRang,
        IronKeyToFireLizards,
        DragonStone,
        BossKilled,
        LudAndZallenDead,
    }

    [DebuggerDisplay("{n1} <-> {n2}")]
    public class Connection
    {
        public WarpNode n1;
        public WarpNode n2;
        public Cond condition_n1;
        public Cond condition_n2;

        public Connection(WarpNode node1, WarpNode node2, Cond n1 = Cond.None,
            Cond n2 = Cond.None)
        {
            this.n1 = node1;
            this.n2 = node2;
            condition_n1 = n1;
            condition_n2 = n2;
        }

        public bool Contains(Connection other)
        {
            if (n1 == other.n1 || n2 == other.n1 || n1 == other.n2 || n2 == other.n2) return true;
            return false;
        }
    }

    public struct KeyCond
    {
        public Cond cond;
        public List<Cond> prereqs;
        public List<WarpNode> access_nodes;
        public bool all_nodes_required = false;

        public KeyCond(Cond cond, WarpNode n1)
        {
            this.cond = cond;
            access_nodes = new() { n1 };
            prereqs = new(0);
        }

        public KeyCond(Cond cond, WarpNode n1, WarpNode n2)
        {
            this.cond = cond;
            access_nodes = new() { n1, n2 };
            prereqs = new(0);
        }

        public KeyCond(Cond cond, Cond n1, WarpNode n2)
        {
            this.cond = cond;
            access_nodes = new() { n2 };
            prereqs = new() { n1 };
        }

        public KeyCond(Cond cond, List<WarpNode> nodes, bool all = false)
        {
            this.cond = cond;
            access_nodes = nodes;
            prereqs = new(0);
            all_nodes_required = all;
        }
        public KeyCond(Cond cond, List<WarpNode> nodes, List<Cond> prereqs)
        {
            this.cond = cond;
            access_nodes = nodes;
            this.prereqs = prereqs;
        }

        public KeyCond(Cond cond, Cond prereq1, Cond prereq2)
        {
            this.cond = cond;
            prereqs = new() { prereq1, prereq2 };
            access_nodes = new(0);
        }
    }

    public static class KeyInfo
    {
        public static IReadOnlyList<Cond> consumable_keys = new List<Cond>() 
        { 
            Cond.FragrantBranchOfYore,
            Cond.PharrosLockstone
        };
    }

    public static class GateConnections
    {
        public static IReadOnlyList<Connection> items { get; } = new List<Connection> {
            // start connections
            new(WarpNode.GameStartSpawnDst, WarpNode.Tutorial1EntryFront, n1:Cond.OneWay),
            new(WarpNode.GameStartSpawnDst, WarpNode.Tutorial2EntryFront, n1:Cond.OneWay),
            new(WarpNode.GameStartSpawnDst, WarpNode.Tutorial3EntryFront, n1:Cond.OneWay, n2: Cond.FragrantBranchOfYore),
            new(WarpNode.GameStartSpawnDst, WarpNode.MajulaToForestOfFallenGiantsFront, n1:Cond.OneWay),
            new(WarpNode.GameStartSpawnDst, WarpNode.MajulaToShadedWoodsFront, n1:Cond.OneWay),
            new(WarpNode.GameStartSpawnDst, WarpNode.MajulaToGraveOfSaintsFront, n1:Cond.OneWay, n2: Cond.Catring),
            new(WarpNode.GameStartSpawnDst, WarpNode.MajulaToGutterFront, n1:Cond.OneWay, n2: Cond.Catring),
            new(WarpNode.GameStartSpawnDst, WarpNode.MajulaToRotundaLockstoneFront, n1:Cond.OneWay),

            // things betwixt
            new(WarpNode.Tutorial1EntryFront, WarpNode.Tutorial2EntryFront),
            new(WarpNode.Tutorial1EntryFront, WarpNode.Tutorial3EntryFront, n2: Cond.FragrantBranchOfYore),
            new(WarpNode.Tutorial1EntryFront, WarpNode.Tutorial1ExitBack,   n2: Cond.OneWay),
            new(WarpNode.Tutorial1EntryFront, WarpNode.Tutorial2ExitBack,   n2: Cond.OneWay),
            new(WarpNode.Tutorial1EntryFront, WarpNode.Tutorial3ExitBack,   n2: Cond.OneWay),
            new(WarpNode.Tutorial1EntryFront, WarpNode.MajulaToForestOfFallenGiantsFront),
            new(WarpNode.Tutorial1EntryFront, WarpNode.MajulaToGraveOfSaintsFront, n1: Cond.OneWay, n2: Cond.Catring),
            new(WarpNode.Tutorial1EntryFront, WarpNode.MajulaToGutterFront, n1: Cond.OneWay, n2: Cond.Catring),
            new(WarpNode.Tutorial1EntryFront, WarpNode.MajulaToShadedWoodsFront),
            new(WarpNode.Tutorial1EntryFront, WarpNode.MajulaToRotundaLockstoneFront),

            new(WarpNode.Tutorial2EntryFront, WarpNode.Tutorial3EntryFront, n2: Cond.FragrantBranchOfYore),
            new(WarpNode.Tutorial2EntryFront, WarpNode.Tutorial1ExitBack,   n2: Cond.OneWay),
            new(WarpNode.Tutorial2EntryFront, WarpNode.Tutorial2ExitBack,   n2: Cond.OneWay),
            new(WarpNode.Tutorial2EntryFront, WarpNode.Tutorial3ExitBack,   n2: Cond.OneWay),
            new(WarpNode.Tutorial2EntryFront, WarpNode.MajulaToForestOfFallenGiantsFront),
            new(WarpNode.Tutorial2EntryFront, WarpNode.MajulaToGraveOfSaintsFront, n1: Cond.OneWay, n2: Cond.Catring),
            new(WarpNode.Tutorial2EntryFront, WarpNode.MajulaToGutterFront, n1: Cond.OneWay, n2: Cond.Catring),
            new(WarpNode.Tutorial2EntryFront, WarpNode.MajulaToShadedWoodsFront),
            new(WarpNode.Tutorial2EntryFront, WarpNode.MajulaToRotundaLockstoneFront),

            new(WarpNode.Tutorial3EntryFront, WarpNode.Tutorial1ExitBack,   n1: Cond.FragrantBranchOfYore, n2: Cond.OneWay),
            new(WarpNode.Tutorial3EntryFront, WarpNode.Tutorial2ExitBack,   n1: Cond.FragrantBranchOfYore, n2: Cond.OneWay),
            new(WarpNode.Tutorial3EntryFront, WarpNode.Tutorial3ExitBack,   n1: Cond.FragrantBranchOfYore, n2: Cond.OneWay),
            new(WarpNode.Tutorial3EntryFront, WarpNode.MajulaToForestOfFallenGiantsFront, n1: Cond.FragrantBranchOfYore),
            new(WarpNode.Tutorial3EntryFront, WarpNode.MajulaToGraveOfSaintsFront, n1: Cond.OneWay, n2: Cond.Catring),
            new(WarpNode.Tutorial3EntryFront, WarpNode.MajulaToGutterFront, n1: Cond.OneWay, n2: Cond.Catring),
            new(WarpNode.Tutorial3EntryFront, WarpNode.MajulaToShadedWoodsFront, n1: Cond.FragrantBranchOfYore),
            new(WarpNode.Tutorial3EntryFront, WarpNode.MajulaToRotundaLockstoneFront, n1: Cond.FragrantBranchOfYore),

            new(WarpNode.Tutorial1ExitBack, WarpNode.MajulaToForestOfFallenGiantsFront, n1: Cond.OneWay),
            new(WarpNode.Tutorial1ExitBack, WarpNode.MajulaToGraveOfSaintsFront, n1: Cond.OneWay, n2: Cond.Catring),
            new(WarpNode.Tutorial1ExitBack, WarpNode.MajulaToGutterFront, n1: Cond.OneWay, n2: Cond.Catring),
            new(WarpNode.Tutorial1ExitBack, WarpNode.MajulaToShadedWoodsFront, n1: Cond.OneWay),
            new(WarpNode.Tutorial1ExitBack, WarpNode.MajulaToRotundaLockstoneFront, n1: Cond.OneWay),

            new(WarpNode.Tutorial2ExitBack, WarpNode.MajulaToForestOfFallenGiantsFront, n1: Cond.OneWay),
            new(WarpNode.Tutorial2ExitBack, WarpNode.MajulaToGraveOfSaintsFront, n1: Cond.OneWay, n2: Cond.Catring),
            new(WarpNode.Tutorial2ExitBack, WarpNode.MajulaToGutterFront, n1: Cond.OneWay, n2: Cond.Catring),
            new(WarpNode.Tutorial2ExitBack, WarpNode.MajulaToShadedWoodsFront, n1: Cond.OneWay),
            new(WarpNode.Tutorial2ExitBack, WarpNode.MajulaToRotundaLockstoneFront, n1: Cond.OneWay),

            new(WarpNode.Tutorial3ExitBack, WarpNode.MajulaToForestOfFallenGiantsFront, n1: Cond.OneWay),
            new(WarpNode.Tutorial3ExitBack, WarpNode.MajulaToGraveOfSaintsFront, n1: Cond.OneWay, n2: Cond.Catring),
            new(WarpNode.Tutorial3ExitBack, WarpNode.MajulaToGutterFront, n1: Cond.OneWay, n2: Cond.Catring),
            new(WarpNode.Tutorial3ExitBack, WarpNode.MajulaToShadedWoodsFront, n1: Cond.OneWay),
            new(WarpNode.Tutorial3ExitBack, WarpNode.MajulaToRotundaLockstoneFront, n1: Cond.OneWay),

            new(WarpNode.MajulaToForestOfFallenGiantsFront, WarpNode.MajulaToGraveOfSaintsFront, n1: Cond.OneWay, n2: Cond.Catring),
            new(WarpNode.MajulaToForestOfFallenGiantsFront, WarpNode.MajulaToGutterFront, n1: Cond.OneWay, n2: Cond.Catring),
            new(WarpNode.MajulaToForestOfFallenGiantsFront, WarpNode.MajulaToShadedWoodsFront),
            new(WarpNode.MajulaToForestOfFallenGiantsFront, WarpNode.MajulaToRotundaLockstoneFront),

            new(WarpNode.MajulaToGraveOfSaintsFront, WarpNode.MajulaToGutterFront, n1: Cond.OneWay),
            new(WarpNode.MajulaToGraveOfSaintsFront, WarpNode.MajulaToShadedWoodsFront, n1: Cond.Catring, n2: Cond.OneWay),
            new(WarpNode.MajulaToGraveOfSaintsFront, WarpNode.MajulaToRotundaLockstoneFront, n1: Cond.Catring, n2: Cond.OneWay),

            new(WarpNode.MajulaToGutterFront, WarpNode.MajulaToShadedWoodsFront, n1: Cond.Catring, n2: Cond.OneWay),
            new(WarpNode.MajulaToGutterFront, WarpNode.MajulaToRotundaLockstoneFront, n1: Cond.Catring, n2: Cond.OneWay),

            new(WarpNode.MajulaToShadedWoodsFront, WarpNode.MajulaToRotundaLockstoneFront),

            new(WarpNode.Tutorial1EntryBack, WarpNode.Tutorial1ExitFront),
            new(WarpNode.Tutorial2EntryBack, WarpNode.Tutorial2ExitFront, n1: Cond.OneWay),
            new(WarpNode.Tutorial3ExitFront, WarpNode.Tutorial3EntryBack, n2: Cond.OneWay),


            // Forest of the fallen giants
            new(WarpNode.MajulaToForestOfFallenGiantsBack, WarpNode.ForestOfFallenGiantsFromMajulaFront),
            new(WarpNode.ForestOfFallenGiantsFromMajulaBack, WarpNode.ForestOfFallenGiantsAfterFirstBonfireFront),

            new(WarpNode.NearPateGiantMemoryEntryDst, WarpNode.NearPateGiantMemoryExitSrc),
            new(WarpNode.NearPursuerGiantMemoryEntryDst, WarpNode.NearPursuerGiantMemoryExitSrc),

            // TODO: add logic for iron key?
            new(WarpNode.ForestOfFallenGiantsAfterFirstBonfireBack, WarpNode.ForestOfFallenGiantsToCaleFront, n1: Cond.DropDownPath),
            //new(WarpNode.ForestOfFallenGiantsAfterFirstBonfireBack, WarpNode.ForestOfFallenGiantsBalconyBack, n1: Cond.OneWay),
            new(WarpNode.ForestOfFallenGiantsAfterFirstBonfireBack, WarpNode.GiantLordMemoryEntrySrc, n2: Cond.AshenMistHeartSoldiersKeyKingsRing),

            new(WarpNode.GiantLordMemoryExitDst, WarpNode.GiantLordMemoryEntrySrc, n1: Cond.OneWay),

            new(WarpNode.ForestOfFallenGiantsToCaleFront, WarpNode.ForestOfFallenGiantsBalconyBack, n2: Cond.OneWay),
            new(WarpNode.ForestOfFallenGiantsToCaleFront, WarpNode.LastGiantEntryFront, n2: Cond.OneWay),
            new(WarpNode.ForestOfFallenGiantsToCaleFront, WarpNode.GiantLordMemoryEntrySrc, n2: Cond.AshenMistHeartSoldiersKeyKingsRing),

            new(WarpNode.ForestOfFallenGiantsBalconyBack, WarpNode.LastGiantEntryFront),
            new(WarpNode.ForestOfFallenGiantsBalconyBack, WarpNode.GiantLordMemoryEntrySrc, n1: Cond.OneWay, n2: Cond.AshenMistHeartSoldiersKeyKingsRing),

            new(WarpNode.LastGiantEntryBack, WarpNode.Lone),

            new(WarpNode.ForestOfFallenGiantsToCaleBack, WarpNode.ForestOfFallenGiantsBalconyFront),
            new(WarpNode.ForestOfFallenGiantsToCaleBack, WarpNode.ForestOfFallenGiantsToPursuerArenaFront, n1: Cond.OneWay, n2: Cond.SoldiersKey),
            new(WarpNode.ForestOfFallenGiantsToCaleBack, WarpNode.PursuerExitBack, n2: Cond.OneWay),
            new(WarpNode.ForestOfFallenGiantsToCaleBack, WarpNode.NearPursuerGiantMemoryEntrySrc, n2: Cond.OneWay),
            new(WarpNode.ForestOfFallenGiantsToCaleBack, WarpNode.NearPateGiantMemoryEntrySrc, n2: Cond.AshenMistHeart),

            new(WarpNode.NearPateGiantMemoryExitDst, WarpNode.NearPateGiantMemoryEntrySrc, n1:Cond.OneWay),

            new(WarpNode.NearPursuerGiantMemoryExitDst, WarpNode.NearPursuerGiantMemoryEntrySrc, n1:Cond.OneWay),

            new(WarpNode.ForestOfFallenGiantsBalconyFront, WarpNode.ForestOfFallenGiantsToPursuerArenaFront, n1: Cond.OneWay, n2: Cond.SoldiersKey),
            new(WarpNode.ForestOfFallenGiantsBalconyFront, WarpNode.PursuerExitBack, n2: Cond.OneWay),
            new(WarpNode.ForestOfFallenGiantsBalconyFront, WarpNode.NearPursuerGiantMemoryEntrySrc, n2: Cond.OneWay),
            new(WarpNode.ForestOfFallenGiantsBalconyFront, WarpNode.NearPateGiantMemoryEntrySrc, n2: Cond.AshenMistHeart),

            new(WarpNode.ForestOfFallenGiantsToPursuerArenaFront, WarpNode.PursuerExitBack, n1:Cond.SoldiersKey, n2: Cond.OneWay),
            new(WarpNode.ForestOfFallenGiantsToPursuerArenaFront, WarpNode.NearPursuerGiantMemoryEntrySrc, n1: Cond.SoldiersKey, n2: Cond.OneWay),
            new(WarpNode.ForestOfFallenGiantsToPursuerArenaFront, WarpNode.NearPateGiantMemoryEntrySrc, n1: Cond.SoldiersKey, n2: Cond.OneWay),

            new(WarpNode.PursuerExitBack, WarpNode.NearPursuerGiantMemoryEntrySrc, n2: Cond.AshenMistHeart),
            new(WarpNode.PursuerExitBack, WarpNode.NearPateGiantMemoryEntrySrc, n1: Cond.OneWay, n2: Cond.AshenMistHeart),
            new(WarpNode.PursuerExitBack, WarpNode.NearPursuerBirdEntry, n1: Cond.OneWay),

            new(WarpNode.NearPursuerGiantMemoryEntrySrc, WarpNode.NearPateGiantMemoryEntrySrc, n1: Cond.OneWay, n2: Cond.AshenMistHeart),

            new(WarpNode.ForestOfFallenGiantsToPursuerArenaBack, WarpNode.PursuerEntryFront),

            new(WarpNode.PursuerEntryBack, WarpNode.PursuerExitFront),

            new(WarpNode.GiantLordEntryFront, WarpNode.GiantLordMemoryEntryDst, n2: Cond.OneWay),
            new(WarpNode.GiantLordEntryBack, WarpNode.GiantLordExitFront),
            new(WarpNode.GiantLordExitBack, WarpNode.GiantLordMemoryExitSrc),

            // lost bastille
            new(WarpNode.NearPursuerBirdExit, WarpNode.RuinSentinelsEntryFront, n2: Cond.FragrantBranchOfYore, n1: Cond.OneWay),

            new(WarpNode.RuinSentinelsEntryFront, WarpNode.LostBastilleToShipFromWharfBack, n2: Cond.OneWay, n1: Cond.FragrantBranchOfYore),
            new(WarpNode.RuinSentinelsEntryFront, WarpNode.RuinSentinesUpperExitBack, n2: Cond.OneWay),

            new(WarpNode.LostBastilleToShipFromWharfBack, WarpNode.LostBastilleToSinnersRiseFront, n1: Cond.OneWay, n2: Cond.OldKeyInBastille),
            new(WarpNode.LostBastilleToShipFromWharfBack, WarpNode.RuinSentinesUpperExitBack, n2: Cond.OneWay),

            new(WarpNode.LostBastilleToSinnersRiseFront, WarpNode.RuinSentinesUpperExitBack, n2: Cond.OneWay),

            new(WarpNode.PirateShipBastille, WarpNode.LostBastilleToShipFromWharfFront, n1: Cond.OneWay),

            new(WarpNode.LostBastilleToSinnersRiseBack, WarpNode.LostSinnerEntryFront, n1: Cond.BastilleKey),
            new(WarpNode.LostSinnerEntryBack, WarpNode.LostSinnerExitFront, n1: Cond.OneWay),
            new(WarpNode.LostSinnerExitBack, WarpNode.Lone),

            new(WarpNode.RuinSentinelsEntryBack, WarpNode.RuinSentinelsHiddenDoor1ExitFront, n1: Cond.OneWay),
            new(WarpNode.RuinSentinelsEntryBack, WarpNode.RuinSentinelsHiddenDoor2ExitFront, n1: Cond.OneWay),
            new(WarpNode.RuinSentinelsEntryBack, WarpNode.RuinSentinelsHiddenDoor3ExitFront, n1: Cond.OneWay),
            new(WarpNode.RuinSentinelsEntryBack, WarpNode.RuinSentinelsHiddenDoor4ExitFront, n1: Cond.OneWay),
            new(WarpNode.RuinSentinelsEntryBack, WarpNode.RuinSentinelsExitFront, n1: Cond.OneWay),

            new(WarpNode.RuinSentinelsHiddenDoor1ExitFront, WarpNode.RuinSentinelsHiddenDoor2ExitFront),
            new(WarpNode.RuinSentinelsHiddenDoor1ExitFront, WarpNode.RuinSentinelsHiddenDoor3ExitFront),
            new(WarpNode.RuinSentinelsHiddenDoor1ExitFront, WarpNode.RuinSentinelsHiddenDoor4ExitFront),
            new(WarpNode.RuinSentinelsHiddenDoor1ExitFront, WarpNode.RuinSentinelsExitFront),
            new(WarpNode.RuinSentinelsHiddenDoor1ExitFront, WarpNode.RuinSentinelsExitBack, n2: Cond.OneWay),

            new(WarpNode.RuinSentinelsHiddenDoor2ExitFront, WarpNode.RuinSentinelsHiddenDoor3ExitFront),
            new(WarpNode.RuinSentinelsHiddenDoor2ExitFront, WarpNode.RuinSentinelsHiddenDoor4ExitFront),
            new(WarpNode.RuinSentinelsHiddenDoor2ExitFront, WarpNode.RuinSentinelsExitFront),
            new(WarpNode.RuinSentinelsHiddenDoor2ExitFront, WarpNode.RuinSentinelsExitBack, n2: Cond.OneWay),

            new(WarpNode.RuinSentinelsHiddenDoor3ExitFront, WarpNode.RuinSentinelsHiddenDoor4ExitFront),
            new(WarpNode.RuinSentinelsHiddenDoor3ExitFront, WarpNode.RuinSentinelsExitFront),
            new(WarpNode.RuinSentinelsHiddenDoor3ExitFront, WarpNode.RuinSentinelsExitBack, n2: Cond.OneWay),

            new(WarpNode.RuinSentinelsHiddenDoor4ExitFront, WarpNode.RuinSentinelsExitFront),
            new(WarpNode.RuinSentinelsHiddenDoor4ExitFront, WarpNode.RuinSentinelsExitBack, n2: Cond.OneWay),

            new(WarpNode.RuinSentinelsExitFront, WarpNode.RuinSentinelsExitBack, n2: Cond.OneWay),

            new(WarpNode.RuinSentinelsHiddenDoor1ExitBack, WarpNode.Lone),
            new(WarpNode.RuinSentinelsHiddenDoor2ExitBack, WarpNode.Lone),
            new(WarpNode.RuinSentinelsHiddenDoor3ExitBack, WarpNode.Lone),
            new(WarpNode.RuinSentinelsHiddenDoor4ExitBack, WarpNode.Lone),

            new(WarpNode.RuinSentinesUpperExitFront, WarpNode.RuinSentinelsHiddenDoor1ExitFront, n1: Cond.OneWay),
            new(WarpNode.RuinSentinesUpperExitFront, WarpNode.RuinSentinelsHiddenDoor2ExitFront, n1: Cond.OneWay),
            new(WarpNode.RuinSentinesUpperExitFront, WarpNode.RuinSentinelsHiddenDoor3ExitFront, n1: Cond.OneWay),
            new(WarpNode.RuinSentinesUpperExitFront, WarpNode.RuinSentinelsHiddenDoor4ExitFront, n1: Cond.OneWay),
            new(WarpNode.RuinSentinesUpperExitFront, WarpNode.RuinSentinelsExitFront, n1: Cond.OneWay),
            new(WarpNode.RuinSentinesUpperExitFront, WarpNode.RuinSentinelsExitBack),

            new(WarpNode.LostBastilleToBelfryLunaFront, WarpNode.RuinSentinesUpperExitBack, n1: Cond.PharrosLockstone),
            new(WarpNode.LostBastilleToBelfryLunaFront, WarpNode.RuinSentinelsEntryFront, n1: Cond.OneWay, n2: Cond.FragrantBranchOfYore),
            new(WarpNode.LostBastilleToBelfryLunaFront, WarpNode.LostBastilleToShipFromWharfBack, n1: Cond.OneWay, n2: Cond.OldKeyInBastille),

            new(WarpNode.LostBastilleToBelfryLunaBack, WarpNode.GargoylesEntryFront),
            new(WarpNode.GargoylesEntryBack, WarpNode.GargoylesExitFront),
            new(WarpNode.GargoylesExitBack, WarpNode.Lone),

            // heides tower of flame
            new(WarpNode.MajulaToRotundaLockstoneBack, WarpNode.MajulaToHuntsmanCopseFront, n1: Cond.OneWay, n2: Cond.RotundaLockstone),
            new(WarpNode.MajulaToRotundaLockstoneBack, WarpNode.HeidesToMajulaFront),

            new(WarpNode.MajulaToHuntsmanCopseFront, WarpNode.HeidesToMajulaFront, n1: Cond.RotundaLockstone, n2: Cond.OneWay),

            new(WarpNode.HeidesToMajulaBack, WarpNode.DragonriderEntryFront),
            new(WarpNode.HeidesToMajulaBack, WarpNode.OldDragonslayerEntryFront, n1: Cond.OneWay),

            new(WarpNode.DragonriderEntryFront, WarpNode.OldDragonslayerEntryFront, n1:Cond.OneWay),

            new(WarpNode.DragonriderEntryBack, WarpNode.DragonriderExitFront),

            new(WarpNode.OldDragonslayerEntryBack, WarpNode.OldDragonslayerExitFront),

            new(WarpNode.OldDragonslayerExitBack, WarpNode.Lone),

            new(WarpNode.DragonriderExitBack, WarpNode.HeidesToWharfFront),
            new(WarpNode.HeidesToWharfBack, WarpNode.NoMansWharfToHeidesFront),

            // no man's wharf
            new(WarpNode.NoMansWharfToHeidesBack, WarpNode.FlexileSentryEntryFront, n1: Cond.ShipBellRang, n2: Cond.ShipBellRang),
            new(WarpNode.FlexileSentryEntryBack, WarpNode.FlexileSentryExitFront, n1: Cond.ShipBellRang, n2: Cond.ShipBellRang), // TODO: what to do here should the ship spawn at wharf??
            new(WarpNode.FlexileSentryExitBack, WarpNode.PirateShipWharf, n1: Cond.OneWay, n2: Cond.ShipBellRang),

            // huntsman copse
            new(WarpNode.MajulaToHuntsmanCopseBack, WarpNode.HuntsmanCopseToMajulaFront),
            new(WarpNode.HuntsmanCopseToMajulaBack, WarpNode.ChariotEntryFront),
            new(WarpNode.HuntsmanCopseToMajulaBack, WarpNode.SkeletonLordsEntryFront, n1: Cond.OneWay),

            new(WarpNode.ChariotEntryFront, WarpNode.SkeletonLordsEntryFront, n1: Cond.OneWay),

            new(WarpNode.ChariotEntryBack, WarpNode.ChariotExitFront),
            new(WarpNode.ChariotExitBack, WarpNode.Lone),

            new(WarpNode.SkeletonLordsEntryBack, WarpNode.SkeletonLordsExitFront),
            new(WarpNode.SkeletonLordsExitBack, WarpNode.HarvestValleyToSkeletonLordsFront, n1: Cond.OneWay),
            // harvest valley
            new(WarpNode.HarvestValleyToSkeletonLordsBack, WarpNode.CovetousDemonEntryFront, n1: Cond.OneWay),
            new(WarpNode.CovetousDemonEntryBack, WarpNode.CovetousDemonExitFront),
            
            // earthen peak
            new(WarpNode.CovetousDemonExitBack, WarpNode.EarthenPeakNearWindmillBurnLocationFront),
            new(WarpNode.CovetousDemonExitBack, WarpNode.EarthenPeakNearWindmillBurnLocationBack),
            new(WarpNode.CovetousDemonExitBack, WarpNode.MythaEntryFront),

            new(WarpNode.EarthenPeakNearWindmillBurnLocationFront, WarpNode.EarthenPeakNearWindmillBurnLocationBack),
            new(WarpNode.EarthenPeakNearWindmillBurnLocationFront, WarpNode.MythaEntryFront),

            new(WarpNode.EarthenPeakNearWindmillBurnLocationBack, WarpNode.MythaEntryFront),

            new(WarpNode.MythaEntryBack, WarpNode.MythaExitFront),
            new(WarpNode.MythaExitBack, WarpNode.IronKeepToEarthenPeakFront),
            // iron keep
            new(WarpNode.IronKeepToEarthenPeakBack, WarpNode.SmeltorDemonEntryFront, n1: Cond.OneWay),
            new(WarpNode.IronKeepToEarthenPeakBack, WarpNode.IronKeepNearFlameThrowerAndTurtleFront, n1: Cond.OneWay),
            new(WarpNode.IronKeepToEarthenPeakBack, WarpNode.IronKeepToBelfryAtPharrosLockstoneFront, n1: Cond.OneWay, n2: Cond.PharrosLockstone),

            new(WarpNode.SmeltorDemonEntryFront, WarpNode.IronKeepNearFlameThrowerAndTurtleFront),
            new(WarpNode.SmeltorDemonEntryFront, WarpNode.IronKeepNearFlameThrowerAndTurtleBack, n1: Cond.OneWay),
            new(WarpNode.SmeltorDemonEntryFront, WarpNode.IronKeepToBelfryAtPharrosLockstoneFront, n2: Cond.PharrosLockstone),

            new(WarpNode.SmeltorDemonEntryBack, WarpNode.SmeltorDemonExitFront),
            new(WarpNode.SmeltorDemonExitBack, WarpNode.SmeltorDemonToBonfireFront),
            new(WarpNode.SmeltorDemonToBonfireBack, WarpNode.IronKeepToBelfryAtPharrosLockstoneFront, n1: Cond.OneWay, n2: Cond.PharrosLockstone),
            new(WarpNode.SmeltorDemonToBonfireBack, WarpNode.IronKeepNearFlameThrowerAndTurtleFront, n1: Cond.OneWay),

            new(WarpNode.IronKeepToBelfryAtPharrosLockstoneBack, WarpNode.BelfrySolEntryFront, n1: Cond.OneWay),
            new(WarpNode.IronKeepToBelfryAtPharrosLockstoneBack, WarpNode.IronKeepNearFlameThrowerAndTurtleFront, n1: Cond.OneWay),
            new(WarpNode.IronKeepToBelfryAtPharrosLockstoneBack, WarpNode.BelfrySolExitBack, n2: Cond.OneWay),
            new(WarpNode.IronKeepToBelfryAtPharrosLockstoneBack, WarpNode.IronKeepToBelfryAtPharrosLockstoneFront, n1: Cond.OneWay, n2: Cond.PharrosLockstone),
            new(WarpNode.IronKeepToBelfryAtPharrosLockstoneBack, WarpNode.SmeltorDemonEntryFront, n1: Cond.OneWay),
            new(WarpNode.BelfrySolEntryBack, WarpNode.BelfrySolExitFront),

            new(WarpNode.BelfrySolExitBack, WarpNode.SmeltorDemonEntryFront, n1: Cond.OneWay),
            new(WarpNode.BelfrySolExitBack, WarpNode.IronKeepNearFlameThrowerAndTurtleFront, n1: Cond.OneWay),
            new(WarpNode.BelfrySolExitBack, WarpNode.IronKeepNearFlameThrowerAndTurtleBack, n1: Cond.OneWay),

            new(WarpNode.IronKeepNearFlameThrowerAndTurtleBack, WarpNode.OldIronKingEntryFront),
            new(WarpNode.OldIronKingEntryBack, WarpNode.OldIronKingExitFront),
            new(WarpNode.OldIronKingExitBack, WarpNode.DLC2EntranceBaseGame),

            new(WarpNode.IronKeepNearFlameThrowerAndTurtleFront, WarpNode.IronKeepToBelfryAtPharrosLockstoneFront, n2: Cond.PharrosLockstone),
            new(WarpNode.IronKeepNearFlameThrowerAndTurtleBack, WarpNode.IronKeepToBelfryAtPharrosLockstoneFront, n2: Cond.OneWay),

            new(WarpNode.OldIronKingEntryFront, WarpNode.IronKeepToBelfryAtPharrosLockstoneFront, n2: Cond.OneWay),
            new(WarpNode.OldIronKingEntryFront, WarpNode.IronKeepToBelfryAtPharrosLockstoneBack, n2: Cond.OneWay),
            new(WarpNode.OldIronKingEntryFront, WarpNode.BelfrySolExitBack, n2: Cond.OneWay),
            // dlc2
            new(WarpNode.DLC2EntranceDLC, WarpNode.BrumeTowerEntranceFromLiftFront, n1: Cond.OneWay, n2: Cond.DLC2Key),
            new(WarpNode.BrumeTowerEntranceFromLiftBack, WarpNode.BrumeTowerFrom2ndBonfireToCentralRoomFront, n1: Cond.OneWay),
            new(WarpNode.BrumeTowerFrom2ndBonfireToCentralRoomBack, WarpNode.BrumeTowerToFoyerBonfireFromOutsideFront, n1: Cond.OneWay),
            new(WarpNode.BrumeTowerToFoyerBonfireFromOutsideBack, WarpNode.BrumeTowerToScorchingIronSceptorKeyFront),
            new(WarpNode.BrumeTowerToScorchingIronSceptorKeyBack, WarpNode.Lone),

            new(WarpNode.BrumeTowerToBlueSmelterDungeonBack, WarpNode.BlueSmeltorDemonEntryFront, n1: Cond.OneWay),
            new(WarpNode.BlueSmeltorDemonEntryBack, WarpNode.BlueSmeltorDemonExitFront),
            new(WarpNode.BlueSmeltorDemonExitBack, WarpNode.BrumeTowerToBlueSmelterDungeonFront, n1: Cond.OneWay),

            new(WarpNode.BrumeTowerToFoyerBonfireFromOutsideBack, WarpNode.BrumeTowerToBlueSmelterDungeonFront, n1: Cond.OneWay, n2: Cond.ScorchingIronSceptor),
            new(WarpNode.BrumeTowerToFoyerBonfireFromOutsideBack, WarpNode.FumeKnightEntryFront, n1: Cond.OneWay, n2: Cond.ScorchingIronSceptor),
            new(WarpNode.BrumeTowerToFoyerBonfireFromOutsideBack, WarpNode.BrumeTowerFrom2ndBonfireToCentralRoomBack, n1: Cond.OneWay, n2: Cond.ScorchingIronSceptor),
            new(WarpNode.BrumeTowerToFoyerBonfireFromOutsideBack, WarpNode.SirAlonneArmorDLCEntrySrc, n1: Cond.OneWay, n2: Cond.ScorchingIronSceptor),

            new(WarpNode.SirAlonneMemoryExitDst, WarpNode.SirAlonneArmorDLCEntrySrc, n1:Cond.OneWay),

            new(WarpNode.BrumeTowerFrom2ndBonfireToCentralRoomBack, WarpNode.SirAlonneArmorDLCEntrySrc, n1: Cond.OneWay, n2: Cond.ActivateBrumeTower),

            new(WarpNode.SirAlonneArmorDLCEntryDst, WarpNode.SirAlonneEntryFront, n1: Cond.OneWay),
            new(WarpNode.SirAlonneEntryBack, WarpNode.SirAlonneExitFront),
            new(WarpNode.SirAlonneExitBack, WarpNode.SirAlonneMemoryExitSrc),

            new(WarpNode.FumeKnightEntryBack, WarpNode.FumeKnightExitFront),
            new(WarpNode.FumeKnightExitBack, WarpNode.Lone),
            
            // grave of saints
            new(WarpNode.MajulaToGraveOfSaintsBack, WarpNode.GraveOfSaintsFromPitFront),
            new(WarpNode.GraveOfSaintsFromPitBack, WarpNode.GraveOfSaintsNearUpperBonfireFront),
            new(WarpNode.GraveOfSaintsNearUpperBonfireBack, WarpNode.RoyalRatVanguardEntryFront),
            new(WarpNode.RoyalRatVanguardEntryBack, WarpNode.RoyalRatVanguardExitFront),
            new(WarpNode.RoyalRatVanguardExitBack, WarpNode.MajulaToGutterBack, n1: Cond.OneWay),
            new(WarpNode.RoyalRatVanguardExitBack, WarpNode.TheGutterFromGraveOfSaintsFront, n1: Cond.OneWay),
            new(WarpNode.MajulaToGutterBack, WarpNode.TheGutterFromGraveOfSaintsFront, n1: Cond.OneWay),
            // gutter
            new(WarpNode.TheGutterFromGraveOfSaintsBack, WarpNode.GutterNearAntQueenFront, n1:Cond.OneWay),
            new(WarpNode.TheGutterFromGraveOfSaintsBack, WarpNode.GutterNearAntQueenBack,  n1:Cond.OneWay),
            new(WarpNode.TheGutterFromGraveOfSaintsBack, WarpNode.BlackGulchEntranceFront,  n1:Cond.OneWay),
            new(WarpNode.GutterNearAntQueenBack, WarpNode.BlackGulchEntranceFront,  n1:Cond.OneWay),
            // black gulch
            new(WarpNode.BlackGulchEntranceBack, WarpNode.TheRottenEntryFront),
            new(WarpNode.BlackGulchEntranceBack, WarpNode.ChasmPortalFromBlackGulchSrc, n1: Cond.OneWay, n2: Cond.DarkCovenentJoinedForgottenKey),
            new(WarpNode.ChasmPortalFromBlackGulchSrc, WarpNode.TheRottenEntryFront, n1: Cond.DarkCovenentJoinedForgottenKey, n2: Cond.OneWay),

            new(WarpNode.ChasmGulchExitWarpDst, WarpNode.ChasmPortalFromBlackGulchSrc, n1:Cond.OneWay),

            new(WarpNode.TheRottenEntryBack, WarpNode.TheRottenExitFront),
            new(WarpNode.TheRottenExitBack, WarpNode.DLC1EntranceBaseGame),
            // dlc1
            new(WarpNode.DLC1EntranceDLC, WarpNode.ShulvaEntranceFront, n1: Cond.DLC1Key, n2: Cond.DLC1Key),
            new(WarpNode.ShulvaEntranceBack, WarpNode.NearJesterThomasFront, n1: Cond.OneWay),
            new(WarpNode.ShulvaEntranceBack, WarpNode.ShulvaToGankFight1Front, n1: Cond.OneWay, n2: Cond.ShulvaSanctumKey),

            new(WarpNode.NearJesterThomasBack, WarpNode.ShulvaEntranceBack, n1: Cond.OneWay),
            new(WarpNode.NearJesterThomasBack, WarpNode.ElanaTheSqualidQueenEntryFront, n1: Cond.OneWay, n2: Cond.ActivateDragonStone),

            new(WarpNode.ElanaTheSqualidQueenEntryBack, WarpNode.BetweenElanaAndSihnFront, n1: Cond.OneWay),
            new(WarpNode.BetweenElanaAndSihnBack, WarpNode.SihnTheSlumberingDragonEntryFront),
            new(WarpNode.SihnTheSlumberingDragonEntryBack, WarpNode.Lone),

            new(WarpNode.ShulvaToGankFight1Back, WarpNode.ShulvaToGankFight2Front),
            new(WarpNode.ShulvaToGankFight2Back, WarpNode.GankSquadBossEntryFront, n1: Cond.OneWay),
            new(WarpNode.GankSquadBossEntryBack, WarpNode.GankSquadBossExitFront),
            new(WarpNode.GankSquadBossExitBack, WarpNode.ShulvaEntranceBack, n1: Cond.OneWay),
            new(WarpNode.GankSquadBossExitBack, WarpNode.NearJesterThomasFront, n1: Cond.OneWay),
            new(WarpNode.GankSquadBossExitBack, WarpNode.ShulvaToGankFight1Front, n1: Cond.OneWay, n2: Cond.ShulvaSanctumKey),
            // shaded woods
            new(WarpNode.MajulaToShadedWoodsBack, WarpNode.ShadedWoodsFromMajulaFront),
            new(WarpNode.ShadedWoodsFromMajulaBack, WarpNode.ShadedWoodsToMistyAreaFront, n1: Cond.OneWay, n2: Cond.FragrantBranchOfYore),
            new(WarpNode.ShadedWoodsFromMajulaBack, WarpNode.AldiasKeepEntranceFront, n1: Cond.OneWay, n2: Cond.KingsRingFragrantBranch),
            new(WarpNode.ShadedWoodsFromMajulaBack, WarpNode.DrangleicCastleToShadedWoodsFront, n1: Cond.OneWay, n2: Cond.FirstFourSouls),
            new(WarpNode.ShadedWoodsFromMajulaBack, WarpNode.DLC3EntranceBaseGame, n1: Cond.OneWay, n2: Cond.FirstFourSouls),

            new(WarpNode.ShadedWoodsToMistyAreaFront, WarpNode.AldiasKeepEntranceFront, n1: Cond.KingsRing, n2: Cond.KingsRing),
            new(WarpNode.ShadedWoodsToMistyAreaFront, WarpNode.DrangleicCastleToShadedWoodsFront, n1: Cond.OneWay, n2: Cond.FirstFourSouls),
            new(WarpNode.ShadedWoodsToMistyAreaFront, WarpNode.DLC3EntranceBaseGame, n1: Cond.OneWay, n2: Cond.FirstFourSouls),

            new(WarpNode.AldiasKeepEntranceFront, WarpNode.DrangleicCastleToShadedWoodsFront, n1: Cond.OneWay, n2: Cond.KingsRingFirstFourSouls), // TODO: test if the shrine of winter opens if approached from behind
            new(WarpNode.AldiasKeepEntranceFront, WarpNode.DLC3EntranceBaseGame, n1: Cond.OneWay, n2: Cond.KingsRingFirstFourSouls),

            new(WarpNode.DrangleicCastleToShadedWoodsFront, WarpNode.DLC3EntranceBaseGame, n1: Cond.OneWay, n2: Cond.FirstFourSouls),

            new(WarpNode.ShadedWoodsToMistyAreaBack, WarpNode.ScorpionessNajkaEntryFront),
            new(WarpNode.ScorpionessNajkaEntryBack, WarpNode.ScorpionessNajkaExitFront),

            new(WarpNode.ScorpionessNajkaExitBack, WarpNode.DoorOfPharrosToRatKingDomainFront),
            new(WarpNode.ScorpionessNajkaExitBack, WarpNode.BrightstoneCoveToDoorsOfPharrosFront),
            new(WarpNode.ScorpionessNajkaExitBack, WarpNode.RoyalRatAuthorityExitBack, n2: Cond.OneWay),

            new(WarpNode.DoorOfPharrosToRatKingDomainFront, WarpNode.BrightstoneCoveToDoorsOfPharrosFront),
            new(WarpNode.DoorOfPharrosToRatKingDomainFront, WarpNode.RoyalRatAuthorityExitBack, n2: Cond.OneWay),

            new(WarpNode.BrightstoneCoveToDoorsOfPharrosFront, WarpNode.RoyalRatAuthorityExitBack, n2: Cond.OneWay),

            new(WarpNode.ChasmPortalFromShadedWoodsSrc, WarpNode.ShadedWoodsToMistyAreaBack, n1: Cond.DarkCovenentJoined),
            new(WarpNode.ChasmPortalFromShadedWoodsSrc, WarpNode.ScorpionessNajkaEntryFront, n1: Cond.DarkCovenentJoined),
            
            new(WarpNode.ChasmShadedWoodsExitWarpDst, WarpNode.ChasmPortalFromShadedWoodsSrc, n1:Cond.OneWay),

            new(WarpNode.RoyalRatAuthorityEntryFront, WarpNode.DoorOfPharrosToOrdealEndBonfireBack),
            new(WarpNode.RoyalRatAuthorityEntryBack, WarpNode.RoyalRatAuthorityExitFront),
            new(WarpNode.DoorOfPharrosToOrdealEndBonfireFront, WarpNode.DoorOfPharrosToRatKingDomainBack),

            // brightstone cove
            new(WarpNode.BrightstoneCoveToDoorsOfPharrosBack, WarpNode.CongregationEntryFront, n1: Cond.OneWay),
            new(WarpNode.CongregationEntryBack, WarpNode.CongregationExitFront),
            new(WarpNode.CongregationExitBack, WarpNode.DukesDearFreyjaEntryFront, n1: Cond.OneWay),
            new(WarpNode.DukesDearFreyjaEntryBack, WarpNode.DukesDearFreyjaExitFront),
            new(WarpNode.DukesDearFreyjaExitBack, WarpNode.Lone),
            new(WarpNode.DukesDearFreyjaEntryBack, WarpNode.DragonMemoriesCoveSrc, n2: Cond.AshenMistHeart),
            new(WarpNode.DukesDearFreyjaExitFront, WarpNode.DragonMemoriesCoveSrc, n2: Cond.AshenMistHeart),
            new(WarpNode.DragonMemoriesMemoryDst, WarpNode.DragonMemoriesMemorySrc, n1: Cond.OneWay),
            new(WarpNode.DragonMemoriesCoveDst, WarpNode.DragonMemoriesCoveSrc, n1:Cond.OneWay),

            // dlc3
            new(WarpNode.DLC3EntranceDLC, WarpNode.AavaTheKingsPetEntryFront, n1: Cond.DLC3Key, n2: Cond.DLC3Key),
            new(WarpNode.DLC3EntranceDLC, WarpNode.EleumLoyceAfterGettingEyeToSeeGhostsFront, n1: Cond.OneWay, n2: Cond.DLC3Key),
            new(WarpNode.AavaTheKingsPetEntryBack, WarpNode.AavaTheKingsPetExitFront, n1: Cond.DLC3Eye, n2: Cond.DLC3Eye),
            new(WarpNode.AavaTheKingsPetExitBack, WarpNode.EleumLoyceCathedraEntranceFront),
            new(WarpNode.EleumLoyceCathedraEntranceBack, WarpNode.IvoryKingFront, n1: Cond.OneWay),
            new(WarpNode.IvoryKingBack, WarpNode.IvoryKingFightEndSrc, n1: Cond.OneWay),
            new(WarpNode.IvoryKingFightEndDst, WarpNode.IvoryKingFront, n1: Cond.OneWay, n2: Cond.DLC3Unfreezed),

            new(WarpNode.EleumLoyceAfterGettingEyeToSeeGhostsBack, WarpNode.DLC3EntranceDLC, n1:Cond.OneWay ,n2: Cond.DLC3Key),
            new(WarpNode.EleumLoyceAfterGettingEyeToSeeGhostsBack, WarpNode.AavaTheKingsPetEntryFront, n1:Cond.OneWay),
            new(WarpNode.EleumLoyceAfterGettingEyeToSeeGhostsBack, WarpNode.EleumLoyceAfterGettingEyeToSeeGhostsFront, n1:Cond.OneWay),
            new(WarpNode.EleumLoyceAfterGettingEyeToSeeGhostsBack, WarpNode.AavaTheKingsPetExitBack, n1:Cond.OneWay, n2: Cond.DLC3Unfreezed),
            new(WarpNode.EleumLoyceAfterGettingEyeToSeeGhostsBack, WarpNode.EleumLoyceCathedraEntranceFront, n1:Cond.OneWay, n2: Cond.DLC3Unfreezed),

            new(WarpNode.CoffinWarpSrc, WarpNode.DLC3EntranceDLC, n1: Cond.FrigidOutskirtsKey, n2: Cond.OneWay),
            new(WarpNode.CoffinWarpSrc, WarpNode.AavaTheKingsPetEntryFront, n1: Cond.FrigidOutskirtsKey, n2: Cond.OneWay),
            new(WarpNode.CoffinWarpDst, WarpNode.LudAndZallenEntryFront, n1: Cond.OneWay),
            new(WarpNode.LudAndZallenEntryBack, WarpNode.LudAndZallenExitFront),
            new(WarpNode.LudAndZallenExitBack, WarpNode.LudAndZallenExitWarpSrc, n1: Cond.OneWay),

            new(WarpNode.LudAndZallenExitWarpDst, WarpNode.CoffinWarpSrc, n1:Cond.OneWay),

            // dranglic castle
            new(WarpNode.DrangleicCastleToShadedWoodsBack, WarpNode.FinalFightArenaFront, n1: Cond.OneWay, n2: Cond.KingsRing),
            new(WarpNode.DrangleicCastleToShadedWoodsBack, WarpNode.TwinDragonridersEntryFront, n1: Cond.OneWay),
            new(WarpNode.DrangleicCastleToShadedWoodsBack, WarpNode.DrangleicCastleToChasmPortalFront, n1: Cond.OneWay),

            new(WarpNode.FinalFightArenaFront, WarpNode.TwinDragonridersEntryFront, n1: Cond.OneWay, n2: Cond.KingsRing),
            new(WarpNode.FinalFightArenaFront, WarpNode.DrangleicCastleToChasmPortalFront, n1: Cond.KingsRing, n2: Cond.KingsRing),

            new(WarpNode.TwinDragonridersEntryFront, WarpNode.DrangleicCastleToChasmPortalFront, n2: Cond.OneWay),

            new(WarpNode.DrangleicCastleToChasmPortalBack, WarpNode.ChasmPortalFromCastleSrc, n1: Cond.OneWay, n2: Cond.DarkCovenentJoined),

            new(WarpNode.ChasmCastleExitWarpDst, WarpNode.ChasmPortalFromCastleSrc, n1:Cond.OneWay),

            new(WarpNode.TwinDragonridersEntryBack, WarpNode.TwinDragonridersExitFront),
            new(WarpNode.TwinDragonridersExitBack, WarpNode.LookingGlassKnightEntryFront, n1: Cond.OneWay),
            new(WarpNode.LookingGlassKnightEntryBack, WarpNode.LookingGlassKnightExitFront),
            new(WarpNode.LookingGlassKnightExitBack, WarpNode.ShrineOfAmanaToDrangleicCastleFront),
            // shrine of amana
            new(WarpNode.ShrineOfAmanaToDrangleicCastleBack, WarpNode.ShrineOfAmanaTo2ndBonfireFront),
            new(WarpNode.ShrineOfAmanaTo2ndBonfireBack, WarpNode.ShrineOfAmanaTo3rdBonfireFront),
            new(WarpNode.ShrineOfAmanaTo3rdBonfireBack, WarpNode.DemonOfSongEntryFront),
            new(WarpNode.DemonOfSongEntryBack, WarpNode.DemonOfSongExitFront),
            new(WarpNode.DemonOfSongExitBack, WarpNode.UndeadCryptToShrineOfAmanaFront, n1: Cond.OneWay),
            // undead crypt
            new(WarpNode.UndeadCryptToShrineOfAmanaBack, WarpNode.UndeadCryptFromAgdayneToBonfireFront),
            new(WarpNode.UndeadCryptToShrineOfAmanaBack, WarpNode.UndeadCryptFromAgdayneToBonfireBack, n2: Cond.DropDownPath),
            new(WarpNode.UndeadCryptToShrineOfAmanaBack, WarpNode.VelsdatEntryFront, n2: Cond.DropDownPath),

            new(WarpNode.UndeadCryptFromAgdayneToBonfireFront, WarpNode.UndeadCryptFromAgdayneToBonfireBack, n2: Cond.DropDownPath),
            new(WarpNode.UndeadCryptFromAgdayneToBonfireFront, WarpNode.VelsdatEntryFront, n2: Cond.DropDownPath),

            new(WarpNode.UndeadCryptFromAgdayneToBonfireBack, WarpNode.VelsdatEntryFront, n1: Cond.DropDownPath),

            new(WarpNode.VelsdatEntryBack, WarpNode.VelsdatExitFront),
            new(WarpNode.VelsdatExitBack, WarpNode.VendrickFront),
            new(WarpNode.VendrickBack, WarpNode.MemoryOfTheKingCryptSrc, n2: Cond.AshenMistHeartKingMemory),
            new(WarpNode.MemoryOfTheKingMemoryDst, WarpNode.MemoryOfTheKingMemorySrc, n1: Cond.OneWay),

            new(WarpNode.MemoryOfTheKingCryptDst, WarpNode.MemoryOfTheKingCryptSrc, n1:Cond.OneWay),

            // dark chasms
            new(WarpNode.ChasmPortalFromBlackGulchDst, WarpNode.DarkChasmFromBlackGulchExitFront, n1: Cond.OneWay),
            new(WarpNode.DarkChasmFromBlackGulchExitBack, WarpNode.ChasmGulchExitWarpSrc, n1: Cond.OneWay),

            new(WarpNode.ChasmPortalFromShadedWoodsDst, WarpNode.DarkChasmFromShadedWoodsExitFront, n1: Cond.OneWay),
            new(WarpNode.DarkChasmFromShadedWoodsExitBack, WarpNode.ChasmShadedWoodsExitWarpSrc, n1: Cond.OneWay),

            new(WarpNode.ChasmPortalFromCastleDst, WarpNode.DarkChasmFromDrangleicCastleExitFront, n1: Cond.OneWay),
            new(WarpNode.DarkChasmFromDrangleicCastleExitBack, WarpNode.ChasmCastleExitWarpSrc, n1: Cond.OneWay),

            new(WarpNode.DarkLurkerExitBack, WarpNode.ChasmDarkLurkerExitWarpSrc, n1: Cond.OneWay),
            new(WarpNode.DarkLurkerExitFront, WarpNode.Lone),
            new(WarpNode.ChasmDarkLurkerExitWarpDst, WarpNode.ChasmPortalFromCastleSrc, n1: Cond.OneWay), // TODO: this is not correct as it depends on where you entered from

            // aldia's keep
            new(WarpNode.AldiasKeepEntranceBack, WarpNode.GuardianDragonEntryFront, n1: Cond.OneWay),
            new(WarpNode.GuardianDragonEntryBack, WarpNode.GuardianDragonExitFront),
            new(WarpNode.GuardianDragonExitBack, WarpNode.DragonAerieToAldiasKeepFront),

            // dragon aerie
            new(WarpNode.DragonAerieToAldiasKeepBack, WarpNode.AncientDragonFront),
            new(WarpNode.AncientDragonBack, WarpNode.Lone),

            // final fight
            new(WarpNode.FinalFightArenaBack, WarpNode.Lone),
        };

        public static IReadOnlyList<KeyCond> key_reqs { get; } = new List<KeyCond> {
            // catring
            //new(Cond.Catring, WarpNode.GameStartSpawnDst), // just farm the souls
            // fragrant branches locations
            new(Cond.FragrantBranchOfYore, WarpNode.LostSinnerExitBack), // in the chest
            new(Cond.FragrantBranchOfYore, WarpNode.SkeletonLordsExitBack), // near gavlan
            new(Cond.FragrantBranchOfYore, WarpNode.GiantLordMemoryEntrySrc), // on a body on the ledge // TODO: it can also be accessed after getting king's ring and soldier's key in FOFG
            new(Cond.FragrantBranchOfYore, WarpNode.NearPursuerBirdExit), // in a chest next to pursuer exit
            new(Cond.FragrantBranchOfYore, WarpNode.TheGutterFromGraveOfSaintsBack), // on a group of corpse
            new(Cond.FragrantBranchOfYore, WarpNode.BlackGulchEntranceFront), // on corpse next to sconce
            new(Cond.FragrantBranchOfYore, WarpNode.VelsdatEntryFront), // in a chest next to fog gate
            new(Cond.FragrantBranchOfYore, WarpNode.AncientDragonFront), // in a chest near the egg
            new(Cond.FragrantBranchOfYore, WarpNode.DukesDearFreyjaExitBack), // in the chest
            new(Cond.FragrantBranchOfYore, WarpNode.ForestOfFallenGiantsAfterFirstBonfireBack), // melentia's shop
            new(Cond.FragrantBranchOfYore, WarpNode.SmeltorDemonEntryFront), // magerold's shop

            new(Cond.RotundaLockstone, WarpNode.DragonriderExitBack), // licia

            new(Cond.SoldiersKey, WarpNode.LastGiantEntryBack),
            new(Cond.KingsRing, WarpNode.VendrickBack),
            new(Cond.KingsRingFragrantBranch, Cond.KingsRing, Cond.FragrantBranchOfYore),
            new(Cond.FirstFourSouls, new List<WarpNode>(){
                WarpNode.LostSinnerEntryBack,
                WarpNode.TheRottenEntryBack,
                WarpNode.DukesDearFreyjaEntryBack,
                WarpNode.OldIronKingEntryBack,
            }),

            new(Cond.KingsRingFirstFourSouls, Cond.KingsRing, Cond.FirstFourSouls),
            new(Cond.Catring, Cond.BossKilled, Cond.BossKilled), // two bosses? killed to buy cat ring
            new(Cond.AshenMistHeart, WarpNode.AncientDragonBack),
            new(Cond.AshenMistHeartSoldiersKey, Cond.AshenMistHeart, Cond.SoldiersKey),
            new(Cond.AshenMistHeartSoldiersKeyKingsRing, Cond.AshenMistHeartSoldiersKey, Cond.KingsRing),
            new(Cond.AshenMistHeartKingMemory, Cond.AshenMistHeart, Cond.KingsRing), // TODO: right now if you reached the king and have ashen mist heart you might have to kill vendrick to proceed
            new(Cond.OldKeyInBastille, WarpNode.NearPursuerBirdExit),
            new(Cond.OldKeyInBastille, WarpNode.RuinSentinesUpperExitBack),
            new(Cond.OldKeyInBastille, WarpNode.LostBastilleToShipFromWharfBack),
            new(Cond.BastilleKey, WarpNode.RuinSentinelsExitBack),
            new(Cond.PharrosLockstone, new List<WarpNode>() {
                WarpNode.ForestOfFallenGiantsToCaleFront, // melentia
                WarpNode.ForestOfFallenGiantsToCaleBack, // cale->house key->majula
                // in the well
                WarpNode.ChariotEntryFront, // below the bridge
                WarpNode.LostBastilleToSinnersRiseBack, // bottom floor left cell
                WarpNode.EarthenPeakNearWindmillBurnLocationFront, // below gilligan
                WarpNode.EarthenPeakNearWindmillBurnLocationBack, // trapped chest near pate's 2nd location
                WarpNode.ShadedWoodsToMistyAreaFront, // on a corpse on the path to ruined forked road bonfire
                WarpNode.SmeltorDemonEntryFront, // upstairs from magerold
                WarpNode.ScorpionessNajkaEntryFront, // near tark
                WarpNode.ShadedWoodsToMistyAreaBack, // up in the ruins next to lion warriors
                WarpNode.DoorOfPharrosToRatKingDomainBack, // up the ladder behind the stairs
                WarpNode.CongregationExitBack, // near ornifex shop
                WarpNode.CongregationExitBack, // before freya in a pot cannot go from bottom
                WarpNode.RoyalRatVanguardExitBack, // near the fountain after rat king
                WarpNode.DrangleicCastleToShadedWoodsBack, // ruin sentinels in drangleic castle room middle left
                WarpNode.AldiasKeepEntranceBack, // behind bookshelf in the bonfire room
                WarpNode.DragonAerieToAldiasKeepBack, // after 2nd dragon below on the ledge requires dropdown
            }),
            new(Cond.ScorchingIronSceptor, WarpNode.BrumeTowerToScorchingIronSceptorKeyBack),
            new(Cond.ActivateBrumeTower, Cond.ScorchingIronSceptor, WarpNode.BrumeTowerToFoyerBonfireFromOutsideBack),
            new(Cond.DarkCovenentJoined, new List<WarpNode>(){
                WarpNode.ScorpionessNajkaEntryFront,
                WarpNode.DrangleicCastleToChasmPortalBack,
                WarpNode.TheRottenEntryFront,
            }, new List<Cond> {
                Cond.ForgottenKey,
            }),
            new(Cond.DarkCovenentJoinedForgottenKey, Cond.DarkCovenentJoined, Cond.ForgottenKey),
            new(Cond.ForgottenKey, WarpNode.TheRottenEntryFront),
            new(Cond.IronKeyToFireLizards, WarpNode.SmeltorDemonEntryFront),
            new(Cond.DLC1Key, Cond.ForgottenKey, Cond.Catring),
            new(Cond.DLC2Key, Cond.IronKeyToFireLizards, WarpNode.LastGiantEntryFront), // has two conds
            new(Cond.DLC2Key, Cond.Catring, WarpNode.ForestOfFallenGiantsToCaleFront), // has two conds
            new(Cond.DLC3Key, WarpNode.TwinDragonridersEntryFront),
            new(Cond.ShulvaSanctumKey, WarpNode.ShulvaEntranceBack),
            new(Cond.ActivateDragonStone, Cond.DragonStone, WarpNode.NearJesterThomasBack),
            new(Cond.DLC3Eye, WarpNode.EleumLoyceAfterGettingEyeToSeeGhostsFront),
            new(Cond.DLC3Unfreezed, WarpNode.EleumLoyceCathedraEntranceBack, WarpNode.IvoryKingFightEndDst),
            new(Cond.FrigidOutskirtsKey, Cond.DLC3Unfreezed, WarpNode.AavaTheKingsPetEntryFront),
            new(Cond.ShipBellRang, WarpNode.NoMansWharfToHeidesBack),
            // for frigid outskits exit warp
            new(Cond.LudAndZallenDead, WarpNode.LudAndZallenEntryBack),
        };

        public static IReadOnlyList<WarpNode> cannot_warp_from = new List<WarpNode>
        {
            WarpNode.NearPursuerBirdExit,
            WarpNode.NearPateGiantMemoryEntryDst,
            WarpNode.NearPursuerGiantMemoryEntryDst,
            WarpNode.GiantLordMemoryEntryDst,
            WarpNode.DragonMemoriesMemoryDst,
            WarpNode.SirAlonneArmorDLCEntryDst,
            WarpNode.PirateShipBastille,
            WarpNode.CoffinWarpDst,
            WarpNode.IvoryKingFightEndDst,
            WarpNode.ChasmPortalFromBlackGulchDst,
            WarpNode.ChasmPortalFromCastleDst,
            WarpNode.ChasmPortalFromShadedWoodsDst,
            WarpNode.IvoryKingBack,

            WarpNode.NearPateGiantMemoryExitDst,
            WarpNode.NearPursuerGiantMemoryExitDst,
            WarpNode.GiantLordMemoryExitDst,
        };

        public static IReadOnlyList<WarpNode> cannot_warp_to = new List<WarpNode>
        {
            WarpNode.NearPursuerBirdEntry,
            WarpNode.NearPateGiantMemoryExitSrc,
            WarpNode.NearPursuerGiantMemoryExitSrc,
            WarpNode.GiantLordMemoryExitSrc,
            WarpNode.DragonMemoriesMemorySrc,
            WarpNode.SirAlonneMemoryExitSrc,
            WarpNode.PirateShipWharf,
            WarpNode.LudAndZallenExitWarpSrc,
            WarpNode.IvoryKingFightEndSrc,
            WarpNode.ChasmCastleExitWarpSrc,
            WarpNode.ChasmDarkLurkerExitWarpSrc,
            WarpNode.ChasmGulchExitWarpSrc,
            WarpNode.ChasmShadedWoodsExitWarpSrc,
        };

        public static IReadOnlyList<WarpNode> reqd_gates_to_complete_game = new List<WarpNode>
        {
            WarpNode.FinalFightArenaBack,
            WarpNode.GiantLordEntryBack,
        };

        public static IReadOnlyList<WarpNode> pirate_ship_nodes = new List<WarpNode>() 
        { 
            WarpNode.FlexileSentryEntryFront,
            WarpNode.FlexileSentryEntryBack,
            WarpNode.FlexileSentryExitFront,
            WarpNode.FlexileSentryExitBack,
        };

        public static List<WarpNode> starting_gates = new() 
        { 
            WarpNode.Tutorial1EntryFront,
            WarpNode.Tutorial2EntryFront,
            WarpNode.MajulaToForestOfFallenGiantsFront,
            WarpNode.MajulaToRotundaLockstoneFront,
            WarpNode.MajulaToGraveOfSaintsFront,
            WarpNode.MajulaToGutterFront,
            WarpNode.Tutorial3EntryFront,
        };

    }

    class TreeNode
    {
        public WarpNode Value;
        public List<TreeNode> Children = new List<TreeNode>();
        public CType Type;

        public TreeNode(WarpNode value, CType type)
        {
            Value = value;
            Type = type;
        }

        public static TreeNode? BuildTraversalTree(Graph graph, WarpNode startNode, CType type, HashSet<WarpNode>? visited = null)
        {
            if (visited == null)
                visited = new HashSet<WarpNode>();

            // Avoid cycles
            if (visited.Contains(startNode))
                return null;

            visited.Add(startNode);

            var node = new TreeNode(startNode, type);

            int count = 0;
            foreach (var next in graph.Edges[startNode])
            {
                var child = BuildTraversalTree(graph, next, graph.Types[startNode][count], visited: visited);
                if (child != null)
                    node.Children.Add(child);
                count++;
            }

            return node;
        }

        public static void PrintTree(TreeNode node, StringBuilder sb, string indent = "", bool isLast = true)
        {
            Console.Write(indent);
            sb.Append(indent);

            if (isLast)
            {
                Console.Write("└── ");
                sb.Append("└── ");
                indent += "    ";
            }
            else
            {
                Console.Write("├── ");
                sb.Append("├── ");
                indent += "│   ";
            }

            Console.WriteLine(node.Value);
            sb.Append(node.Value.ToString());
            sb.AppendLine();

            for (int i = 0; i < node.Children.Count; i++)
            {
                PrintTree(node.Children[i], sb, indent, i == node.Children.Count - 1);
            }
        }

    }

    class Graph
    {
        public Dictionary<WarpNode, List<WarpNode>> Edges = new Dictionary<WarpNode, List<WarpNode>>();
        public Dictionary<WarpNode, List<CType>> Types = new Dictionary<WarpNode, List<CType>>();

        public void AddNode(WarpNode node)
        {
            if (!Edges.ContainsKey(node))
                Edges[node] = new List<WarpNode>();
            if (!Types.ContainsKey(node))
                Types[node] = new List<CType>();
        }

        public void AddEdge(WarpNode from, WarpNode to, CType type)
        {
            AddNode(from);
            AddNode(to);
            Edges[from].Add(to);
            Types[from].Add(type);
        }
    }

    public enum CType
    {
        Warp,
        Walk
    }
    
    public class ConnectionElem
    {
        public CType type;
        public WarpNode to;

        public ConnectionElem(WarpNode to, CType type)
        {
            this.type = type;
            this.to = to;
        }
    }

    public class ConnectionGroup
    {
        public Dictionary<WarpNode, List<ConnectionElem>> items = new();

        void Add(WarpNode node)
        {
            if (!items.ContainsKey(node))
            {
                items[node] = new();
            }
        }
        public void Add(WarpNode src, WarpNode dst, CType type, bool twoway = false)
        {
            Add(src);
            Add(dst);
            if (!has_child(src, dst))
            {
                items[src].Add(new(dst, type));
            }
            if (twoway && !has_child(dst, src))
            {
                items[dst].Add(new(src, type));
            }
        }

        public bool Contains(WarpNode node)
        {
            return items.ContainsKey(node);
        }

        public bool has_child(WarpNode parent, WarpNode child)
        {
            if (!items.ContainsKey(parent)) return false;
            if (items[parent].Count == 0) return false;
            foreach (var c in items[parent])
            {
                if (c.to == child) return true;
            }
            return false;
        }
    }


    [DebuggerDisplay("{name}({count})")]
    public class InventoryItem
    {
        public Cond name;
        public int count;

        public InventoryItem(Cond name)
        {
            this.name = name;
            count = 1;
        }
    }

    public class Inventory: List<InventoryItem>
    {
        public bool Contains(Cond name)
        {
            foreach (var i in this)
            {
                if (i.name == name) return true;
            }
            return false;
        }

        public void Add(Cond name)
        {
            for (int i=0; i<this.Count; i++)
            {
                if (this[i].name == name)
                {
                    this[i].count++;
                    return;
                }
            }
            this.Add(new InventoryItem(name));
        }

        public int IndexOf(Cond name)
        {
            for (int i=0; i<this.Count; i++)
            {
                if (this[i].name == name) return i;
            }
            throw new ArgumentOutOfRangeException();
        }

        public void Use(Cond name)
        {
            if (!this.Contains(name)) return;
            int idx = this.IndexOf(name);
            if (this[idx].count == 0) return;
            if (KeyInfo.consumable_keys.Contains(name)) this[idx].count -= 1; // use it if it is consumable
        }

        public bool HasKey(HashSet<Node> visited_ids, Cond key)
        {
            bool ret = true;
            if (key == Cond.FirstFourSouls)
            {
                foreach(var item in GateConnections.key_reqs)
                {
                    if (item.cond == key)
                    {
                        foreach (var node in item.access_nodes)
                        {
                            bool contains = false;
                            foreach (var id in visited_ids)
                            {
                                if (id.name == node)
                                {
                                    contains = true;
                                    break;
                                }
                            }
                            ret = ret & contains;
                        }
                    }
                }
                return ret;
            }
            else if (KeyInfo.consumable_keys.Contains(key))
            {
                foreach (var item in this)
                {
                    if (item.name == key) return item.count > 0;
                }
                return false;

            }
            else if (key == Cond.Catring)
            {
                // TODO: catring is always accessible
                return true;
            }
            else if (key == Cond.DropDownPath)
            {
                // TODO: dropdown path is always enabled
                return true;
            }
            List<Cond> prereqs = new(0);
            foreach(var item in GateConnections.key_reqs)
            {
                if (item.cond == key) prereqs = item.prereqs;
            }
            if (prereqs.Count == 0)
            {
                foreach (var item in this)
                {
                    if (item.name == key) return true;
                }
                return false;
            }
            foreach (var prereq in prereqs)
            {
                ret = ret & HasKey(visited_ids, prereq);
            }
            return ret;
        }

        void check_blocked_edges(Queue<Node> queue, HashSet<Node> visited_ids, List<CondNode> blocked_edges,  List<CondNode> still_blocked)
        {
            foreach (var be in blocked_edges)
            {
                // TODO: make consumable key work
                // workaround: don't unlock the consumable keys door, remove them if they are reached
                if (KeyInfo.consumable_keys.Contains(be.cond))
                {
                    if (!visited_ids.Contains(be.node))
                    {
                        still_blocked.Add(be);
                    }
                }
                else if (this.HasKey(visited_ids, be.cond))
                {
                    this.Use(be.cond);
                    if (visited_ids.Contains(be.node)) continue;
                    queue.Enqueue(be.node);
                    visited_ids.Add(be.node);
                }
                else
                {
                    still_blocked.Add(be);
                }
            }
            (still_blocked, blocked_edges) = (blocked_edges, still_blocked);
        }

        public void Update(Node node, Queue<Node> queue, HashSet<Node> visited_ids, List<CondNode> blocked_edges, List<CondNode> still_blocked)
        {
            foreach (var key in node.keys)
            {
                bool found = false;
                for (int i=0; i<this.Count; i++)
                {
                    if (this[i].name == key)
                    {
                        this[i].count++;
                        check_blocked_edges(queue, visited_ids, blocked_edges, still_blocked);
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    this.Add(new InventoryItem(key));
                    check_blocked_edges(queue, visited_ids, blocked_edges, still_blocked);
                }
            }
        }
    }

    [DebuggerDisplay("{name}")]
    public class Node
    {
        public WarpNode name;
        public List<Cond> keys;

        public Node(WarpNode node, List<Cond> keys)
        {
            name = node;
            this.keys = keys;
        }
    }

    [DebuggerDisplay("{n1}-{n2}({cn1},{cn2})")]
    public class Edge
    {
        public Node n1;
        public Node n2;
        public Cond cn1; // for n2 -> n1
        public Cond cn2; // for n1 -> n2

        public Edge(WarpNode n1, WarpNode n2)
        {
            this.n1 = new(n1, new());
            this.n2 = new(n2, new());
        }

        public Edge(Node n1, Node n2, Cond cn1, Cond cn2)
        {
            this.n1 = n1;
            this.n2 = n2;
            this.cn1 = cn1;
            this.cn2 = cn2;
        }
    }

    [DebuggerDisplay("{node}({cond})")]
    public struct CondNode(Node node, Cond cond)
    {
        public Node node = node;
        public Cond cond = cond;
    }
}
