using System;
using System.Collections.Generic;

namespace FogWallNS
{
    public enum Gate
    {
        Lone,
        // warp gates
        NearPursuerBirdEntry,
        NearPursuerGiantMemoryEntryFront,
        NearPateGiantMemoryEntryFront,
        GiantLordMemoryEntryFront,
        //
        NearPursuerBirdExit,
        NearPursuerGiantMemoryEntryBack,
        NearPateGiantMemoryEntryBack,
        GiantLordMemoryEntryBack,
        NearPursuerGiantMemoryExit,
        NearPateGiantMemoryExit,
        GiantLordMemoryExit,
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
        SirAlonneArmorDLC,
        SirAlonneArmorMemory,
        SirAlonneMemoryExit,
        //
        ChasmPortalFromBlackGulch,
        ChasmPortalFromShadedWoods,
        ChasmPortalFromCastle,
        //
        ChasmPortalFromBlackGulchDungeon,
        ChasmPortalFromShadedWoodsDungeon,
        ChasmPortalFromCastleDungeon,
        //
        ChasmGulchExitWarp,
        ChasmShadedWoodsExitWarp,
        ChasmCastleExitWarp,
        //
        IvoryKingFightEndSrc,
        IvoryKingFightEndDst,
        CoffinWarpSrc,
        CoffinWarpDst,
        LudAndZallenExitWarp,
        //
        DragonMemoriesCoveSrc,
        DragonMemoriesMemoryDst,
        DragonMemoriesMemorySrc,
        MemoryOfTheKingCryptSrc,
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
        LastGiantFront,
        PursuerEntryFront,
        PursuerExitFront,
        ForestOfFallenGiantsBalconyFront,
        ForestOfFallenGiantsToCaleFront,
        ForestOfFallenGiantsAfterFirstBonfireFront,
        ForestOfFallenGiantsFromMajulaFront,
        ForestOfFallenGiantsToPursuerArenaFront,
        LastGiantBack,
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
        RuinSentinelsHiddenDoor1Front,
        RuinSentinelsHiddenDoor2Front,
        RuinSentinelsHiddenDoor3Front,
        RuinSentinelsHiddenDoor4Front,
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
        RuinSentinelsHiddenDoor1Back,
        RuinSentinelsHiddenDoor2Back,
        RuinSentinelsHiddenDoor3Back,
        RuinSentinelsHiddenDoor4Back,
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
        SihnTheSlumberingDragonFront,
        ElanaTheSqualidQueenFront,
        GankSquadBossEntryFront,
        GankSquadBossExitFront,
        ShulvaToGankFight1Front,
        ShulvaToGankFight2Front,
        BetweenElanaAndSihnFront,
        NearJesterThomasFront,
        ShulvaEntranceFront,
        SihnTheSlumberingDragonBack,
        ElanaTheSqualidQueenBack,
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
        FragrantBranchOfYore,
        OneWay,
        RotundaLockstone,
        SoldiersKey,
        KingsRing,
        KingsRingFragrantBranch,
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
    }

    public class Connection
    {
        public Gate n1;
        public Gate n2;
        public Cond condition_n1;
        public Cond condition_n2;

        public Connection(Gate node1, Gate node2, Cond n1 = Cond.None,
            Cond n2 = Cond.None)
        {
            this.n1 = node1;
            this.n2 = node2;
            condition_n1 = n1;
            condition_n2 = n2;
        }
    }

    public static class GateConnections
    {
        public static IReadOnlyList<Connection> items { get; } = new List<Connection> {
            new(Gate.Tutorial1EntryFront, Gate.Tutorial2EntryFront),
            new(Gate.Tutorial1EntryFront, Gate.Tutorial3EntryFront, n2: Cond.FragrantBranchOfYore),
            new(Gate.Tutorial1EntryFront, Gate.Tutorial1ExitBack,   n2: Cond.OneWay),
            new(Gate.Tutorial1EntryFront, Gate.Tutorial2ExitBack,   n2: Cond.OneWay),
            new(Gate.Tutorial1EntryFront, Gate.Tutorial3ExitBack,   n2: Cond.OneWay),
            new(Gate.Tutorial1EntryFront, Gate.MajulaToForestOfFallenGiantsFront),
            new(Gate.Tutorial1EntryFront, Gate.MajulaToGraveOfSaintsFront, n1: Cond.OneWay, n2: Cond.Catring),
            new(Gate.Tutorial1EntryFront, Gate.MajulaToGutterFront, n1: Cond.OneWay, n2: Cond.Catring),
            new(Gate.Tutorial1EntryFront, Gate.MajulaToShadedWoodsFront),
            new(Gate.Tutorial1EntryFront, Gate.MajulaToRotundaLockstoneFront),

            new(Gate.Tutorial2EntryFront, Gate.Tutorial3EntryFront, n2: Cond.FragrantBranchOfYore),
            new(Gate.Tutorial2EntryFront, Gate.Tutorial1ExitBack,   n2: Cond.OneWay),
            new(Gate.Tutorial2EntryFront, Gate.Tutorial2ExitBack,   n2: Cond.OneWay),
            new(Gate.Tutorial2EntryFront, Gate.Tutorial3ExitBack,   n2: Cond.OneWay),
            new(Gate.Tutorial2EntryFront, Gate.MajulaToForestOfFallenGiantsFront),
            new(Gate.Tutorial2EntryFront, Gate.MajulaToGraveOfSaintsFront, n1: Cond.OneWay, n2: Cond.Catring),
            new(Gate.Tutorial2EntryFront, Gate.MajulaToGutterFront, n1: Cond.OneWay, n2: Cond.Catring),
            new(Gate.Tutorial2EntryFront, Gate.MajulaToShadedWoodsFront),
            new(Gate.Tutorial2EntryFront, Gate.MajulaToRotundaLockstoneFront),

            new(Gate.Tutorial3EntryFront, Gate.Tutorial1ExitBack,   n1: Cond.FragrantBranchOfYore, n2: Cond.OneWay),
            new(Gate.Tutorial3EntryFront, Gate.Tutorial2ExitBack,   n1: Cond.FragrantBranchOfYore, n2: Cond.OneWay),
            new(Gate.Tutorial3EntryFront, Gate.Tutorial3ExitBack,   n1: Cond.FragrantBranchOfYore, n2: Cond.OneWay),
            new(Gate.Tutorial3EntryFront, Gate.MajulaToForestOfFallenGiantsFront, n1: Cond.FragrantBranchOfYore),
            new(Gate.Tutorial3EntryFront, Gate.MajulaToGraveOfSaintsFront, n1: Cond.OneWay, n2: Cond.Catring),
            new(Gate.Tutorial3EntryFront, Gate.MajulaToGutterFront, n1: Cond.OneWay, n2: Cond.Catring),
            new(Gate.Tutorial3EntryFront, Gate.MajulaToShadedWoodsFront, n1: Cond.FragrantBranchOfYore),
            new(Gate.Tutorial3EntryFront, Gate.MajulaToRotundaLockstoneFront, n1: Cond.FragrantBranchOfYore),

            new(Gate.Tutorial1ExitBack, Gate.MajulaToForestOfFallenGiantsFront, n1: Cond.OneWay),
            new(Gate.Tutorial1ExitBack, Gate.MajulaToGraveOfSaintsFront, n1: Cond.OneWay, n2: Cond.Catring),
            new(Gate.Tutorial1ExitBack, Gate.MajulaToGutterFront, n1: Cond.OneWay, n2: Cond.Catring),
            new(Gate.Tutorial1ExitBack, Gate.MajulaToShadedWoodsFront, n1: Cond.OneWay),
            new(Gate.Tutorial1ExitBack, Gate.MajulaToRotundaLockstoneFront, n1: Cond.OneWay),

            new(Gate.Tutorial2ExitBack, Gate.MajulaToForestOfFallenGiantsFront, n1: Cond.OneWay),
            new(Gate.Tutorial2ExitBack, Gate.MajulaToGraveOfSaintsFront, n1: Cond.OneWay, n2: Cond.Catring),
            new(Gate.Tutorial2ExitBack, Gate.MajulaToGutterFront, n1: Cond.OneWay, n2: Cond.Catring),
            new(Gate.Tutorial2ExitBack, Gate.MajulaToShadedWoodsFront, n1: Cond.OneWay),
            new(Gate.Tutorial2ExitBack, Gate.MajulaToRotundaLockstoneFront, n1: Cond.OneWay),

            new(Gate.Tutorial3ExitBack, Gate.MajulaToForestOfFallenGiantsFront, n1: Cond.OneWay),
            new(Gate.Tutorial3ExitBack, Gate.MajulaToGraveOfSaintsFront, n1: Cond.OneWay, n2: Cond.Catring),
            new(Gate.Tutorial3ExitBack, Gate.MajulaToGutterFront, n1: Cond.OneWay, n2: Cond.Catring),
            new(Gate.Tutorial3ExitBack, Gate.MajulaToShadedWoodsFront, n1: Cond.OneWay),
            new(Gate.Tutorial3ExitBack, Gate.MajulaToRotundaLockstoneFront, n1: Cond.OneWay),

            new(Gate.MajulaToForestOfFallenGiantsFront, Gate.MajulaToGraveOfSaintsFront, n1: Cond.OneWay, n2: Cond.Catring),
            new(Gate.MajulaToForestOfFallenGiantsFront, Gate.MajulaToGutterFront, n1: Cond.OneWay, n2: Cond.Catring),
            new(Gate.MajulaToForestOfFallenGiantsFront, Gate.MajulaToShadedWoodsFront),
            new(Gate.MajulaToForestOfFallenGiantsFront, Gate.MajulaToRotundaLockstoneFront),

            new(Gate.MajulaToGraveOfSaintsFront, Gate.MajulaToGutterFront, n1: Cond.OneWay),
            new(Gate.MajulaToGraveOfSaintsFront, Gate.MajulaToShadedWoodsFront, n1: Cond.Catring, n2: Cond.OneWay),
            new(Gate.MajulaToGraveOfSaintsFront, Gate.MajulaToRotundaLockstoneFront, n1: Cond.Catring, n2: Cond.OneWay),

            new(Gate.MajulaToGutterFront, Gate.MajulaToShadedWoodsFront, n1: Cond.Catring, n2: Cond.OneWay),
            new(Gate.MajulaToGutterFront, Gate.MajulaToRotundaLockstoneFront, n1: Cond.Catring, n2: Cond.OneWay),

            new(Gate.MajulaToShadedWoodsFront, Gate.MajulaToRotundaLockstoneFront),

            new(Gate.Tutorial1EntryBack, Gate.Tutorial1ExitFront),
            new(Gate.Tutorial2EntryBack, Gate.Tutorial2ExitFront, n1: Cond.OneWay),
            new(Gate.Tutorial3EntryBack, Gate.Tutorial3ExitFront, n1: Cond.OneWay),

            // Forest of the fallen giants
            new(Gate.MajulaToForestOfFallenGiantsBack, Gate.ForestOfFallenGiantsAfterFirstBonfireFront),

            // TODO: add logic for iron key?
            new(Gate.ForestOfFallenGiantsAfterFirstBonfireBack, Gate.ForestOfFallenGiantsToCaleFront, n1: Cond.DropDownPath),
            new(Gate.ForestOfFallenGiantsAfterFirstBonfireBack, Gate.ForestOfFallenGiantsBalconyBack, n1: Cond.OneWay),
            new(Gate.ForestOfFallenGiantsAfterFirstBonfireBack, Gate.GiantLordMemoryEntryFront, n2: Cond.AshenMistHeartSoldiersKeyKingsRing),

            new(Gate.ForestOfFallenGiantsToCaleFront, Gate.ForestOfFallenGiantsBalconyBack, n2: Cond.OneWay),
            new(Gate.ForestOfFallenGiantsToCaleFront, Gate.LastGiantFront, n2: Cond.OneWay),
            new(Gate.ForestOfFallenGiantsToCaleFront, Gate.GiantLordMemoryEntryFront, n2: Cond.AshenMistHeartSoldiersKeyKingsRing),

            new(Gate.ForestOfFallenGiantsBalconyBack, Gate.LastGiantFront),
            new(Gate.ForestOfFallenGiantsBalconyBack, Gate.GiantLordMemoryEntryFront, n1: Cond.OneWay, n2: Cond.AshenMistHeartSoldiersKeyKingsRing),

            new(Gate.LastGiantBack, Gate.Lone),

            new(Gate.ForestOfFallenGiantsToCaleBack, Gate.ForestOfFallenGiantsBalconyFront),
            new(Gate.ForestOfFallenGiantsToCaleBack, Gate.ForestOfFallenGiantsToPursuerArenaFront, n1: Cond.OneWay, n2: Cond.SoldiersKey),
            new(Gate.ForestOfFallenGiantsToCaleBack, Gate.PursuerExitBack, n2: Cond.OneWay),
            new(Gate.ForestOfFallenGiantsToCaleBack, Gate.NearPursuerGiantMemoryEntryFront, n2: Cond.OneWay),
            new(Gate.ForestOfFallenGiantsToCaleBack, Gate.NearPateGiantMemoryEntryFront, n2: Cond.AshenMistHeart),

            new(Gate.ForestOfFallenGiantsBalconyFront, Gate.ForestOfFallenGiantsToPursuerArenaFront, n1: Cond.OneWay, n2: Cond.SoldiersKey),
            new(Gate.ForestOfFallenGiantsBalconyFront, Gate.PursuerExitBack, n2: Cond.OneWay),
            new(Gate.ForestOfFallenGiantsBalconyFront, Gate.NearPursuerGiantMemoryEntryFront, n2: Cond.OneWay),
            new(Gate.ForestOfFallenGiantsBalconyFront, Gate.NearPateGiantMemoryEntryFront, n2: Cond.AshenMistHeart),

            new(Gate.ForestOfFallenGiantsToPursuerArenaFront, Gate.PursuerExitBack, n1:Cond.SoldiersKey, n2: Cond.OneWay),
            new(Gate.ForestOfFallenGiantsToPursuerArenaFront, Gate.NearPursuerGiantMemoryEntryFront, n1: Cond.SoldiersKey, n2: Cond.OneWay),
            new(Gate.ForestOfFallenGiantsToPursuerArenaFront, Gate.NearPateGiantMemoryEntryFront, n1: Cond.SoldiersKey, n2: Cond.AshenMistHeartSoldiersKey),

            new(Gate.PursuerExitBack, Gate.NearPursuerGiantMemoryEntryFront, n2: Cond.AshenMistHeart),
            new(Gate.PursuerExitBack, Gate.NearPateGiantMemoryEntryFront, n1: Cond.OneWay, n2: Cond.AshenMistHeart),
            new(Gate.PursuerExitBack, Gate.NearPursuerBirdEntry, n1: Cond.OneWay),

            new(Gate.NearPursuerGiantMemoryEntryFront, Gate.NearPateGiantMemoryEntryFront, n1: Cond.OneWay, n2: Cond.AshenMistHeart),

            new(Gate.ForestOfFallenGiantsToPursuerArenaBack, Gate.PursuerEntryFront),

            new(Gate.PursuerEntryBack, Gate.PursuerExitFront),
            // lost bastille
            new(Gate.NearPursuerBirdExit, Gate.RuinSentinelsEntryFront, n2: Cond.FragrantBranchOfYore, n1: Cond.OneWay),

            new(Gate.RuinSentinelsEntryFront, Gate.LostBastilleToShipFromWharfBack, n2: Cond.OneWay, n1: Cond.FragrantBranchOfYore),
            new(Gate.RuinSentinelsEntryFront, Gate.RuinSentinesUpperExitBack, n2: Cond.OneWay),

            new(Gate.LostBastilleToShipFromWharfBack, Gate.LostBastilleToSinnersRiseFront, n2: Cond.OldKeyInBastille, n1: Cond.OneWay),
            new(Gate.LostBastilleToShipFromWharfBack, Gate.RuinSentinesUpperExitBack, n1: Cond.OldKeyInBastille, n2: Cond.OneWay),

            new(Gate.LostBastilleToSinnersRiseFront, Gate.RuinSentinesUpperExitBack, n1: Cond.OldKeyInBastille, n2: Cond.OneWay),

            new(Gate.PirateShipBastille, Gate.LostBastilleToShipFromWharfFront, n1: Cond.OneWay),

            new(Gate.LostBastilleToSinnersRiseBack, Gate.LostSinnerEntryFront, n1: Cond.BastilleKey),

            new(Gate.RuinSentinelsEntryBack, Gate.RuinSentinelsHiddenDoor1Front, n1: Cond.OneWay),
            new(Gate.RuinSentinelsEntryBack, Gate.RuinSentinelsHiddenDoor2Front, n1: Cond.OneWay),
            new(Gate.RuinSentinelsEntryBack, Gate.RuinSentinelsHiddenDoor3Front, n1: Cond.OneWay),
            new(Gate.RuinSentinelsEntryBack, Gate.RuinSentinelsHiddenDoor4Front, n1: Cond.OneWay),
            new(Gate.RuinSentinelsEntryBack, Gate.RuinSentinelsExitFront, n1: Cond.OneWay),

            new(Gate.RuinSentinelsHiddenDoor1Front, Gate.RuinSentinelsHiddenDoor2Front),
            new(Gate.RuinSentinelsHiddenDoor1Front, Gate.RuinSentinelsHiddenDoor3Front),
            new(Gate.RuinSentinelsHiddenDoor1Front, Gate.RuinSentinelsHiddenDoor4Front),
            new(Gate.RuinSentinelsHiddenDoor1Front, Gate.RuinSentinelsExitFront),
            new(Gate.RuinSentinelsHiddenDoor1Front, Gate.RuinSentinelsExitBack, n2: Cond.OneWay),

            new(Gate.RuinSentinelsHiddenDoor2Front, Gate.RuinSentinelsHiddenDoor3Front),
            new(Gate.RuinSentinelsHiddenDoor2Front, Gate.RuinSentinelsHiddenDoor4Front),
            new(Gate.RuinSentinelsHiddenDoor2Front, Gate.RuinSentinelsExitFront),
            new(Gate.RuinSentinelsHiddenDoor2Front, Gate.RuinSentinelsExitBack, n2: Cond.OneWay),

            new(Gate.RuinSentinelsHiddenDoor3Front, Gate.RuinSentinelsHiddenDoor4Front),
            new(Gate.RuinSentinelsHiddenDoor3Front, Gate.RuinSentinelsExitFront),
            new(Gate.RuinSentinelsHiddenDoor3Front, Gate.RuinSentinelsExitBack, n2: Cond.OneWay),

            new(Gate.RuinSentinelsHiddenDoor4Front, Gate.RuinSentinelsExitFront),
            new(Gate.RuinSentinelsHiddenDoor4Front, Gate.RuinSentinelsExitBack, n2: Cond.OneWay),

            new(Gate.RuinSentinelsExitFront, Gate.RuinSentinelsExitBack, n2: Cond.OneWay),

            new(Gate.RuinSentinelsHiddenDoor1Back, Gate.Lone),
            new(Gate.RuinSentinelsHiddenDoor2Back, Gate.Lone),
            new(Gate.RuinSentinelsHiddenDoor3Back, Gate.Lone),
            new(Gate.RuinSentinelsHiddenDoor4Back, Gate.Lone),

            new(Gate.RuinSentinesUpperExitFront, Gate.RuinSentinelsHiddenDoor1Front, n1: Cond.OneWay),
            new(Gate.RuinSentinesUpperExitFront, Gate.RuinSentinelsHiddenDoor2Front, n1: Cond.OneWay),
            new(Gate.RuinSentinesUpperExitFront, Gate.RuinSentinelsHiddenDoor3Front, n1: Cond.OneWay),
            new(Gate.RuinSentinesUpperExitFront, Gate.RuinSentinelsHiddenDoor4Front, n1: Cond.OneWay),
            new(Gate.RuinSentinesUpperExitFront, Gate.RuinSentinelsExitFront, n1: Cond.OneWay),
            new(Gate.RuinSentinesUpperExitFront, Gate.RuinSentinelsExitBack),
            // heides tower of flame
            new(Gate.MajulaToRotundaLockstoneBack, Gate.MajulaToHuntsmanCopseFront, n1: Cond.OneWay, n2: Cond.RotundaLockstone),
            new(Gate.MajulaToRotundaLockstoneBack, Gate.HeidesToMajulaFront, n1: Cond.OneWay, n2: Cond.RotundaLockstone),

            new(Gate.MajulaToHuntsmanCopseFront, Gate.HeidesToMajulaFront, n1: Cond.RotundaLockstone, n2: Cond.OneWay),

            new(Gate.HeidesToMajulaBack, Gate.DragonriderEntryFront),
            new(Gate.HeidesToMajulaBack, Gate.OldDragonslayerEntryFront),

            new(Gate.DragonriderEntryFront, Gate.OldDragonslayerEntryFront),

            new(Gate.DragonriderEntryBack, Gate.DragonriderExitFront),

            new(Gate.OldDragonslayerEntryBack, Gate.OldDragonslayerExitFront),

            new(Gate.OldDragonslayerExitBack, Gate.Lone),

            new(Gate.DragonriderExitBack, Gate.NoMansWharfToHeidesFront),
            // no man's wharf
            new(Gate.NoMansWharfToHeidesBack, Gate.PirateShipWharf, n1: Cond.OneWay),
            // huntsman copse
            new(Gate.MajulaToHuntsmanCopseBack, Gate.HuntsmanCopseToMajulaFront),
            new(Gate.HuntsmanCopseToMajulaBack, Gate.ChariotEntryFront),
            new(Gate.HuntsmanCopseToMajulaBack, Gate.SkeletonLordsEntryFront, n1: Cond.OneWay),

            new(Gate.ChariotEntryFront, Gate.SkeletonLordsEntryFront, n1: Cond.OneWay),

            new(Gate.ChariotEntryBack, Gate.ChariotExitFront),
            new(Gate.ChariotExitBack, Gate.Lone),

            new(Gate.SkeletonLordsEntryBack, Gate.SkeletonLordsExitFront),
            new(Gate.SkeletonLordsExitBack, Gate.HarvestValleyToSkeletonLordsFront, n1: Cond.OneWay),
            // harvest valley
            new(Gate.HarvestValleyToSkeletonLordsBack, Gate.CovetousDemonEntryFront, n1: Cond.OneWay),
            new(Gate.CovetousDemonEntryBack, Gate.CovetousDemonExitFront),
            
            // earthen peak
            new(Gate.CovetousDemonExitBack, Gate.EarthenPeakNearWindmillBurnLocationFront),
            new(Gate.CovetousDemonExitBack, Gate.EarthenPeakNearWindmillBurnLocationBack),
            new(Gate.CovetousDemonExitBack, Gate.MythaEntryFront),

            new(Gate.EarthenPeakNearWindmillBurnLocationFront, Gate.EarthenPeakNearWindmillBurnLocationBack),
            new(Gate.EarthenPeakNearWindmillBurnLocationFront, Gate.MythaEntryFront),

            new(Gate.EarthenPeakNearWindmillBurnLocationBack, Gate.MythaEntryFront),

            new(Gate.MythaEntryBack, Gate.MythaExitFront),
            new(Gate.MythaExitBack, Gate.IronKeepToEarthenPeakFront),
            // iron keep
            new(Gate.IronKeepToEarthenPeakBack, Gate.SmeltorDemonEntryFront, n1: Cond.OneWay),
            new(Gate.IronKeepToEarthenPeakBack, Gate.IronKeepNearFlameThrowerAndTurtleFront, n1: Cond.OneWay),
            new(Gate.IronKeepToEarthenPeakBack, Gate.IronKeepToBelfryAtPharrosLockstoneFront, n1: Cond.OneWay, n2: Cond.PharrosLockstone),

            new(Gate.SmeltorDemonEntryFront, Gate.IronKeepNearFlameThrowerAndTurtleFront),
            new(Gate.SmeltorDemonEntryFront, Gate.IronKeepNearFlameThrowerAndTurtleBack, n1: Cond.OneWay),
            new(Gate.SmeltorDemonEntryFront, Gate.IronKeepToBelfryAtPharrosLockstoneFront, n2: Cond.PharrosLockstone),

            new(Gate.SmeltorDemonEntryBack, Gate.SmeltorDemonExitFront),
            new(Gate.SmeltorDemonExitBack, Gate.SmeltorDemonToBonfireFront),

            new(Gate.IronKeepToBelfryAtPharrosLockstoneBack, Gate.BelfrySolEntryFront),
            new(Gate.IronKeepToBelfryAtPharrosLockstoneBack, Gate.IronKeepNearFlameThrowerAndTurtleFront, n1: Cond.OneWay),
            new(Gate.IronKeepToBelfryAtPharrosLockstoneBack, Gate.BelfrySolExitBack, n2: Cond.OneWay),
            new(Gate.BelfrySolEntryBack, Gate.BelfrySolExitFront),

            new(Gate.BelfrySolExitBack, Gate.SmeltorDemonEntryFront, n1: Cond.OneWay),
            new(Gate.BelfrySolExitBack, Gate.IronKeepNearFlameThrowerAndTurtleFront, n1: Cond.OneWay),
            new(Gate.BelfrySolExitBack, Gate.IronKeepNearFlameThrowerAndTurtleBack, n1: Cond.OneWay),

            new(Gate.IronKeepNearFlameThrowerAndTurtleBack, Gate.OldIronKingEntryFront),
            new(Gate.OldIronKingEntryBack, Gate.OldIronKingExitFront),
            new(Gate.OldIronKingExitBack, Gate.DLC2EntranceBaseGame),

            new(Gate.OldIronKingEntryFront, Gate.IronKeepToBelfryAtPharrosLockstoneFront, n2: Cond.OneWay),
            new(Gate.OldIronKingEntryFront, Gate.IronKeepToBelfryAtPharrosLockstoneBack, n2: Cond.OneWay),
            new(Gate.OldIronKingEntryFront, Gate.BelfrySolExitBack, n2: Cond.OneWay),
            // dlc2
            new(Gate.DLC2EntranceDLC, Gate.BrumeTowerEntranceFromLiftFront, n1: Cond.OneWay, n2: Cond.DLC2Key),
            new(Gate.BrumeTowerEntranceFromLiftBack, Gate.BrumeTowerFrom2ndBonfireToCentralRoomFront, n1: Cond.OneWay),
            new(Gate.BrumeTowerFrom2ndBonfireToCentralRoomBack, Gate.BrumeTowerToFoyerBonfireFromOutsideFront, n1: Cond.OneWay),
            new(Gate.BrumeTowerToFoyerBonfireFromOutsideBack, Gate.BrumeTowerToScorchingIronSceptorKeyFront),
            new(Gate.BrumeTowerToScorchingIronSceptorKeyBack, Gate.Lone),

            new(Gate.BrumeTowerToBlueSmelterDungeonBack, Gate.BlueSmeltorDemonEntryFront, n1: Cond.OneWay),
            new(Gate.BlueSmeltorDemonEntryBack, Gate.BlueSmeltorDemonExitFront),
            new(Gate.BlueSmeltorDemonExitBack, Gate.BrumeTowerToBlueSmelterDungeonFront, n1: Cond.OneWay),

            new(Gate.BrumeTowerToFoyerBonfireFromOutsideBack, Gate.BrumeTowerToBlueSmelterDungeonFront, n1: Cond.OneWay, n2: Cond.ScorchingIronSceptor),
            new(Gate.BrumeTowerToFoyerBonfireFromOutsideBack, Gate.FumeKnightEntryFront, n1: Cond.OneWay, n2: Cond.ScorchingIronSceptor),
            new(Gate.BrumeTowerToFoyerBonfireFromOutsideBack, Gate.BrumeTowerFrom2ndBonfireToCentralRoomBack, n1: Cond.OneWay, n2: Cond.ScorchingIronSceptor),
            new(Gate.BrumeTowerToFoyerBonfireFromOutsideBack, Gate.SirAlonneArmorDLC, n1: Cond.OneWay, n2: Cond.ScorchingIronSceptor),

            new(Gate.BrumeTowerFrom2ndBonfireToCentralRoomBack, Gate.SirAlonneArmorDLC, n1: Cond.OneWay, n2: Cond.ActivateBrumeTower),

            new(Gate.SirAlonneArmorMemory, Gate.SirAlonneEntryFront, n1: Cond.OneWay),
            new(Gate.SirAlonneEntryBack, Gate.SirAlonneExitFront),
            new(Gate.SirAlonneExitBack, Gate.SirAlonneMemoryExit),

            new(Gate.FumeKnightEntryBack, Gate.FumeKnightExitFront),
            new(Gate.FumeKnightExitBack, Gate.Lone),
            
            // grave of saints
            new(Gate.MajulaToGraveOfSaintsBack, Gate.GraveOfSaintsFromPitFront),
            new(Gate.GraveOfSaintsFromPitBack, Gate.GraveOfSaintsNearUpperBonfireFront),
            new(Gate.GraveOfSaintsNearUpperBonfireBack, Gate.RoyalRatVanguardEntryFront),
            new(Gate.RoyalRatVanguardEntryBack, Gate.RoyalRatVanguardExitFront),
            new(Gate.RoyalRatVanguardExitBack, Gate.MajulaToGutterBack, n1: Cond.OneWay),
            new(Gate.RoyalRatVanguardExitBack, Gate.TheGutterFromGraveOfSaintsFront, n1: Cond.OneWay),
            new(Gate.MajulaToGutterBack, Gate.TheGutterFromGraveOfSaintsFront, n1: Cond.OneWay),
            // gutter
            new(Gate.TheGutterFromGraveOfSaintsBack, Gate.GutterNearAntQueenFront, n1:Cond.OneWay),
            new(Gate.TheGutterFromGraveOfSaintsBack, Gate.GutterNearAntQueenBack,  n1:Cond.OneWay),
            new(Gate.TheGutterFromGraveOfSaintsBack, Gate.BlackGulchEntranceFront,  n1:Cond.OneWay),
            new(Gate.GutterNearAntQueenBack, Gate.BlackGulchEntranceFront,  n1:Cond.OneWay),
            // black gulch
            new(Gate.BlackGulchEntranceBack, Gate.TheRottenEntryFront),
            new(Gate.BlackGulchEntranceBack, Gate.ChasmPortalFromBlackGulch, n1: Cond.OneWay, n2: Cond.DarkCovenentJoinedForgottenKey),
            new(Gate.ChasmPortalFromBlackGulch, Gate.TheRottenEntryFront, n1: Cond.DarkCovenentJoinedForgottenKey, n2: Cond.OneWay),

            new(Gate.TheRottenEntryBack, Gate.TheRottenExitFront),
            new(Gate.TheRottenExitBack, Gate.DLC1EntranceBaseGame),
            // dlc1
            new(Gate.DLC1EntranceDLC, Gate.ShulvaEntranceFront, n1: Cond.DLC1Key, n2: Cond.DLC1Key),
            new(Gate.ShulvaEntranceBack, Gate.NearJesterThomasFront, n1: Cond.OneWay),
            new(Gate.ShulvaEntranceBack, Gate.ShulvaToGankFight1Front, n1: Cond.OneWay, n2: Cond.ShulvaSanctumKey),

            new(Gate.NearJesterThomasBack, Gate.ShulvaEntranceFront, n1: Cond.OneWay),
            new(Gate.NearJesterThomasBack, Gate.ElanaTheSqualidQueenFront, n1: Cond.OneWay, n2: Cond.ActivateDragonStone),

            new(Gate.ElanaTheSqualidQueenBack, Gate.BetweenElanaAndSihnFront, n1: Cond.OneWay),
            new(Gate.BetweenElanaAndSihnBack, Gate.SihnTheSlumberingDragonFront),
            new(Gate.SihnTheSlumberingDragonBack, Gate.Lone),

            new(Gate.ShulvaToGankFight1Back, Gate.ShulvaToGankFight2Front),
            new(Gate.ShulvaToGankFight2Back, Gate.GankSquadBossEntryFront, n1: Cond.OneWay),
            new(Gate.GankSquadBossEntryBack, Gate.GankSquadBossExitFront),
            new(Gate.GankSquadBossExitBack, Gate.ShulvaEntranceBack, n1: Cond.OneWay),
            new(Gate.GankSquadBossExitBack, Gate.NearJesterThomasFront, n1: Cond.OneWay),
            new(Gate.GankSquadBossExitBack, Gate.ShulvaToGankFight1Front, n1: Cond.OneWay, n2: Cond.ShulvaSanctumKey),
            // shaded woods
            new(Gate.MajulaToShadedWoodsBack, Gate.ShadedWoodsFromMajulaFront),
            new(Gate.ShadedWoodsFromMajulaBack, Gate.ShadedWoodsToMistyAreaFront, n1: Cond.OneWay, n2: Cond.FragrantBranchOfYore),
            new(Gate.ShadedWoodsFromMajulaBack, Gate.AldiasKeepEntranceFront, n1: Cond.OneWay, n2: Cond.KingsRingFragrantBranch),
            new(Gate.ShadedWoodsFromMajulaBack, Gate.DrangleicCastleToShadedWoodsFront, n1: Cond.OneWay, n2: Cond.FirstFourSouls),
            new(Gate.ShadedWoodsFromMajulaBack, Gate.DLC3EntranceBaseGame, n1: Cond.OneWay, n2: Cond.FirstFourSouls),

            new(Gate.ShadedWoodsToMistyAreaFront, Gate.AldiasKeepEntranceFront, n1: Cond.KingsRing, n2: Cond.KingsRing),
            new(Gate.ShadedWoodsToMistyAreaFront, Gate.DrangleicCastleToShadedWoodsFront, n1: Cond.FirstFourSouls, n2: Cond.FirstFourSouls),
            new(Gate.ShadedWoodsToMistyAreaFront, Gate.DLC3EntranceBaseGame, n1: Cond.FirstFourSouls, n2: Cond.FirstFourSouls),

            new(Gate.ShadedWoodsToMistyAreaBack, Gate.ScorpionessNajkaEntryFront),
            new(Gate.ScorpionessNajkaEntryBack, Gate.ScorpionessNajkaExitFront),

            new(Gate.ScorpionessNajkaExitBack, Gate.DoorOfPharrosToRatKingDomainFront),
            new(Gate.ScorpionessNajkaExitBack, Gate.BrightstoneCoveToDoorsOfPharrosFront),
            new(Gate.ScorpionessNajkaExitBack, Gate.RoyalRatAuthorityExitBack, n2: Cond.OneWay),

            new(Gate.DoorOfPharrosToRatKingDomainFront, Gate.BrightstoneCoveToDoorsOfPharrosFront),
            new(Gate.DoorOfPharrosToRatKingDomainFront, Gate.RoyalRatAuthorityExitBack, n2: Cond.OneWay),

            new(Gate.BrightstoneCoveToDoorsOfPharrosFront, Gate.RoyalRatAuthorityExitBack, n2: Cond.OneWay),

            new(Gate.ChasmPortalFromShadedWoods, Gate.ShadedWoodsToMistyAreaBack, n1: Cond.DarkCovenentJoined),
            new(Gate.ChasmPortalFromShadedWoods, Gate.ScorpionessNajkaEntryFront, n1: Cond.DarkCovenentJoined),

            // brightstone cove
            new(Gate.BrightstoneCoveToDoorsOfPharrosBack, Gate.CongregationEntryFront),
            new(Gate.CongregationEntryBack, Gate.CongregationExitFront),
            new(Gate.CongregationExitBack, Gate.DukesDearFreyjaEntryFront, n1: Cond.OneWay),
            new(Gate.DukesDearFreyjaEntryBack, Gate.DukesDearFreyjaExitFront),
            new(Gate.DukesDearFreyjaExitBack, Gate.Lone),
            new(Gate.DukesDearFreyjaEntryBack, Gate.DragonMemoriesCoveSrc, n2: Cond.AshenMistHeart),
            new(Gate.DukesDearFreyjaExitFront, Gate.DragonMemoriesCoveSrc, n2: Cond.AshenMistHeart),
            new(Gate.DragonMemoriesMemoryDst, Gate.DragonMemoriesMemorySrc, n1: Cond.OneWay),

            // dlc3
            new(Gate.DLC3EntranceDLC, Gate.AavaTheKingsPetEntryFront, n1: Cond.DLC3Key, n2: Cond.DLC3Key),
            new(Gate.DLC3EntranceDLC, Gate.EleumLoyceAfterGettingEyeToSeeGhostsFront, n1: Cond.OneWay, n2: Cond.DLC3Key),
            new(Gate.AavaTheKingsPetEntryBack, Gate.AavaTheKingsPetExitBack, n1: Cond.DLC3Eye, n2: Cond.DLC3Eye),
            new(Gate.AavaTheKingsPetExitBack, Gate.EleumLoyceCathedraEntranceFront),
            new(Gate.EleumLoyceCathedraEntranceBack, Gate.IvoryKingFront, n1: Cond.OneWay),
            new(Gate.IvoryKingBack, Gate.IvoryKingFightEndSrc, n1: Cond.OneWay),

            new(Gate.EleumLoyceAfterGettingEyeToSeeGhostsBack, Gate.DLC3EntranceDLC, n1:Cond.OneWay ,n2: Cond.DLC3Key),
            new(Gate.EleumLoyceAfterGettingEyeToSeeGhostsBack, Gate.AavaTheKingsPetEntryFront, n1:Cond.OneWay),
            new(Gate.EleumLoyceAfterGettingEyeToSeeGhostsBack, Gate.EleumLoyceAfterGettingEyeToSeeGhostsFront, n1:Cond.OneWay),
            new(Gate.EleumLoyceAfterGettingEyeToSeeGhostsBack, Gate.AavaTheKingsPetExitBack, n1:Cond.OneWay, n2: Cond.DLC3Unfreezed),
            new(Gate.EleumLoyceAfterGettingEyeToSeeGhostsBack, Gate.EleumLoyceCathedraEntranceFront, n1:Cond.OneWay, n2: Cond.DLC3Unfreezed),

            new(Gate.CoffinWarpSrc, Gate.DLC3EntranceDLC, n1: Cond.FrigidOutskirtsKey, n2: Cond.OneWay),
            new(Gate.CoffinWarpDst, Gate.LudAndZallenEntryFront, n1: Cond.OneWay),
            new(Gate.LudAndZallenEntryBack, Gate.LudAndZallenExitFront),
            new(Gate.LudAndZallenExitBack, Gate.LudAndZallenExitWarp, n1: Cond.OneWay),

            // dranglic castle
            new(Gate.DrangleicCastleToShadedWoodsBack, Gate.FinalFightArenaFront, n1: Cond.OneWay, n2: Cond.KingsRing),
            new(Gate.DrangleicCastleToShadedWoodsBack, Gate.TwinDragonridersEntryFront, n1: Cond.OneWay),
            new(Gate.DrangleicCastleToShadedWoodsBack, Gate.DrangleicCastleToChasmPortalFront, n1: Cond.OneWay),

            new(Gate.FinalFightArenaFront, Gate.TwinDragonridersEntryFront, n1: Cond.OneWay, n2: Cond.KingsRing),
            new(Gate.FinalFightArenaFront, Gate.DrangleicCastleToChasmPortalFront, n1: Cond.KingsRing, n2: Cond.KingsRing),

            new(Gate.TwinDragonridersEntryFront, Gate.DrangleicCastleToChasmPortalFront, n2: Cond.OneWay),

            new(Gate.DrangleicCastleToChasmPortalBack, Gate.ChasmPortalFromCastle, n1: Cond.OneWay, n2: Cond.DarkCovenentJoined),

            new(Gate.TwinDragonridersEntryBack, Gate.TwinDragonridersExitFront),
            new(Gate.TwinDragonridersExitBack, Gate.LookingGlassKnightEntryFront, n1: Cond.OneWay),
            new(Gate.LookingGlassKnightEntryBack, Gate.LookingGlassKnightExitFront),
            new(Gate.LookingGlassKnightExitBack, Gate.ShrineOfAmanaToDrangleicCastleFront),
            // shrine of amana
            new(Gate.ShrineOfAmanaToDrangleicCastleBack, Gate.ShrineOfAmanaTo2ndBonfireFront),
            new(Gate.ShrineOfAmanaTo2ndBonfireBack, Gate.ShrineOfAmanaTo3rdBonfireFront),
            new(Gate.ShrineOfAmanaTo3rdBonfireBack, Gate.DemonOfSongEntryFront),
            new(Gate.DemonOfSongEntryBack, Gate.DemonOfSongExitFront),
            new(Gate.DemonOfSongExitBack, Gate.UndeadCryptToShrineOfAmanaFront, n1: Cond.OneWay),
            // undead crypt
            new(Gate.UndeadCryptToShrineOfAmanaBack, Gate.UndeadCryptFromAgdayneToBonfireFront),
            new(Gate.UndeadCryptToShrineOfAmanaBack, Gate.UndeadCryptFromAgdayneToBonfireBack, n2: Cond.DropDownPath),
            new(Gate.UndeadCryptToShrineOfAmanaBack, Gate.VelsdatEntryFront, n2: Cond.DropDownPath),

            new(Gate.UndeadCryptFromAgdayneToBonfireFront, Gate.UndeadCryptFromAgdayneToBonfireBack, n2: Cond.DropDownPath),
            new(Gate.UndeadCryptFromAgdayneToBonfireFront, Gate.VelsdatEntryFront, n2: Cond.DropDownPath),

            new(Gate.UndeadCryptFromAgdayneToBonfireBack, Gate.VelsdatEntryFront, n1: Cond.DropDownPath),

            new(Gate.VelsdatEntryBack, Gate.VelsdatExitFront),
            new(Gate.VelsdatExitBack, Gate.VendrickFront),
            new(Gate.VendrickBack, Gate.MemoryOfTheKingCryptSrc, n2: Cond.AshenMistHeartKingMemory),
            new(Gate.MemoryOfTheKingMemoryDst, Gate.MemoryOfTheKingMemorySrc, n1: Cond.OneWay),

            // dark chasms
            new(Gate.ChasmPortalFromBlackGulchDungeon, Gate.DarkChasmFromBlackGulchExitFront, n1: Cond.OneWay),
            new(Gate.DarkChasmFromBlackGulchExitBack, Gate.ChasmGulchExitWarp, n1: Cond.OneWay),

            new(Gate.ChasmPortalFromShadedWoodsDungeon, Gate.DarkChasmFromShadedWoodsExitFront, n1: Cond.OneWay),
            new(Gate.DarkChasmFromShadedWoodsExitBack, Gate.ChasmShadedWoodsExitWarp, n1: Cond.OneWay),

            new(Gate.ChasmPortalFromCastleDungeon, Gate.DarkChasmFromDrangleicCastleExitFront, n1: Cond.OneWay),
            new(Gate.DarkChasmFromDrangleicCastleExitBack, Gate.ChasmCastleExitWarp, n1: Cond.OneWay),
        };
    }
}
