using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace FogWallNS
{
    public enum WarpNode
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
        ChasmDarkLurkerExitWarp,
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

    public struct CondOr2(Cond c1, Cond c2)
    {
        public Cond c1 = c1;
        public Cond c2 = c2;
    }

    public struct CondAnd2(Cond c1, Cond c2)
    {
        public Cond c1 = c1;
        public Cond c2 = c2;
    }

    public enum CondType
    {
        Single,
        Or2,
        And2,
    }

    public struct Condition
    {
        CondType type;
        Cond val;
        CondOr2 or2;
        CondAnd2 and2;
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

    public static class GateConnections
    {
        public static IReadOnlyList<Connection> items { get; } = new List<Connection> {
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

            new(WarpNode.NearPateGiantMemoryEntryBack, WarpNode.NearPateGiantMemoryExit),
            new(WarpNode.NearPursuerGiantMemoryEntryBack, WarpNode.NearPursuerGiantMemoryExit),

            // TODO: add logic for iron key?
            new(WarpNode.ForestOfFallenGiantsAfterFirstBonfireBack, WarpNode.ForestOfFallenGiantsToCaleFront, n1: Cond.DropDownPath),
            new(WarpNode.ForestOfFallenGiantsAfterFirstBonfireBack, WarpNode.ForestOfFallenGiantsBalconyBack, n1: Cond.OneWay),
            new(WarpNode.ForestOfFallenGiantsAfterFirstBonfireBack, WarpNode.GiantLordMemoryEntryFront, n2: Cond.AshenMistHeartSoldiersKeyKingsRing),

            new(WarpNode.ForestOfFallenGiantsToCaleFront, WarpNode.ForestOfFallenGiantsBalconyBack, n2: Cond.OneWay),
            new(WarpNode.ForestOfFallenGiantsToCaleFront, WarpNode.LastGiantFront, n2: Cond.OneWay),
            new(WarpNode.ForestOfFallenGiantsToCaleFront, WarpNode.GiantLordMemoryEntryFront, n2: Cond.AshenMistHeartSoldiersKeyKingsRing),

            new(WarpNode.ForestOfFallenGiantsBalconyBack, WarpNode.LastGiantFront),
            new(WarpNode.ForestOfFallenGiantsBalconyBack, WarpNode.GiantLordMemoryEntryFront, n1: Cond.OneWay, n2: Cond.AshenMistHeartSoldiersKeyKingsRing),

            new(WarpNode.LastGiantBack, WarpNode.Lone),

            new(WarpNode.ForestOfFallenGiantsToCaleBack, WarpNode.ForestOfFallenGiantsBalconyFront),
            new(WarpNode.ForestOfFallenGiantsToCaleBack, WarpNode.ForestOfFallenGiantsToPursuerArenaFront, n1: Cond.OneWay, n2: Cond.SoldiersKey),
            new(WarpNode.ForestOfFallenGiantsToCaleBack, WarpNode.PursuerExitBack, n2: Cond.OneWay),
            new(WarpNode.ForestOfFallenGiantsToCaleBack, WarpNode.NearPursuerGiantMemoryEntryFront, n2: Cond.OneWay),
            new(WarpNode.ForestOfFallenGiantsToCaleBack, WarpNode.NearPateGiantMemoryEntryFront, n2: Cond.AshenMistHeart),

            new(WarpNode.ForestOfFallenGiantsBalconyFront, WarpNode.ForestOfFallenGiantsToPursuerArenaFront, n1: Cond.OneWay, n2: Cond.SoldiersKey),
            new(WarpNode.ForestOfFallenGiantsBalconyFront, WarpNode.PursuerExitBack, n2: Cond.OneWay),
            new(WarpNode.ForestOfFallenGiantsBalconyFront, WarpNode.NearPursuerGiantMemoryEntryFront, n2: Cond.OneWay),
            new(WarpNode.ForestOfFallenGiantsBalconyFront, WarpNode.NearPateGiantMemoryEntryFront, n2: Cond.AshenMistHeart),

            new(WarpNode.ForestOfFallenGiantsToPursuerArenaFront, WarpNode.PursuerExitBack, n1:Cond.SoldiersKey, n2: Cond.OneWay),
            new(WarpNode.ForestOfFallenGiantsToPursuerArenaFront, WarpNode.NearPursuerGiantMemoryEntryFront, n1: Cond.SoldiersKey, n2: Cond.OneWay),
            new(WarpNode.ForestOfFallenGiantsToPursuerArenaFront, WarpNode.NearPateGiantMemoryEntryFront, n1: Cond.SoldiersKey, n2: Cond.AshenMistHeartSoldiersKey),

            new(WarpNode.PursuerExitBack, WarpNode.NearPursuerGiantMemoryEntryFront, n2: Cond.AshenMistHeart),
            new(WarpNode.PursuerExitBack, WarpNode.NearPateGiantMemoryEntryFront, n1: Cond.OneWay, n2: Cond.AshenMistHeart),
            new(WarpNode.PursuerExitBack, WarpNode.NearPursuerBirdEntry, n1: Cond.OneWay),

            new(WarpNode.NearPursuerGiantMemoryEntryFront, WarpNode.NearPateGiantMemoryEntryFront, n1: Cond.OneWay, n2: Cond.AshenMistHeart),

            new(WarpNode.ForestOfFallenGiantsToPursuerArenaBack, WarpNode.PursuerEntryFront),

            new(WarpNode.PursuerEntryBack, WarpNode.PursuerExitFront),

            new(WarpNode.GiantLordEntryFront, WarpNode.GiantLordMemoryEntryBack, n2: Cond.OneWay),
            new(WarpNode.GiantLordEntryBack, WarpNode.GiantLordExitFront),
            new(WarpNode.GiantLordExitBack, WarpNode.GiantLordMemoryExit),

            // lost bastille
            new(WarpNode.NearPursuerBirdExit, WarpNode.RuinSentinelsEntryFront, n2: Cond.FragrantBranchOfYore, n1: Cond.OneWay),

            new(WarpNode.RuinSentinelsEntryFront, WarpNode.LostBastilleToShipFromWharfBack, n2: Cond.OneWay, n1: Cond.FragrantBranchOfYore),
            new(WarpNode.RuinSentinelsEntryFront, WarpNode.RuinSentinesUpperExitBack, n2: Cond.OneWay),

            new(WarpNode.LostBastilleToShipFromWharfBack, WarpNode.LostBastilleToSinnersRiseFront, n1: Cond.OneWay, n2: Cond.OldKeyInBastille),
            new(WarpNode.LostBastilleToShipFromWharfBack, WarpNode.RuinSentinesUpperExitBack, n1: Cond.OldKeyInBastille, n2: Cond.OneWay),

            new(WarpNode.LostBastilleToSinnersRiseFront, WarpNode.RuinSentinesUpperExitBack, n1: Cond.OldKeyInBastille, n2: Cond.OneWay),

            new(WarpNode.PirateShipBastille, WarpNode.LostBastilleToShipFromWharfFront, n1: Cond.OneWay),

            new(WarpNode.LostBastilleToSinnersRiseBack, WarpNode.LostSinnerEntryFront, n1: Cond.BastilleKey),
            new(WarpNode.LostSinnerEntryBack, WarpNode.LostSinnerExitFront, n1: Cond.OneWay),
            new(WarpNode.LostSinnerExitBack, WarpNode.Lone),

            new(WarpNode.RuinSentinelsEntryBack, WarpNode.RuinSentinelsHiddenDoor1Front, n1: Cond.OneWay),
            new(WarpNode.RuinSentinelsEntryBack, WarpNode.RuinSentinelsHiddenDoor2Front, n1: Cond.OneWay),
            new(WarpNode.RuinSentinelsEntryBack, WarpNode.RuinSentinelsHiddenDoor3Front, n1: Cond.OneWay),
            new(WarpNode.RuinSentinelsEntryBack, WarpNode.RuinSentinelsHiddenDoor4Front, n1: Cond.OneWay),
            new(WarpNode.RuinSentinelsEntryBack, WarpNode.RuinSentinelsExitFront, n1: Cond.OneWay),

            new(WarpNode.RuinSentinelsHiddenDoor1Front, WarpNode.RuinSentinelsHiddenDoor2Front),
            new(WarpNode.RuinSentinelsHiddenDoor1Front, WarpNode.RuinSentinelsHiddenDoor3Front),
            new(WarpNode.RuinSentinelsHiddenDoor1Front, WarpNode.RuinSentinelsHiddenDoor4Front),
            new(WarpNode.RuinSentinelsHiddenDoor1Front, WarpNode.RuinSentinelsExitFront),
            new(WarpNode.RuinSentinelsHiddenDoor1Front, WarpNode.RuinSentinelsExitBack, n2: Cond.OneWay),

            new(WarpNode.RuinSentinelsHiddenDoor2Front, WarpNode.RuinSentinelsHiddenDoor3Front),
            new(WarpNode.RuinSentinelsHiddenDoor2Front, WarpNode.RuinSentinelsHiddenDoor4Front),
            new(WarpNode.RuinSentinelsHiddenDoor2Front, WarpNode.RuinSentinelsExitFront),
            new(WarpNode.RuinSentinelsHiddenDoor2Front, WarpNode.RuinSentinelsExitBack, n2: Cond.OneWay),

            new(WarpNode.RuinSentinelsHiddenDoor3Front, WarpNode.RuinSentinelsHiddenDoor4Front),
            new(WarpNode.RuinSentinelsHiddenDoor3Front, WarpNode.RuinSentinelsExitFront),
            new(WarpNode.RuinSentinelsHiddenDoor3Front, WarpNode.RuinSentinelsExitBack, n2: Cond.OneWay),

            new(WarpNode.RuinSentinelsHiddenDoor4Front, WarpNode.RuinSentinelsExitFront),
            new(WarpNode.RuinSentinelsHiddenDoor4Front, WarpNode.RuinSentinelsExitBack, n2: Cond.OneWay),

            new(WarpNode.RuinSentinelsExitFront, WarpNode.RuinSentinelsExitBack, n2: Cond.OneWay),

            new(WarpNode.RuinSentinelsHiddenDoor1Back, WarpNode.Lone),
            new(WarpNode.RuinSentinelsHiddenDoor2Back, WarpNode.Lone),
            new(WarpNode.RuinSentinelsHiddenDoor3Back, WarpNode.Lone),
            new(WarpNode.RuinSentinelsHiddenDoor4Back, WarpNode.Lone),

            new(WarpNode.RuinSentinesUpperExitFront, WarpNode.RuinSentinelsHiddenDoor1Front, n1: Cond.OneWay),
            new(WarpNode.RuinSentinesUpperExitFront, WarpNode.RuinSentinelsHiddenDoor2Front, n1: Cond.OneWay),
            new(WarpNode.RuinSentinesUpperExitFront, WarpNode.RuinSentinelsHiddenDoor3Front, n1: Cond.OneWay),
            new(WarpNode.RuinSentinesUpperExitFront, WarpNode.RuinSentinelsHiddenDoor4Front, n1: Cond.OneWay),
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
            new(WarpNode.HeidesToMajulaBack, WarpNode.OldDragonslayerEntryFront),

            new(WarpNode.DragonriderEntryFront, WarpNode.OldDragonslayerEntryFront),

            new(WarpNode.DragonriderEntryBack, WarpNode.DragonriderExitFront),

            new(WarpNode.OldDragonslayerEntryBack, WarpNode.OldDragonslayerExitFront),

            new(WarpNode.OldDragonslayerExitBack, WarpNode.Lone),

            new(WarpNode.DragonriderExitBack, WarpNode.HeidesToWharfFront),
            new(WarpNode.HeidesToWharfBack, WarpNode.NoMansWharfToHeidesFront),

            // no man's wharf
            new(WarpNode.NoMansWharfToHeidesBack, WarpNode.FlexileSentryEntryFront, n1: Cond.ShipBellRang, n2: Cond.ShipBellRang),
            new(WarpNode.FlexileSentryEntryBack, WarpNode.FlexileSentryExitFront, n1: Cond.ShipBellRang, n2: Cond.ShipBellRang), // TODO: what to do here should the ship spawn at wharf??
            new(WarpNode.FlexileSentryExitBack, WarpNode.PirateShipWharf, n1: Cond.ShipBellRang, n2: Cond.ShipBellRang),

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
            new(WarpNode.BrumeTowerToFoyerBonfireFromOutsideBack, WarpNode.SirAlonneArmorDLC, n1: Cond.OneWay, n2: Cond.ScorchingIronSceptor),

            new(WarpNode.BrumeTowerFrom2ndBonfireToCentralRoomBack, WarpNode.SirAlonneArmorDLC, n1: Cond.OneWay, n2: Cond.ActivateBrumeTower),

            new(WarpNode.SirAlonneArmorMemory, WarpNode.SirAlonneEntryFront, n1: Cond.OneWay),
            new(WarpNode.SirAlonneEntryBack, WarpNode.SirAlonneExitFront),
            new(WarpNode.SirAlonneExitBack, WarpNode.SirAlonneMemoryExit),

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
            new(WarpNode.BlackGulchEntranceBack, WarpNode.ChasmPortalFromBlackGulch, n1: Cond.OneWay, n2: Cond.DarkCovenentJoinedForgottenKey),
            new(WarpNode.ChasmPortalFromBlackGulch, WarpNode.TheRottenEntryFront, n1: Cond.DarkCovenentJoinedForgottenKey, n2: Cond.OneWay),

            new(WarpNode.TheRottenEntryBack, WarpNode.TheRottenExitFront),
            new(WarpNode.TheRottenExitBack, WarpNode.DLC1EntranceBaseGame),
            // dlc1
            new(WarpNode.DLC1EntranceDLC, WarpNode.ShulvaEntranceFront, n1: Cond.DLC1Key, n2: Cond.DLC1Key),
            new(WarpNode.ShulvaEntranceBack, WarpNode.NearJesterThomasFront, n1: Cond.OneWay),
            new(WarpNode.ShulvaEntranceBack, WarpNode.ShulvaToGankFight1Front, n1: Cond.OneWay, n2: Cond.ShulvaSanctumKey),

            new(WarpNode.NearJesterThomasBack, WarpNode.ShulvaEntranceBack, n1: Cond.OneWay),
            new(WarpNode.NearJesterThomasBack, WarpNode.ElanaTheSqualidQueenFront, n1: Cond.OneWay, n2: Cond.ActivateDragonStone),

            new(WarpNode.ElanaTheSqualidQueenBack, WarpNode.BetweenElanaAndSihnFront, n1: Cond.OneWay),
            new(WarpNode.BetweenElanaAndSihnBack, WarpNode.SihnTheSlumberingDragonFront),
            new(WarpNode.SihnTheSlumberingDragonBack, WarpNode.Lone),

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

            new(WarpNode.ChasmPortalFromShadedWoods, WarpNode.ShadedWoodsToMistyAreaBack, n1: Cond.DarkCovenentJoined),
            new(WarpNode.ChasmPortalFromShadedWoods, WarpNode.ScorpionessNajkaEntryFront, n1: Cond.DarkCovenentJoined),

            new(WarpNode.RoyalRatAuthorityEntryFront, WarpNode.DoorOfPharrosToOrdealEndBonfireBack),
            new(WarpNode.RoyalRatAuthorityEntryBack, WarpNode.RoyalRatAuthorityExitFront),
            new(WarpNode.DoorOfPharrosToOrdealEndBonfireFront, WarpNode.DoorOfPharrosToRatKingDomainBack),

            // brightstone cove
            new(WarpNode.BrightstoneCoveToDoorsOfPharrosBack, WarpNode.CongregationEntryFront),
            new(WarpNode.CongregationEntryBack, WarpNode.CongregationExitFront),
            new(WarpNode.CongregationExitBack, WarpNode.DukesDearFreyjaEntryFront, n1: Cond.OneWay),
            new(WarpNode.DukesDearFreyjaEntryBack, WarpNode.DukesDearFreyjaExitFront),
            new(WarpNode.DukesDearFreyjaExitBack, WarpNode.Lone),
            new(WarpNode.DukesDearFreyjaEntryBack, WarpNode.DragonMemoriesCoveSrc, n2: Cond.AshenMistHeart),
            new(WarpNode.DukesDearFreyjaExitFront, WarpNode.DragonMemoriesCoveSrc, n2: Cond.AshenMistHeart),
            new(WarpNode.DragonMemoriesMemoryDst, WarpNode.DragonMemoriesMemorySrc, n1: Cond.OneWay),

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
            new(WarpNode.LudAndZallenExitBack, WarpNode.LudAndZallenExitWarp, n1: Cond.OneWay),

            // dranglic castle
            new(WarpNode.DrangleicCastleToShadedWoodsBack, WarpNode.FinalFightArenaFront, n1: Cond.OneWay, n2: Cond.KingsRing),
            new(WarpNode.DrangleicCastleToShadedWoodsBack, WarpNode.TwinDragonridersEntryFront, n1: Cond.OneWay),
            new(WarpNode.DrangleicCastleToShadedWoodsBack, WarpNode.DrangleicCastleToChasmPortalFront, n1: Cond.OneWay),

            new(WarpNode.FinalFightArenaFront, WarpNode.TwinDragonridersEntryFront, n1: Cond.OneWay, n2: Cond.KingsRing),
            new(WarpNode.FinalFightArenaFront, WarpNode.DrangleicCastleToChasmPortalFront, n1: Cond.KingsRing, n2: Cond.KingsRing),

            new(WarpNode.TwinDragonridersEntryFront, WarpNode.DrangleicCastleToChasmPortalFront, n2: Cond.OneWay),

            new(WarpNode.DrangleicCastleToChasmPortalBack, WarpNode.ChasmPortalFromCastle, n1: Cond.OneWay, n2: Cond.DarkCovenentJoined),

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

            // dark chasms
            new(WarpNode.ChasmPortalFromBlackGulchDungeon, WarpNode.DarkChasmFromBlackGulchExitFront, n1: Cond.OneWay),
            new(WarpNode.DarkChasmFromBlackGulchExitBack, WarpNode.ChasmGulchExitWarp, n1: Cond.OneWay),

            new(WarpNode.ChasmPortalFromShadedWoodsDungeon, WarpNode.DarkChasmFromShadedWoodsExitFront, n1: Cond.OneWay),
            new(WarpNode.DarkChasmFromShadedWoodsExitBack, WarpNode.ChasmShadedWoodsExitWarp, n1: Cond.OneWay),

            new(WarpNode.ChasmPortalFromCastleDungeon, WarpNode.DarkChasmFromDrangleicCastleExitFront, n1: Cond.OneWay),
            new(WarpNode.DarkChasmFromDrangleicCastleExitBack, WarpNode.ChasmCastleExitWarp, n1: Cond.OneWay),

            new(WarpNode.DarkLurkerExitBack, WarpNode.ChasmDarkLurkerExitWarp, n1: Cond.OneWay),
            new(WarpNode.DarkLurkerExitFront, WarpNode.Lone),

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
            new(Cond.FragrantBranchOfYore, WarpNode.LostSinnerExitBack),
            new(Cond.FragrantBranchOfYore, WarpNode.SkeletonLordsExitBack),
            new(Cond.FragrantBranchOfYore, WarpNode.GiantLordMemoryEntryFront), // TODO: this is complicated
            new(Cond.FragrantBranchOfYore, WarpNode.NearPursuerBirdExit),
            new(Cond.FragrantBranchOfYore, WarpNode.TheGutterFromGraveOfSaintsBack),
            new(Cond.FragrantBranchOfYore, WarpNode.BlackGulchEntranceFront, WarpNode.GutterNearAntQueenBack),
            new(Cond.FragrantBranchOfYore, WarpNode.VelsdatEntryFront, WarpNode.UndeadCryptFromAgdayneToBonfireBack),
            new(Cond.FragrantBranchOfYore, WarpNode.DragonAerieToAldiasKeepBack, WarpNode.AncientDragonFront),
            new(Cond.FragrantBranchOfYore, WarpNode.DukesDearFreyjaExitBack),
            new(Cond.RotundaLockstone, WarpNode.DragonriderExitBack, WarpNode.HeidesToWharfFront),
            new(Cond.RotundaLockstone, WarpNode.HeidesToWharfFront),
            new(Cond.SoldiersKey, WarpNode.LastGiantBack),
            new(Cond.KingsRing, WarpNode.VendrickBack, WarpNode.MemoryOfTheKingCryptSrc),
            new(Cond.KingsRingFragrantBranch, Cond.KingsRing, Cond.FragrantBranchOfYore),
            new(Cond.FirstFourSouls, new(){})
        };

        public static IReadOnlyList<WarpNode> cannot_warp_from = new List<WarpNode>
        {
            WarpNode.NearPursuerBirdExit,
            WarpNode.NearPateGiantMemoryEntryBack,
            WarpNode.NearPursuerGiantMemoryEntryBack,
            WarpNode.GiantLordMemoryEntryBack,
            WarpNode.DragonMemoriesMemoryDst,
            WarpNode.SirAlonneArmorMemory,
            WarpNode.PirateShipBastille,
            WarpNode.CoffinWarpDst,
            WarpNode.IvoryKingFightEndDst,
            WarpNode.ChasmPortalFromBlackGulchDungeon,
            WarpNode.ChasmPortalFromCastleDungeon,
            WarpNode.ChasmPortalFromShadedWoodsDungeon,
            WarpNode.IvoryKingBack,
        };

        public static IReadOnlyList<WarpNode> cannot_warp_to = new List<WarpNode>
        {
            WarpNode.NearPursuerBirdEntry,
            WarpNode.NearPateGiantMemoryExit,
            WarpNode.NearPursuerGiantMemoryExit,
            WarpNode.GiantLordMemoryExit,
            WarpNode.DragonMemoriesMemorySrc,
            WarpNode.SirAlonneMemoryExit,
            WarpNode.PirateShipWharf,
            WarpNode.LudAndZallenExitWarp,
            WarpNode.IvoryKingFightEndSrc,
            WarpNode.ChasmCastleExitWarp,
            WarpNode.ChasmDarkLurkerExitWarp,
            WarpNode.ChasmGulchExitWarp,
            WarpNode.ChasmShadedWoodsExitWarp,
        };

        public static IReadOnlyList<WarpNode> reqd_gates_to_complete_game = new List<WarpNode>
        {
            WarpNode.FinalFightArenaBack,
            WarpNode.GiantLordEntryBack,
        };
    }

    class TreeNode
    {
        public WarpNode Value;
        public List<TreeNode> Children = new List<TreeNode>();


        public TreeNode(WarpNode value)
        {
            Value = value;
        }

        public static TreeNode? BuildTraversalTree(Graph graph, WarpNode startNode, HashSet<WarpNode>? visited = null)
        {
            if (visited == null)
                visited = new HashSet<WarpNode>();

            // Avoid cycles
            if (visited.Contains(startNode))
                return null;

            visited.Add(startNode);

            var node = new TreeNode(startNode);

            foreach (var next in graph.Edges[startNode])
            {
                var child = BuildTraversalTree(graph, next, visited);
                if (child != null)
                    node.Children.Add(child);
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

        public void AddNode(WarpNode node)
        {
            if (!Edges.ContainsKey(node))
                Edges[node] = new List<WarpNode>();
        }

        public void AddEdge(WarpNode from, WarpNode to)
        {
            AddNode(from);
            AddNode(to);
            Edges[from].Add(to);
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
        public void Add(WarpNode src, WarpNode dst, CType type)
        {
            Add(src);
            Add(dst);
            items[src].Add(new(dst, type));
        }

        public bool Contains(WarpNode node)
        {
            return items.ContainsKey(node);
        }
    }
}
