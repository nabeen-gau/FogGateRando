using System.Numerics;

namespace FogWallNS
{
	public class FogWall
	{
		public String name;
		public String map_name;
		public int instance_id;
		bool pvp;
		public bool cutscene;
		public bool boss_exit;
		public Vector3? offset;
		public int event_id; // cutscene event id
		public BossName boss_name;
		public int destruction_flag;
		public int twin_gate_id;
		public bool use_second_death_check_impl;
		public bool reverse;
		public FogWall(String name, String map_name, BossName boss_enum_id = BossName.None,
			int event_id = -1, bool use_second_death_check_impl = false, bool reverse = false,
			bool pvp = false, bool boss_exit = false, bool cutscene = false)
		{
			this.name = name;
			this.map_name = map_name;
			this.instance_id = -1;
			this.pvp = pvp;
			this.boss_exit = boss_exit;
			this.offset = null;
			this.cutscene = cutscene;
			this.event_id = event_id;
			this.boss_name = boss_enum_id;
			this.destruction_flag = -1;
			this.twin_gate_id = -1;
			this.use_second_death_check_impl = use_second_death_check_impl;
			this.reverse = reverse;
		}
	};

	enum MapName
	{
		ThingsBetwixt = 0,
		Majula,
		ForestOfTheFallenGiants,
		BrightstoneCoveTseldora,
		AldiasKeep,
		TheLostBastilleBelfryLuna,
		HarvestValleyEarthenPeak,
		NomansWharf,
		IronKeepBelfrySol,
		HuntsmanCopseUndeadPurgatory,
		TheGutterBlackGulch,
		DragonAerieDragonShrine,
		MajulaShadedWoods,
		HeidesToNoMansWharf,
		HeidesTowerofFlame,
        ShadedWoodsShrineofWinter,
		DoorsofPharros,
		GraveofSaints,
		MemoryofVammarOrroandJeigh,
		ShrineofAmana,
		DrangleicCastleThroneofWant,
		UndeadCrypt,
		DragonMemories,
		DarkChasmofOld,
		ShulvaSanctumCity,
		BrumeTower,
		FrozenEleumLoyce,
		MemoryoftheKing
	}

	public enum BossName
	{
		None,
		TheLastGiant,
        ThePursuer,
		Dragonrider,
		OldDragonslayer,
		FlexileSentry,
		RuinSentinels,
		TheLostSinner,
		BelfryGargoyles,
		SkeletonLords,
		ExecutionersChariot,
		CovetousDemon,
		MythaTheBanefulQueen,
		SmelterDemon,
		OldIronKing,
		ScorpionessNajka,
		RoyalRatAuthority,
		ProwlingMagusAndCongregation,
		TheDukesDearFreja,
		RoyalRatVanguard,
		TheRotten,
		TwinDragonrider,
		LookingGlassKnight,
		DemonofSong,
		VelstadtTheRoyalAegis,
		Vendrick,
		GuardianDragon,
		AncientDragon,
		GiantLord,
		ThroneWatcherAndDefender,
		Nashandra,
		AldiaScholarOfTheFirstSin,
		Darklurker,
		ElanaTheSqualidQueen,
		SinhTheSlumberingDragon,
		Gankfight,
		FumeKnight,
		SirAlonne,
		BlueSmelterDemon,
		AavaTheKingsPet,
		BurntIvoryKing,
		LudAndZallen
	}


	public struct StringChange
	{
		public String from;
		public String to;

		public StringChange(String from, String to)
		{
			this.from = from;
			this.to = to;
		}
	}

	public struct EventID
	{
		public int event_loc_id;
		public Vector3 position;

		public EventID(int event_loc_id, Vector3 position)
		{
			this.event_loc_id = event_loc_id;
			this.position = position;
		}
	}

	public struct FogGateInfo
	{
		String map_name;
		int script_id;
		int warp_src_id;
		int warp_dst_id;
		FogWall? fogwall;
		int throne_watcher_defender_defeat_flag;
		int giant_lord_defeat_flag;
		int nashandra_cutscene_flag;
		List<int>? enemy_ids;
		int chasm_event_flag;
		int vendricks_hostility_flag;
		int throne_duo_defeat_flag;

		public FogGateInfo(String map_name, int script_id, int warp_src_id, int warp_dst_id,
			FogWall? fogwall = null, int throne_watcher_defender_defeat_flag = -1,
            int giant_lord_defeat_flag = -1, int nashandra_cutscene_flag = -1,
            List<int>? enemy_ids = null, int chasm_event_flag = -1,
            int vendricks_hostility_flag = -1, int throne_duo_defeat_flag = -1
		)
		{
            this.map_name = map_name;
            this.script_id = script_id;
            this.warp_src_id = warp_src_id;
            this.warp_dst_id = warp_dst_id;
            this.fogwall = fogwall;
            this.throne_watcher_defender_defeat_flag = throne_watcher_defender_defeat_flag;
            this.giant_lord_defeat_flag = giant_lord_defeat_flag;
            this.nashandra_cutscene_flag = nashandra_cutscene_flag;
            this.enemy_ids = enemy_ids;
            this.chasm_event_flag = chasm_event_flag;
            this.vendricks_hostility_flag = vendricks_hostility_flag;
            this.throne_duo_defeat_flag = throne_duo_defeat_flag;
		}
	}
}
