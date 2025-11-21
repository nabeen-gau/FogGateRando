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

	public static class Util
	{
        public static String check_backup(String name)
        {
            if (!File.Exists(name + ".bak"))
            {
                File.Copy(name, name + ".bak");
                Console.WriteLine($"[BACKUP] {name}.bak created.");
            }
            return name + ".bak";
        }

        public static String read_string_from_file(String file_path)
        {
            try
            {
                String str = File.ReadAllText(file_path);
                Console.WriteLine($"[SUCCESS] {file_path} loaded.");
                return str;
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"[ERROR] {file_path} not found: {ex.Message}");
                return "";
            }
            catch (IOException ex)
            {
                Console.WriteLine($"[ERROR] {file_path} read error: {ex.Message}");
                return "";
            }
        }

        public static String get_script_helper_fns(String map_name, int map_num)
        {
            String map_id = map_name.Substring(0, 6);
            return @$"
def event_{map_id}_x501(warp_obj_inst_id=_, event_loc=_, map_id=_):
    """"""
    [Function] wait until interact button is pressed on `warp_obj_inst_id` and warp to `event_loc`
    """"""
    assert event_{map_id}_x502(warp_obj_inst_id=warp_obj_inst_id)
    assert event_{map_id}_x503(event_loc=event_loc, warp_obj_inst_id=warp_obj_inst_id, map_id=map_id)
    return 0

def event_{map_id}_x502(warp_obj_inst_id=_):
    """"""
    [Conditions] Wait until interact button is pressed on `warp_obj_inst_id`
    """"""
    IsObjSearched(0, warp_obj_inst_id)
    assert ConditionGroup(0)
    return 0

def event_{map_id}_x503(event_loc=_, warp_obj_inst_id=_, map_id=_):
    """"""
    [Execution] Warp to the given event_location
    """"""
    DisableObjKeyGuide(warp_obj_inst_id, 1)
    ProhibitInGameMenu(1)
    ProhibitPlayerOperation(1)
    SetPlayerInvincible(1)
    PlayCutsceneAndWarpToMap(0, 0, map_id, event_loc, 0)
    assert CutsceneWarpEnded() != 0
    DisableObjKeyGuide(warp_obj_inst_id, 0)
    ProhibitInGameMenu(0)
    ProhibitPlayerOperation(0)
    SetPlayerInvincible(0)
    return 0

def event_{map_id}_x504(battle_id=_):
    """"""Wait until the boss of given battle_id is defeated""""""
    IsEventBossKill(0, battle_id, 0, 1)
    assert ConditionGroup(0)
    return 0

def event_{map_id}_x505(flag8=_):
    """"""[Reproduction] Is boss dead?
    flag8: Boss destruction flag
    """"""
    """"""State 0,1: Are you fighting the boss?""""""
    if GetEventFlag(flag8) != 0:
        """"""State 3: the boss is dead""""""
        return 1
    else:
        """"""State 2: the boss is not dead""""""
        return 0

";
        }

        public static int parse_map_name(string mapCode)
        {
            // Remove non-numeric characters and concatenate the numbers
            string numericPart = string.Empty;
            foreach (char c in mapCode)
            {
                if (char.IsDigit(c))
                {
                    numericPart += c;
                }
            }
            // Parse the resulting string to an integer
            return int.Parse(numericPart);
        }

	}

	public class Constants
	{
		public const int throne_watcher_defender_defeat_flag = 221000091;
		public const int giant_lord_defeat_flag = 100972;
		public const int nashandra_cutscene_flag = 12010;
		public const int vendricks_hostility_flag = 224000088;
	}

	public struct FogGateInfo
	{
		public String map_name;
		public FogGateType type;
		public FogWall fogwall;
		public String content;

		public FogGateInfo(String map_name, FogWall fogwall)
		{
			this.map_name = map_name;
			this.fogwall = fogwall;
			type = new();
			content  = "\n";
			content +=  "##Generated by DS2SFogGateRando##\n";
			content += $"##{map_name}-{fogwall.name}##";
		}
	}

	public struct FogGateType
	{
		public FogGateDetails front;
		public FogGateDetails back;
		public FogGateType(int script_id, int warp_src_id, int warp_dst_id, int warp_dst_map_id,
			List<int>? enemy_ids = null, int chasm_event_flag = -1)
		{
			front = new(script_id,     warp_src_id,     warp_dst_id,     warp_dst_map_id, enemy_ids, chasm_event_flag);
			back  = new(script_id + 1, warp_src_id + 1, warp_dst_id + 1, warp_dst_map_id, enemy_ids, chasm_event_flag);
		}
	}

	public struct FogGateDetails
	{
		public int script_id;
		public int warp_src_id;
		public int warp_dst_id;
		public List<int>? enemy_ids;
		public int chasm_event_flag;
		public int warp_dst_map_id;

		public FogGateDetails(int script_id, int warp_src_id, int warp_dst_id, int warp_dst_map_id,
			List<int>? enemy_ids = null, int chasm_event_flag = -1)
		{
            this.script_id = script_id;
            this.warp_src_id = warp_src_id;
            this.warp_dst_id = warp_dst_id;
			this.warp_dst_map_id = warp_dst_map_id;
            this.enemy_ids = enemy_ids;
            this.chasm_event_flag = chasm_event_flag;
		}
	}
}
