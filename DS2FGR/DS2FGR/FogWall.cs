using System.Numerics;

namespace FogWallNS
{
	public class FogWall
	{
		public Gate name;
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
		public bool front_blocked;
		public bool back_blocked;
		public FogWall(Gate name, String map_name, BossName boss_name = BossName.None,
			int event_id = -1, bool use_second_death_check_impl = false, bool reverse = false,
			bool pvp = false, bool boss_exit = false, bool cutscene = false, bool front_blocked = false, bool back_blocked = false)
		{
			this.name = name;
			this.map_name = map_name;
			this.instance_id = -1;
			this.pvp = pvp;
			this.boss_exit = boss_exit;
			this.offset = null;
			this.cutscene = cutscene;
			this.event_id = event_id;
			this.boss_name = boss_name;
			this.destruction_flag = -1;
			this.twin_gate_id = -1;
			this.use_second_death_check_impl = use_second_death_check_impl;
			this.reverse = reverse;
			this.front_blocked = front_blocked;
            this.back_blocked = back_blocked;
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

	public struct BossDetails
	{
		public Gate name_str;
		public BossName name;
		public int destruction_flag;
		public bool use_second_death_check_impl;
		public bool cutscene;
		public bool exit;

		public BossDetails(FogWall fw)
		{
			name_str = fw.name;
			name = fw.boss_name;
			destruction_flag = fw.destruction_flag;
			use_second_death_check_impl = fw.use_second_death_check_impl;
			cutscene = fw.cutscene;
			exit = fw.boss_exit;
		}
	}

	public struct WarpInfo
	{
		public String map_name;
		public int script_id;
		public int warp_src_id;
		public int fog_gate_id;
		public int location_id;
		public BossDetails boss;
		public List<int>? enemy_ids;
		public int chasm_event_flag;
		public bool boss_locked;
		public Gate fog_wall_name;
		public int cutscene_script_id;
		public int twin_fog_gate_id;
		public bool front;

		public WarpInfo(String map_name, int script_id, int warp_src_id, int fog_gate_id, int location_id, FogWall fw,
			List<int>? enemy_ids = null, int chasm_event_flag = -1, bool boss_locked = true, int cutscene_script_id = -1,
			bool front = false)
        {
            this.map_name = map_name;
            this.script_id = script_id;
			this.warp_src_id = warp_src_id;
            this.fog_gate_id = fog_gate_id;
            this.location_id = location_id;
			boss = new BossDetails(fw);
			this.enemy_ids = enemy_ids;
			this.chasm_event_flag = chasm_event_flag;
			this.boss_locked = boss_locked;
			fog_wall_name = fw.name;
			this.cutscene_script_id = cutscene_script_id;
			twin_fog_gate_id = fw.twin_gate_id;
			this.front = front;
		}
	}

	public struct Warp
	{
		public WarpInfo from;
		public WarpInfo to;

		public Warp(FogGateInfo fgi)
		{
			bool boss_locked_from = false;
			bool boss_locked_to   = false;
            if (fgi.fogwall.boss_name != BossName.None)
			{
				boss_locked_from =  fgi.fogwall.boss_exit;
				boss_locked_to   = !fgi.fogwall.boss_exit;
			}
			int cutscene_script_id = -1;
			if (fgi.fogwall.cutscene)
			{
				cutscene_script_id = fgi.type.back.script_id + 1;
			}
			from = new(fgi.map_name, fgi.type.front.script_id, fgi.type.front.warp_src_id, fgi.fogwall.instance_id,
				fgi.type.back.warp_dst_id, fgi.fogwall, 
				enemy_ids: fgi.type.front.enemy_ids, chasm_event_flag: fgi.type.front.chasm_event_flag, 
				boss_locked: boss_locked_from, cutscene_script_id: cutscene_script_id, front: true);
			to   = new(fgi.map_name, fgi.type.back.script_id, fgi.type.back.warp_src_id, fgi.fogwall.instance_id,
				fgi.type.front.warp_dst_id, fgi.fogwall, 
				enemy_ids: fgi.type.front.enemy_ids, chasm_event_flag: fgi.type.front.chasm_event_flag,
				boss_locked: boss_locked_to, cutscene_script_id: cutscene_script_id, front: false);
		}

        public Warp(WarpInfo from, WarpInfo to)
        {
            this.from = from;
            this.to = to;
        }
    }

    public static class WarpScrambler
    {
        private static Random rng = new Random();
        public static List<Warp> Scramble(List<Warp> warps)
        {
            int n = warps.Count;
            if (n <= 1) return new List<Warp>(warps);
            List<WarpInfo> fromList = new List<WarpInfo>(n);
            List<WarpInfo> toList = new List<WarpInfo>(n);

            foreach (var w in warps)
            {
                fromList.Add(w.from);
                toList.Add(w.to);
            }
            Shuffle(toList);
            var result = new List<Warp>(n);
            for (int i = 0; i < n; i++)
            {
                result.Add(new Warp(fromList[i], toList[i]));
            }
            return result;
        }

        private static void Shuffle<T>(IList<T> list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }
        }
    }
}
